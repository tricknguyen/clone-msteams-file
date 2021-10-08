using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp_OpenIDConnect_DotNet.Data;
using WebApp_OpenIDConnect_DotNet.Models;
using WebApp_OpenIDConnect_DotNet.RepositoryAPI.IRepositoryAPI;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MSTeamsController : ControllerBase
    {
        private IMsTeamsRepoAPI _msRepo;
        private readonly ApplicationDbContext _db;
        public MSTeamsController(IMsTeamsRepoAPI msRepo, ApplicationDbContext db)
        {
            _msRepo = msRepo;
            _db = db;
        }

        [HttpGet]
          
        public IActionResult GetAllFile()
        {
            var objList = _msRepo.GetAllFiles();          
            return Ok(objList);
        }

        [HttpGet("{fileId:int}", Name = "GetFile")]
        public IActionResult GetFile(int fileId)
        {
            var obj = _msRepo.GetFile(fileId);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }


        //[HttpPost]
        //public IActionResult CreateFile([FromBody] Files file)
        //{
        //    if (file == null)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (_msRepo.FileExists(file.Name))
        //    {
        //        ModelState.AddModelError("", "File name Exists!");
        //        return StatusCode(404, ModelState);
        //    }

        //    if (!_msRepo.CreateFile(file))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when saving the record {file.Name}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return CreatedAtRoute("GetFile", new
        //    {
        //        fileId = file.Id
        //    }, file);
        //}
      
        [HttpPost]
        public IActionResult UploadFile(IList<IFormFile> files)
        {           
            var Name = Path.GetFileName(files[0].FileName);
            var Extension = Path.GetExtension(Name);
            var obj2 = new Files()
            {
                Name = Name,
                Type = Extension,
                Modified = DateTime.Now,
                Modify_By = User.Identity.Name
            };
            _db.SaveChanges();
            return Ok(obj2);
        }


        [HttpPut("{fileId:int}", Name = "UpdateFile")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateFile(int fileId, [FromBody] Files file)
        {
            if (file == null || fileId != file.Id)
            {
                return BadRequest(ModelState);
            }

            var obj = _msRepo.GetFile(fileId);
            obj.Id = file.Id;
            obj.Name = file.Name;
            obj.Modified = file.Modified;
            obj.Modify_By = file.Modify_By;

            _db.SaveChanges();

            return Ok(obj);
        }


        [HttpDelete("{fileId:int}", Name = "DeleteFile")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteFile(int fileId)
        {
            if (!_msRepo.FileExists(fileId))
            {
                return NotFound();
            }

            var fileObj = _msRepo.GetFile(fileId);

            if (!_msRepo.DeleteFile(fileObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {fileObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
