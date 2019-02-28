using PowerShellGallery.Entities.Models;
using PowerShellGallery.Entities.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerShellGallery.Utilities.Services
{
    public class ElasticsearchService
    {
        private const string ElasticsearchApiBaseUrl = "localhost:9200";

        private readonly RestClient _client;

        public ElasticsearchService()
        {
            _client = new RestClient(ElasticsearchApiBaseUrl);
        }

        public object GetAllDocumentsFromApi()
        {
            var request = new RestRequest($"/_search/", Method.GET);
            var response = _client.Get(request);

            return response.Content;
        }

        public object CreateNewDocumentFromApi(ScriptViewModel script, string scriptUrl)
        {
            var request = new RestRequest($"/script/_doc/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-type", "application/json");

            request.AddBody(new Script {
                ScriptName = script.Name,
                ScriptDescription = script.Description,
                ScriptTags = script.Tags,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                GitLabUrl = scriptUrl
            });

            var response = _client.Execute(request);
            return response.Content;
        }

        public object DeleteDocumentFromApi(string scriptId)
        {
            var request = new RestRequest($"/script/_doc/{scriptId}", Method.DELETE);
            var response = _client.Execute(request);

            return response.Content;
        }
    }
}
