using System.ComponentModel.DataAnnotations;

namespace MeetlyOmni.Core;

public class DateValidationAttribute : ValidationAttribute
{
    private readonly string _startTimePropertyName;
    private readonly string _endTimePropertyName;

    public DateValidationAttribute(string startTimePropertyName, string endTimePropertyName)
    {
        this._startTimePropertyName = startTimePropertyName;
        this._endTimePropertyName = endTimePropertyName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // use generic validation to get type and properties
        var objectValueType = validationContext.ObjectType;

        var startTimeProperty = objectValueType.GetProperty(_startTimePropertyName);
        var endTimeProperty = objectValueType.GetProperty(_endTimePropertyName);
        // if not found these two property return not found
        if (startTimeProperty == null || endTimeProperty == null)
        {
            return new ValidationResult(
                $"Property {_startTimePropertyName} or {_endTimePropertyName} cannot found"
            );
        }

        // get start time and end time value
        var startTime = startTimeProperty.GetValue(validationContext.ObjectInstance) as DateTime?;
        var endTime = endTimeProperty.GetValue(validationContext.ObjectInstance) as DateTime?;
        if (startTime == null || endTime == null)
        {
            return new ValidationResult($"Value {startTime} or {endTime} cannot found");
        }
        // start time cannot be greater than end time
        if (startTime >= endTime)
        {
            return new ValidationResult(
                $"Value {startTime} cannot greater than {endTime}, this is not correct."
            );
        }
        return ValidationResult.Success;
    }
}
