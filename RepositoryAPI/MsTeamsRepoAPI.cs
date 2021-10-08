using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_OpenIDConnect_DotNet.Data;
using WebApp_OpenIDConnect_DotNet.Models;
using WebApp_OpenIDConnect_DotNet.RepositoryAPI.IRepositoryAPI;

namespace WebApp_OpenIDConnect_DotNet.RepositoryAPI
{
    public class MsTeamsRepoAPI : IMsTeamsRepoAPI
    {
        private readonly ApplicationDbContext _db;
        public MsTeamsRepoAPI(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateFile(Files file)
        {
            _db.Files.Add(file);
            return Save();
        }

        public bool DeleteFile(Files file)
        {
            _db.Files.Remove(file);
            return Save();
        }

        public bool FileExists(int id)
        {
            return _db.Files.Any(u => u.Id == id);
        }

        public bool FileExists(string name)
        {
            bool value = _db.Files.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public ICollection<Files> GetAllFiles()
        {
            return _db.Files.OrderBy(u => u.Name).ToList();
        }

        public Files GetFile(int fileId)
        {
            return _db.Files.FirstOrDefault(u => u.Id == fileId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateFile(Files file)
        {
            _db.Files.Update(file);
            return Save();
        }
    }
}
