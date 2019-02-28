using PowerShellGallery.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerShellGallery.Utilities.Services.Interfaces
{
    public interface IGitLabService
    {
        object GetProjectDescriptionFromApi();
        object GetRepositoryFileFromApi(string filename);
        string CreateNewFileFromApi(ScriptViewModel script);
    }
}
