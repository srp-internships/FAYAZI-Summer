using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IInstallerRepository _insRepo;

        public InstallerHelper(IInstallerRepository installerRepository)
        {
            _insRepo = installerRepository; 
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _insRepo.FileDownloader(string.Format("http://example.com/{0}/{1}", customerName, installerName), _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}