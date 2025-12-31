using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace gLiter.Infrastructure.Services;

public class FileStorageService
{
    private readonly string _galleryPath;

    public FileStorageService(IWebHostEnvironment env)
    {
        var root = string.IsNullOrWhiteSpace(env.WebRootPath)
            ? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
            : env.WebRootPath;

        _galleryPath = Path.Combine(root, "images", "gallery");
        Directory.CreateDirectory(_galleryPath);
    }

    public async Task<string> SaveGalleryImageAsync(Stream fileStream, string fileName)
    {
        var safeFileName = Path.GetFileName(fileName);
        var filePath = Path.Combine(_galleryPath, safeFileName);

        await using var file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        await fileStream.CopyToAsync(file);

        return $"/images/gallery/{safeFileName}";
    }
}
