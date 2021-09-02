using Microsoft.AspNetCore.Builder;

namespace rrhh_api_restful.Middlewares.ApiWrapper.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiWrapperMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<ApiWrapperMiddleware>();
    }
}
