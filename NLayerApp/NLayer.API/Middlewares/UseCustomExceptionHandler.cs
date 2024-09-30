using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler //Extension method static class
    {
        public static void UseCustomException(this IApplicationBuilder app)  //MiddleWare yazanda IApplicationBulderden geliyi ucun ondan aliriq .
        {
            app.UseExceptionHandler(config => //Frameworkun verdiyi middlewaredir . App'da herhansisa yerinde exc. olsa geriye model donur .
            {
                config.Run(async context => //Sonlandirici middlewaredir . Eger Exc olsa bir basa evvele atib . Exc verecek . 
                {
                    context.Response.ContentType= "application/json"; //Type vermeliyik evvelceden .
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>(); //Firladilan exc. aliriq .
                    var statusCode = exceptionFeature.Error switch // Exc. hardan geldiyini belirlemek ucundur .
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message); //bu bir tipdir geriye dondermeliyik .

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response)); //Serlize edirik Json'a .
                });
            });
        }
    }
}
