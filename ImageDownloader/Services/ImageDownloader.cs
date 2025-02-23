using System.Diagnostics;
using System.IO;
using System.Net.Http;
using ImageDownloader.Dtos;
using ImageDownloader.IServices;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace ImageDownloader.Services
{
    public class ImageDownloader : IImageDownloader
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly string _filePath;

        public ImageDownloader(HttpClient httpClient, IOptions<FilesPath> filePath,IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _filePath = filePath.Value.ImagesPath;
            _memoryCache = memoryCache;
        }
        public async Task DownloadImagesAsync(string url, string userRole)
        {
            //Caching Proxy
            if (!_memoryCache.TryGetValue(url, out string? filePath))
            {
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    throw new ArgumentException("The URL provided is not a valid absolute URL.", nameof(url));
                }
                //Remote Proxy
                var byteArray = await _httpClient.GetByteArrayAsync(url);

                filePath = Path.Combine(_filePath, Guid.NewGuid() + ".jpg");
                await File.WriteAllBytesAsync(filePath.ToString()!, byteArray);
                _memoryCache.Set(url, filePath, TimeSpan.FromMinutes(5));
            }
            if(filePath is not null)
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
