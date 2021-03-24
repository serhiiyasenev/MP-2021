using FileSystemVisitorProj;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        private DirectoryInfo _directory;

        private IFileSystemVisitor _fileSystemVisitor;

        [SetUp]
        public void OneTimeSetUp()
        {
            _directory = Directory.CreateDirectory("TestDirectoryWithFilesAndFolders");
            for (var i = 0; i < 10; i++)
            {
                if (i  % 2 == 0)
                {
                    using var fs = File.Create(Path.Combine(_directory.FullName, $"{i}File.txt"));
                }
                else
                {
                    using var fs = File.Create(Path.Combine(_directory.FullName, $"{i}File.pdf"));
                }
            }

            for (var i = 1; i <= 3; i++)
            {
                _directory.CreateSubdirectory($"{i}");
            }
            File.Create(Path.Combine(_directory.GetDirectories()[0].FullName, "Dir_File.txt")).Dispose();
        }
        
        [Test]
        public void VerifyObjCountTest()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName);
            var actualCount = 0;

            foreach (var element in _fileSystemVisitor)
            {
                ++actualCount;
            }

            var expectCount = _directory.GetFileSystemInfos("*", SearchOption.AllDirectories).Length;
            Assert.AreEqual(expectCount, actualCount);
        }


        [Test]
        public void VerifyCountTextFileTest()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName, x => x.Extension == ".txt");
            foreach (var element in _fileSystemVisitor)
            {
                Assert.True(element.Extension.Equals(".txt"));
            }
        }

        [Test]
        public void VerifyDirectoryFinded()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName);
            _fileSystemVisitor.DirectoryFinded += directoryFinded;
            int actualCount = 0;

            foreach (var item in _fileSystemVisitor.Take(1))
            {
                ++actualCount;
            }

        }

        [Test]
        public void VerifyFileFinded()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName);
            _fileSystemVisitor.FileFinded += fileFinded;
            int actualCount = 0;

            foreach (var item in _fileSystemVisitor.Take(1))
            {
                ++actualCount;
            }

        }

        void directoryFinded(object sender, IterationControlArgs e)
        {
           Assert.True(e.CurrentItem is DirectoryInfo);
        }

        void fileFinded(object sender, IterationControlArgs e)
        {
            Assert.True(e.CurrentItem is FileInfo);
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            _directory.Delete(true);
        }
    }
}