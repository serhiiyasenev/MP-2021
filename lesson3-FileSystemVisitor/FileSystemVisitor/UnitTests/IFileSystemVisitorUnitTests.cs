using FileSystemVisitorProj;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class IFileSystemVisitorUnitTests
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
        public void VerifyObjCountTestGetItems()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName);
            var actualCount = _fileSystemVisitor.GetItems().Count();

            var expectCount = _directory.GetFileSystemInfos("*", SearchOption.AllDirectories).Length;
            Assert.AreEqual(expectCount, actualCount);
        }


        [Test]
        [TestCase(".pdf")]
        [TestCase(".txt")]
        [TestCase("")]
        public void VerifyCountTextFileTest(string extension)
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName, x => x.Extension == extension);
            foreach (var element in _fileSystemVisitor)
            {
                Assert.True(element.Extension.Equals(extension));
            }
        }

        [Test]
        public void VerifyDirectoryFinded()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName);
            _fileSystemVisitor.DirectoryFinded += directoryFinded;
            int actualCount = 0;

            foreach (var item in _fileSystemVisitor)
            {
                ++actualCount;
            }

            Assert.True(actualCount > 0);

            void directoryFinded(object sender, IterationControlArgs e)
            {
                Assert.True(e.CurrentItem is DirectoryInfo);
            }

        }

        [Test]
        public void VerifyFileFinded()
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName);
            _fileSystemVisitor.FileFinded += fileFinded;
            int actualCount = 0;

            foreach (var item in _fileSystemVisitor)
            {
                ++actualCount;
            }

            Assert.True(actualCount > 0);

            void fileFinded(object sender, IterationControlArgs e)
            {
                Assert.True(e.CurrentItem is FileInfo);
            }
        }

        [Test]
        [TestCase("4File.txt")]
        [TestCase("9File.pdf")]
        public void VerifyFilteredFileFindedTest(string fileName)
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName, x => Filter(x, fileName));
            _fileSystemVisitor.FilteredFileFinded += filteredFileFinded;
            int actualCount = 0;

            foreach (var item in _fileSystemVisitor)
            {
                ++actualCount;
            }

            Assert.True(actualCount > 0);

            void filteredFileFinded(object sender, IterationControlArgs e)
            {
                Assert.True(Filter(e.CurrentItem, fileName));
                Assert.True(e.CurrentItem.Name.Equals(fileName));
            }
        }

        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public void VerifyFilteredDirectoryFindedTest(string dirName)
        {
            _fileSystemVisitor = new FileSystemVisitor(_directory.FullName, x => Filter(x, dirName));
            _fileSystemVisitor.FilteredDirectoryFinded += filteredDirectoryFinded;
            int actualCount = 0;

            foreach (var item in _fileSystemVisitor)
            {
                ++actualCount;
            }

            Assert.True(actualCount > 0);

            void filteredDirectoryFinded(object sender, IterationControlArgs e)
            {
                Assert.True(Filter(e.CurrentItem, dirName));
                Assert.True(e.CurrentItem.Name.Equals(dirName));
            }
        }

        bool Filter(FileSystemInfo x, string name)
        {
            return x.Name.Equals(name);
        }


        [TearDown]
        public void OneTimeTearDown()
        {
            _directory.Delete(true);
        }
    }
}