# MeetlyOmni-Backend
c# ASP Dotnet Core PostgreSQL


# Installation
1. Clone repository
git clone
cd MeetlyOmni

> 2. Linting and Code Formatting
// run the follwing command in the root directory of the repository:
dotnet new tool-mainfest
dotnet tool install csharpier --local

dotnet tool restore

dotnet csharpier .

> 3. Pre-commit Hook
pre-commit install


> 4. Test:
pre-commit run --all-files
