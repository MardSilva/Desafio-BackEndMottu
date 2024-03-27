using DesafioBackend.Mottu.Interface;
using System.IO;
using System.Threading.Tasks;

public class LocalFileStorageService : ILocalFileStorageService
{
    private readonly string _basePath = @"C:\wwwroot\uploads";

    public LocalFileStorageService()
    {
        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }
    }

    public async Task<string> SaveCnhImageAsync(byte[] content, string fileName)
    {
        var filePath = Path.Combine(_basePath, fileName);
        await File.WriteAllBytesAsync(filePath, content);
        return filePath;
    }
}