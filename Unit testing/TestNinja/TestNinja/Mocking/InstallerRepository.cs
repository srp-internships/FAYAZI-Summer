using System.Net;

namespace TestNinja.Mocking
{
    public interface IInstallerRepository
    {
        void FileDownloader(string url, string destination);
    }

    public class InstallerRepository : IInstallerRepository
    {
        public void FileDownloader(string url, string destination)
        {
            var client = new WebClient();
            client.DownloadFile(url, destination);

        }
    }
}
