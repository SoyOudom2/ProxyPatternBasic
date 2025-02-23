using ImageDownloader.Dtos;
using ImageDownloader.IServices;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ImageDownloader.Services
{
    public class ImageDownloaderProxy : IImageDownloader
    {
        private readonly HttpClient _client;
        private readonly IMemoryCache _memoryCache;
        private readonly IOptions<FilesPath> _filesPath;

        //Real Object
        private IImageDownloader? _imageDownloader;
        public ImageDownloaderProxy(HttpClient client,IMemoryCache memoryCache,IOptions<FilesPath> filesPath)
        {
            _client = client;
            _memoryCache = memoryCache;
            _filesPath = filesPath;
        }

        public Task DownloadImagesAsync(string url, string userRole)
        {
            //Protection Proxy
            if (userRole != "Admin" && userRole != "User")
            {
                throw new UnauthorizedAccessException("You do not have permission to download images.");
            }

            //Virtual Proxy
            _imageDownloader ??= new ImageDownloader(_client, _filesPath, _memoryCache);

            return _imageDownloader.DownloadImagesAsync(url,userRole);
        }
    }
}
