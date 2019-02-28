using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerShellGallery.Utilities.Services;
using PowerShellGallery.Utilities.Services.Interfaces;

namespace PowerShellGallery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtifactoryController : ControllerBase
    {
        private IArtifactoryService _artifactoryService;

        public ArtifactoryController()
        {
            _artifactoryService = new ArtifactoryService();
        }

        [HttpGet]
        [Route("ListAllPackages")]
        public ActionResult<object> ListAllPackages()
        {
            var result = _artifactoryService.ListPackagesFromApi();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSinglePackage")]
        public ActionResult<object> GetSinglePackage(string packagename)
        {
            var result = _artifactoryService.GetSinglePackageFromApi(packagename);

            return Ok(result);
        }

        [HttpGet]
        [Route("DownloadPackage")]
        public ActionResult<object> DownloadPackage(string packagename, string path)
        {
            var result = _artifactoryService.DownloadSinglePackageFromApi(packagename, path);

            return Ok(result);
        }

    }
}