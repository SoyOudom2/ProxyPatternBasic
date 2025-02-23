# 🎭 Proxy Pattern Implementation in C#

[![NuGet](https://img.shields.io/nuget/v/Microsoft.Extensions.Caching.Memory.svg?style=flat-square)](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory/)
[![.NET](https://img.shields.io/badge/.NET-7.0-blueviolet?style=flat-square)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](LICENSE)

A clean implementation of the Proxy Design Pattern demonstrating multiple proxy types for image/video download operations.

## 🌟 Features

- **Virtual Proxy**: Lazy initialization of expensive resources
- **Protection Proxy**: Role-based access control
- **Caching Proxy**: MemoryCache integration for performance
- **Remote Proxy**: HTTP communication handling
- **Composite Pattern**: Combine multiple proxy types
- **ASP.NET Core Integration**: Full DI container support

## 📦 NuGet Packages

```bash
Install-Package Microsoft.Extensions.Caching.Memory
Install-Package Microsoft.Extensions.Http
```
🛠️ Installation
1. Clone repository:
```bash
git clone https://github.com/SoyOudom2/ProxyPatternBasic.git
```
Configure paths in appsettings.json:
```Json
{
  "FilesPath": {
    "ImagesPath": "C:/Downloads/Images",
    "LogsPath": "C:/Downloads/logs.txt"
  }
}
```
![star-history-2025224](https://github.com/user-attachments/assets/08eac2d7-8a35-49df-acb8-3b52329aa45f)

