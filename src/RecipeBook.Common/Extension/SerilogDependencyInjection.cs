using Microsoft.AspNetCore.Builder;
using Serilog;

namespace RecipeBook.Common.Extension;

public static class SerilogDependencyInjection
{
    public static  WebApplicationBuilder UseSerilogInWebApp(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, config) =>
            config.ReadFrom.Configuration(context.Configuration));
        return builder;
    }
}