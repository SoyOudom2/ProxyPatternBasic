using ImageDownloader.Dtos;
using ImageDownloader.IServices;
using ImageDownloader.Middlewares;
using ImageDownloader.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();

#region 'Registeration'

builder.Services.Configure<FilesPath>(builder.Configuration.GetSection("FilesPath"));
builder.Services.AddTransient<IImageDownloader, ImageDownloaderProxy>(); 
builder.Services.AddTransient<ImageDownloader.Services.ImageDownloader>();

builder.Services.AddSingleton<ILoggerService,LoggerService>();

#endregion

var app = builder.Build();

app.UseMiddleware<ErrorExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
