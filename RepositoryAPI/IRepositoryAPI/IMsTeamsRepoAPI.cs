using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_OpenIDConnect_DotNet.Models;

namespace WebApp_OpenIDConnect_DotNet.RepositoryAPI.IRepositoryAPI
{
    public interface IMsTeamsRepoAPI
    {
        ICollection<Files> GetAllFiles();
        Files GetFile(int fileId);
        bool FileExists(int id);
        bool FileExists(string name);
        bool CreateFile(Files file);
        bool UpdateFile(Files file);
        bool DeleteFile(Files file);
        bool Save();
    }
}
