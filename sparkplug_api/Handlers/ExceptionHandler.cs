using Microsoft.AspNetCore.Diagnostics;
using SparkPlug.Models;
using SparkPlug.Models.Dtos.Response;

namespace SparkPlug.Api.Handlers
{
    public static class ExceptionHandler
    {
        public static void ConfigureException(this IApplicationBuilder app, IWebHostEnvironment hostEnvironment)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature exceptionHandleFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandleFeature != null)
                    {
                        var status = ResponseStatus.FATAL_ERROR;
                        switch (exceptionHandleFeature.Error)
                        {
                            //More Exceptions can be added as they are identified, those that arent identified will default to the 500 status code 
                            case InvalidDataException:
                            case InvalidOperationException:
                            case ArgumentException:
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                status = ResponseStatus.APP_ERROR;
                                break;
                         
                            default:
                                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                break;
                        }
                        var err = new ErrorResponse { Success = false, Status = status };
                        err.Message = hostEnvironment.EnvironmentName == "Production" ?
                         "We currently cannot complete this request process. Please retry or contact our support" : exceptionHandleFeature.Error.Message;
                        await context.Response.WriteAsync(err.ToString());
                                       
                        await context.Response.CompleteAsync();
                    }
                });
            });
        }
    }
}
