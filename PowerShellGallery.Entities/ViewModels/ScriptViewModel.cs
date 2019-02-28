using System;
using System.Collections.Generic;
using System.Text;

namespace PowerShellGallery.Entities.ViewModels
{
    public class ScriptViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
    }
}
