using GeradorClasse.Programa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for UtilTest and is intended
    ///to contain all UtilTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FormatPascalCase
        ///</summary>
        [TestMethod()]
        public void FormatPascalCaseTest()
        {
            string texto = "usuario_grupo"; // TODO: Initialize to an appropriate value
            string expected = "UsuarioGrupo"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Util.FormatPascalCase(texto);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void FormatPascalCaseTest2()
        {
            string texto = "usuario"; // TODO: Initialize to an appropriate value
            string expected = "Usuario"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Util.FormatPascalCase(texto);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void FormatPascalCaseTest4()
        {
            string texto = "u"; // TODO: Initialize to an appropriate value
            string expected = "U"; // TODO: Initialize to an appropriate value
            string actual;
            actual = Util.FormatPascalCase(texto);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void FormatPascalCaseTest3()
        {
            string texto = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = Util.FormatPascalCase(texto);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for WriterFile
        ///</summary>
        [TestMethod()]
        public void WriterFileTest()
        {
            string arquivo = "C:/calculomedia.txt"; // TODO: Initialize to an appropriate value
            string texto = "TESTE"; // TODO: Initialize to an appropriate value
            Util.WriterFile(arquivo, texto);
        }

        /// <summary>
        ///A test for WriterFile
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void WriterFileCaminhoVazioTest()
        {
            string arquivo = string.Empty; // TODO: Initialize to an appropriate value
            string texto = string.Empty; // TODO: Initialize to an appropriate value
            Util.WriterFile(arquivo, texto);
        }
        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void WriterFileCaminhoInvalidoTest()
        {
            string arquivo = "Ç^D~d~d~das[d´paáááád´d´"; // TODO: Initialize to an appropriate value
            string texto = string.Empty; // TODO: Initialize to an appropriate value
            Util.WriterFile(arquivo, texto);
        }
        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void WriterFileCaminhoInexistenteTest()
        {
            string arquivo = "C:/caminhoInexistente/teste.txt"; // TODO: Initialize to an appropriate value
            string texto = string.Empty; // TODO: Initialize to an appropriate value
            Util.WriterFile(arquivo, texto);
        }
    }
}
