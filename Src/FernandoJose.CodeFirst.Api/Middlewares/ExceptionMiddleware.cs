using FernandoJose.CodeFirst.Application.Share.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace FernandoJose.CodeFirst.Api.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Tratar o response
                        ResponseViewModel response = new ResponseViewModel(false, new List<string>
                        {
                            { $"Server Error - {contextFeature.Error.Message}" }
                        });

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response)).ConfigureAwait(true);
                    }
                });
            });
        }
    }
}
