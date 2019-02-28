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
    public class ElasticsearchController : ControllerBase
    {
        private ElasticsearchService _elasticSearchService = new ElasticsearchService();
        private GitLabService _gitLabService = new GitLabService();

        [HttpGet]
        [Route("GetAllDocuments")]
        public ActionResult<object> GetAllDocuments()
        {
            var request = _elasticSearchService.GetAllDocumentsFromApi();
            return Ok(request);
        }

        [HttpDelete]
        [Route("DeleteDocument")]
        public ActionResult<object> DeleteDocument(string scriptId)
        {
            var request = _elasticSearchService.DeleteDocumentFromApi(scriptId);

            return Ok(request);
        }

        //[HttpPost]
        //[Route("CreateNewDocument")]
        //public ActionResult CreateNewDocument(ScriptViewModel script)
        //{
        //    var request = _elasticSearchService.CreateNewDocumentFromApi(script);

        //    return Ok(request);
        //}
    }
}