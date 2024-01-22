using Microsoft.Extensions.Logging;
using System.Text;

namespace Homework.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string requestBody;
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                requestBody = await reader.ReadToEndAsync();
            }
            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));


            // 處理：將登入資訊寫入 log 檔案
            if (context.Response.StatusCode == 200)
            {
                string logMessage = $"{requestBody} at {DateTime.Now}";
                _logger.LogInformation(logMessage);

                // 寫入 log 檔案
                string logFileName = $"debug-{DateTime.Now:yyyy-MM-dd}.txt";
                string logFolder = Path.Combine(Directory.GetCurrentDirectory(), "log");
                if (!Path.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }

                string logFilePath = Path.Combine(logFolder, logFileName);
                await File.AppendAllTextAsync(logFilePath, logMessage + Environment.NewLine, Encoding.UTF8);
            }
            
            await _next(context);
        }
    }
}
