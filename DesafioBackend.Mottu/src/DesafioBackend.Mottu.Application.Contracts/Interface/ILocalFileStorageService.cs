using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackend.Mottu.Interface
{
    public interface ILocalFileStorageService
    {
        Task<string> SaveCnhImageAsync(byte[] content, string fileName);
    }
}