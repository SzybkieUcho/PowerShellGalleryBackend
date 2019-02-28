using PowerShellGallery.Entities.DTO;
using PowerShellGallery.Entities.ViewModels;
using PowerShellGallery.Utilities.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerShellGallery.Utilities.Services
{
    public class GitLabService : IGitLabService
    {
        private const string GitLabApiBaseUrl = "https://gitlab.example.com/api/v4/";
        public const string GitLabRepoBaseUrl = "https://gitlab.example.net/mygroup/PowerShellGallery/blob/master/scripts";

        private readonly RestClient _client;

        public GitLabService()
        {
            _client = new RestClient(GitLabApiBaseUrl);
            //_client.AddDefaultHeader("Private-Token", "********************");
        }

        public object GetProjectDescriptionFromApi()
        {
            var request = new RestRequest($"/projects/35544", Method.GET);
            var response = _client.Get(request);

            return response.Content;
        }

        public object GetRepositoryFileFromApi(string filename)
        {
            var request = new RestRequest($"/projects/35544/repository/files/{filename}/raw?private_token=********************&ref=master", Method.GET);
            var response = _client.Get(request);

            return response.Content;
        }

        public string CreateNewFileFromApi(ScriptViewModel script)
        {
            var request = new RestRequest($"projects/35544/repository/files/scripts%2F{script.Name}%2Eps1", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-type", "application/json");

            request.AddBody(new GitLabFileDTO {
                branch = "master",
                content = script.Content,
                commit_message = "Create new script from powershell gallery"
            });

            var response = _client.Execute(request);
            return $"{GitLabRepoBaseUrl}/{script.Name}.ps1";
        }

        //public object GetTreeFromApi()
        //{
        //    var request = new RestRequest($"projects/35544/repository/tree", Method.GET);
        //    var response = _client.Get(request);

        //    return response.Content;
        //}
    }
}
