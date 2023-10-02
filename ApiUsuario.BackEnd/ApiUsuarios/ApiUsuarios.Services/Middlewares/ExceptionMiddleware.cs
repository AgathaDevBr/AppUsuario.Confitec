using ApiUsuarios.Services.Middlewares.Exceptions;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Newtonsoft.Json;
using Salesforce.Common.Models.Json;
using System.Net;

namespace ApiUsuarios.Services.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate? _requestDelegate;

        public ExceptionMiddleware(RequestDelegate? requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (EmailJaCadastradoException e)
            {
                await HandleException(context, e);
            }
            catch (UsuarioNaoEncontradoException e)
            {
                await HandleException(context, e);
            }
            catch (IdadeException e)
            {
                await HandleException(context, e);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private async Task HandleException(HttpContext context, Exception e)
        {
            switch (e)
            {
                case EmailJaCadastradoException:
                    //HTTP 400 BAD REQUEST
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case UsuarioNaoEncontradoException:
                    //HTTP 404 NOT FOUND
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case IdadeException:
                    //HTTP 404 NOT FOUND
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
            }
            //retornando o conteúdo do erro..
            context.Response.ContentType = "application/json";

            var result = new ErrorResult
            {
                StatusCode = context.Response.StatusCode,
                Message = e.Message,
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Modelo de dados para retornar o conteudo dos erros
        /// </summary>
        public class ErrorResult
        {
            public int StatusCode { get; set; }
            public string? Message { get; set; }
        }


    }
}
