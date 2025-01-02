using MeetlyOmni.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetlyOmni.Models;

public class OmniDbContext : IdentityDbContext<IdentityUser>
{
    public OmniDbContext(DbContextOptions<OmniDbContext> options)
        : base(options) { }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure Entity
        ConfigureEvents(builder);
    }

    private void ConfigureEvents(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(e =>
        {
            e.ToTable("Events");
            e.HasKey(e => e.Id);
            e.Property(x => x.Id).ValueGeneratedOnAdd();
            e.Property(x => x.EventName).IsRequired().HasMaxLength(255);
            e.Property(x => x.GameId).IsRequired();
            e.Property(x => x.GameMasterId).IsRequired();
            e.Property(x => x.HostUserId).IsRequired();
            e.Property(x => x.Pin).IsRequired().HasMaxLength(6);
            e.Property(x => x.UserLimit).IsRequired().HasDefaultValue(1);
            e.Property(x => x.Location).IsRequired().HasMaxLength(255);
            e.Property(x => x.AccessMode)
                .HasConversion(
                    v => v.ToString(),
                    v => (AccessMode)Enum.Parse(typeof(AccessMode), v)
                )
                .IsRequired();
            e.Property(x => x.Type)
                .HasConversion(v => v.ToString(), v => (GameType)Enum.Parse(typeof(GameType), v))
                .IsRequired();
            e.Property(x => x.StartTime).IsRequired();
            e.Property(x => x.EndTime).IsRequired();
            e.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd(); // Ensures the value is generated only during insert;
            e.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnType("timestamp without time zone")
                .HasDefaultValueSql("NOW()");
        });
    }
}
