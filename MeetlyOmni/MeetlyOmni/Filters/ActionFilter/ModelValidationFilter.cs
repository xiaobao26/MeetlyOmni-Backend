using System.Net;
using MeetlyOmni.Core.WrapperResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeetlyOmni.Filters.ActionFilter
{
    public class ModelValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        // run before controller action is executed
        // used to check model validation
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor == null)
                return;

            if (!context.ModelState.IsValid)
            {
                var errorResultsList = new List<ErrorResults>();
                foreach (var item in context.ModelState)
                {
                    if (item.Value.Errors.Count > 0)
                    {
                        var errorResult = new ErrorResults
                        {
                            Field = item.Key,
                            Errors = item.Value.Errors.Select(x => x.ErrorMessage).ToList(),
                        };
                        errorResultsList.Add(errorResult);
                    }
                }

                var apiResponseResult = new ApiResponseResult<List<ErrorResults>>
                {
                    IsSuccess = false,
                    Status = (int)HttpStatusCode.BadRequest,
                    Message = "Model validation failure",
                    Time = DateTime.Now,
                    Data = errorResultsList,
                };

                context.Result = new JsonResult(apiResponseResult)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }
        }

        private class ErrorResults
        {
            public string Field { get; set; }

            public List<string> Errors { get; set; } = new List<string>();
        }
    }
}
