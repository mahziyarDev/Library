using Microsoft.AspNetCore.Builder;

namespace Library.Common.Configurations;

public static class ApplicationBuilderException
{
    public static IApplicationBuilder GlobalException(this IApplicationBuilder applicationBuilder) =>
        applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();
}