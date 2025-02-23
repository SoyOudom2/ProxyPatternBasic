namespace ImageDownloader.IServices
{
    public interface IImageDownloader
    {
        Task DownloadImagesAsync(string url, string userRole);
    }
}
