using System.Diagnostics;
using ImageDownloader.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageDownloaderController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IImageDownloader _imageDownloader;

        public ImageDownloaderController(ILoggerService loggerService, IImageDownloader imageDownloader)
        {
            _loggerService = loggerService;
            _imageDownloader = imageDownloader;
        }

        [HttpGet]
        public async Task<IActionResult> DownloadImagesAsync(string url, string role = "Unknown User")
        {
            //Smart Proxy
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await _imageDownloader.DownloadImagesAsync(url, role);
            stopWatch.Stop();
            var message = $"The Image Has Been Downloaded! | Duration : {stopWatch.Elapsed.TotalSeconds:F2}s";
            _loggerService.LogInfoAsync(message);
            return Ok(message);
        }
    }
}
