using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.WebApi.Utils;
using Microsoft.AspNetCore.Http;

namespace Inlog.Desafio.Backend.Domain.Excecao
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,ErrorContext errorContext)
        {
            try
            {
                await _next(context);
            }
            catch (DesafioExcecao ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
        
                var response = new { mensagem = ex.Message };
                errorContext.MensagemErro  =  ex.Message ;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
        
                var response = new { mensagem = "Erro interno do servidor", detalhe = ex.Message };
                errorContext.MensagemErro  =  ex.Message ;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
   }
}