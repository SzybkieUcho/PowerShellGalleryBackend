using System;
using System.Collections.Generic;
using System.Text;

namespace PowerShellGallery.Entities.DTO
{
    public class GitLabFileDTO
    {
        public string branch { get; set; }
        public string content { get; set; }
        public string commit_message { get; set; }
    }
}
