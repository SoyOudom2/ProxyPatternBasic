using ImageDownloader.Dtos;
using ImageDownloader.IServices;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Options;

namespace ImageDownloader.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly string _logPath;

        public LoggerService(IOptions<FilesPath> filesPath)
        {
            _logPath = filesPath.Value.LogsPath;
        }

        public async void LogErrorAsync(string message, string stackTrace = "")
        {
            await File.AppendAllTextAsync(_logPath,$"\n[{DateTime.Now.ToString("yyyy - MM - dd HH:mm:ss")}] - [ERROR] : {message} | {stackTrace}");
        }

        public async void LogWarningAsync(string message)
        {
            await File.AppendAllTextAsync(_logPath, $"\n[{DateTime.Now.ToString("yyyy - MM - dd HH:mm:ss")}] - [WARNING] : {message}");
        }

        public async void LogInfoAsync(string message)
        {
            await File.AppendAllTextAsync(_logPath, $"\n[{DateTime.Now.ToString("yyyy - MM - dd HH:mm:ss")}] - [INFO] : {message}");
        }
    }
}
