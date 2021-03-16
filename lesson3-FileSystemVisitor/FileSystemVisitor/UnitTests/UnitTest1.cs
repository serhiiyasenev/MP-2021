using FileSystemVisitorProj;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        private DirectoryInfo _directory;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directory = Directory.CreateDirectory("TestDirectoryWithFilesAndFolders");
            for (var i = 0; i < 10; i++)
            {
                using var fs = File.Create(Path.Combine(_directory.FullName, $"{i}File.txt"));
                var info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
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

            var visit = new FileSystemVisitorProj.FileSystemVisitor(_directory.FullName);
            var actualCount = 0;

            foreach (var element in visit)
            {
                ++actualCount;
            }

            var expectCount = 9;
            Assert.AreEqual(expectCount, actualCount);
        }

        [Test]
        public void VerifyCountFilesWithNumber3Test()
        {
            FileSystemVisitorProj.FileSystemVisitor visit = new FileSystemVisitorProj.FileSystemVisitor(_directory.FullName);
            visit.FileFinded += fileFinded;
            int actualCount = 0;

            foreach (var element in visit)
                ++actualCount;

            int expectCount = 8;
            Assert.AreEqual(expectCount, actualCount);
        }

        [Test]
        public void VerifyCountTextFileTest()
        {
            FileSystemVisitorProj.FileSystemVisitor visit = new FileSystemVisitorProj.FileSystemVisitor(_directory.FullName, x => x.Extension == ".txt");
            int actualCount = 0;

            foreach (var element in visit)
                ++actualCount;

            int expectCount = 3;
            Assert.AreEqual(expectCount, actualCount);
        }

        [Test]
        public void VerifyCountFoldersWithNumber2Test()
        {
            FileSystemVisitorProj.FileSystemVisitor visit = new FileSystemVisitorProj.FileSystemVisitor(_directory.FullName);
            visit.DirectoryFinded += directoryFinded;
            int actualCount = 0;

            foreach (var v in visit)
            {
                ++actualCount;
            }

            int expectCount = 6;
            Assert.AreEqual(expectCount, actualCount);
        }

        void directoryFinded(object sender, IterationControlArgs e)
        {
            if (e.CurrentFile.Name.Contains("2"))
                e.Exclude = true;
        }

        void fileFinded(object sender, IterationControlArgs e)
        {
            if (e.CurrentFile.Name.Contains("3"))
                e.Exclude = true;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _directory.Delete(true);
        }
    }
}