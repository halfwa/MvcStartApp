using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using MvcStartApp.Models.Db.Repositories;
using Microsoft.AspNetCore.Http.Extensions;
using MvcStartApp.Models;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository repo)
        {
            LogConsole(context);
            await LogFile(context);
            await LogDb(context, repo);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }

        private void LogConsole(HttpContext context)
        {
            // Для логирования данных о запросе используем свойства объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private async Task LogFile(HttpContext context)
        {
            // Строка для публикации в лог
            string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}" +
            $"{Environment.NewLine}";

            // Путь до логов
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            await File.AppendAllTextAsync(logFilePath, logMessage);
        }

        private async Task LogDb(HttpContext context, IRequestRepository repo) 
        {
            var newRequest = new Request()
            {
                Url = context.Request.GetDisplayUrl()
            }; 
            await repo.AddRequestAsync(newRequest);
        }
    }
}
