namespace ImageDownloader.IServices
{
    public interface ILoggerService
    {
        void LogErrorAsync(string message, string stackTrace = "");
        void LogWarningAsync(string message);
        void LogInfoAsync(string message);
    }
}
