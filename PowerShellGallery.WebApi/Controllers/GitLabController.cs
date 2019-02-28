using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerShellGallery.Entities.ViewModels;
using PowerShellGallery.Utilities.Services;

namespace PowerShellGallery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitLabController : ControllerBase
    {
        private GitLabService _gitLabService = new GitLabService();
        private ElasticsearchService _elasticsearchService = new ElasticsearchService();

        [HttpGet]
        [Route("GetProjectDescription")]
        public ActionResult<object> GetProjectDescription()
        {
            var result = _gitLabService.GetProjectDescriptionFromApi();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetFile")]
        public ActionResult<object> GetFile(string filename)
        {
            var result = _gitLabService.GetRepositoryFileFromApi(filename);

            return Ok(result);
        }

        [HttpPost]
        [Route("CreateFile")]
        public ActionResult<object> CreateFile(ScriptViewModel script)
        {
            var scriptUrl = _gitLabService.CreateNewFileFromApi(script);

            var result = _elasticsearchService.CreateNewDocumentFromApi(script, scriptUrl);

            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteFile")]
        public ActionResult<object> DeleteFile(string scriptId)
        {
            return Ok();
        }


        //[HttpGet]
        //[Route("GetTree")]
        //public ActionResult<object> GetTree()
        //{
        //    var result = _gitLabService.GetTreeFromApi();

        //    return Ok(result);
        //}
    }
}