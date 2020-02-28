using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ssb_notes_wf;

namespace Test_ssbNotes
{
    [TestClass]
    public class TestCharacter
    {
        #region attributes
        Character character;
        #endregion attributes

        [TestInitialize]
        public void Initialize()
        {
            character = new Character("Joker", "C:/ssb/joker/logo.png", "C:/sbb/joker/details.png", "C:/ssb/joker/informations.txt");
        }
        [TestMethod]
        public void TestNameCharacterSuccess()
        {
            string expected = "Joker";
            string actual = character.Name;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestLogoPathCharacterSuccess()
        {
            string expected = "C:/ssb/joker/logo.png";
            string actual = character.LogoPath;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFullPicturePathCharacterSuccess()
        {
            string expected = "C:/sbb/joker/details.png";
            string actual = character.PicturePath;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestInformationsPathCharacterSuccess()
        {
            string expected = "C:/ssb/joker/informations.txt";
            string actual = character.InformationsPath;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPathCharacterSuccess()
        {
            string expected = "C:/ssb/joker";
            string actual = character.Path;

            Assert.AreEqual(expected, actual);
        }
        [TestCleanup]
        public void Cleanup()
        {
            character = null;
        }
    }
}
