using System;
using System.Collections.Generic;
using System.Text;

namespace PowerShellGallery.Utilities.Services.Interfaces
{
    public interface IArtifactoryService
    {
        object GetSinglePackageFromApi(string packagename);
        object ListPackagesFromApi();
        object DownloadSinglePackageFromApi(string packagename, string path);
    }
}
