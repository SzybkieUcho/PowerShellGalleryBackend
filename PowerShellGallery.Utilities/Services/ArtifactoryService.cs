using PowerShellGallery.Utilities.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.IO;

namespace PowerShellGallery.Utilities.Services
{
    public class ArtifactoryService : IArtifactoryService
    {
        private const string ArtifactoryApiBaseUrl = "http://localhost:8081/artifactory/api/";

        private readonly RestClient _client;

        public ArtifactoryService()
        {
            _client = new RestClient(ArtifactoryApiBaseUrl);
            _client.AddDefaultHeader("X-JFrog-Art-Api", "********************");
        }

        public object ListPackagesFromApi()
        {
            var request = new RestRequest($"storage/releases_nuget_packages", Method.GET);
            var response = _client.Get(request);

            return response.Content;
        }

        public object GetSinglePackageFromApi(string packagename)
        {
            var request = new RestRequest($"storage/releases_nuget_packages/{packagename}", Method.GET);
            var response = _client.Get(request);

            return response.Content;
        }

        public object DownloadSinglePackageFromApi(string packagename, string path)
        {
            string _path = path;

            var request = new RestRequest($"nuget/releases_nuget_packages/{packagename}", Method.GET);
            var response = _client.DownloadData(request);

            File.WriteAllBytes(Path.Combine(_path, packagename), response);

            return response;
            //return _client.DownloadData(request);
        }
    }
}
