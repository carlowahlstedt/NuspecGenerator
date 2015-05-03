using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuspecGenerator;

namespace NuspecGeneratorTest
{
    [TestClass]
    public class GeneratorTest
    {
        private PullCord _FileGenerator;

        [TestInitialize]
        public void Init()
        {
            _FileGenerator = new PullCord()
            {
                ID = "Test",
                VersionNumber = new Version(1, 0, 0, 0)
            };
        }

        [TestMethod]
        public void GenerateTest()
        {
            var output = _FileGenerator.Yank();

            Assert.AreNotEqual(string.Empty, output);
            Assert.IsNotNull(output);
        }
    }
}
