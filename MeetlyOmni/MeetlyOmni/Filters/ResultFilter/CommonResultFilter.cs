using System.Net;
using MeetlyOmni.Core.WrapperResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeetlyOmni.Filters.ResultFilter;

public class CommonResultFilter : IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context) { }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        // Check if the result is not an ObjectResult (JSON or other serialized content).
        if (context.Result is not ObjectResult objectResult)
            return;

        // Check if the result type is a generic or non-generic ApiResponseResult.
        if (
            objectResult.DeclaredType == null
            || objectResult.DeclaredType == typeof(ApiResponseResult)
        )
        {
            return;
        }
        if (
            objectResult.DeclaredType.IsGenericType
            && objectResult.DeclaredType.GetGenericTypeDefinition() == typeof(ApiResponseResult<>)
        )
        {
            return;
        }

        // if the object value is null
        // return 404
        if (objectResult.Value == null)
        {
            var noFoundApiResonseResult = new ApiResponseResult()
            {
                IsSuccess = false,
                Status = (int)HttpStatusCode.NotFound,
                Message = "Data cannot found.",
                Time = DateTime.Now,
            };
            context.Result = new JsonResult(noFoundApiResonseResult)
            {
                StatusCode = (int)HttpStatusCode.NotFound,
            };
            return;
        }

        // if the object value is not null
        var apiResponseResult = new ApiResponseResult<object>()
        {
            IsSuccess =
                context.HttpContext.Response.StatusCode >= (int)HttpStatusCode.OK
                && context.HttpContext.Response.StatusCode <= (int)HttpStatusCode.NoContent,
            Status = context.HttpContext.Response.StatusCode,
            Data = objectResult.Value,
            Message = "Successful",
            Time = DateTime.Now,
        };
        context.Result = new JsonResult(apiResponseResult)
        {
            StatusCode = context.HttpContext.Response.StatusCode,
        };
    }
}
