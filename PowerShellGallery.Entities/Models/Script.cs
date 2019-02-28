using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Nest;

namespace PowerShellGallery.Entities.Models
{
    public class Script
    {
        public string ScriptName { get; set; }

        public string ScriptDescription { get; set; }

        public string GitLabUrl { get; set; }

        public string[] ScriptTags { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateCreated { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastModified { get; set; }
    }
}
