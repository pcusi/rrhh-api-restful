using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rrhh_api_restful.Middlewares.ApiWrapper.Extensions;
using rrhh_api_restful.Middlewares.ApiWrapper.Wrappers;

namespace rrhh_api_restful.Middlewares.ApiWrapper
{
    public class ApiResponseValidationsErrorResult : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;
            var error = new ApiError("validations")
            {
                ErrorCode = 0,
                ValidationErrors = context.ModelState.ToParameterizedModelError(context.ActionDescriptor)
            };
            await new ObjectResult(error).ExecuteResultAsync(context);
        }
    }

}
