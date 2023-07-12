using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IInstallerRepository> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void Setup()
        {
            _fileDownloader = new Mock<IInstallerRepository>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadFile_DownloadFails_ThrowsWebException()
        {
            _fileDownloader.Setup(f => 
                f.FileDownloader(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("hello", "world");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadFile_DownloadComletes_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("hello", "world");

            Assert.That(result, Is.True);
        }

    }
}
