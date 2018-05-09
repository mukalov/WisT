using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WisT.DemoWeb.FilePersistence;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.Tests
{
    [TestClass]
    public class LabelFileStorageTests
    {      
        [TestMethod]
        public void AddGetTest1()
        {
            ILabelStorage testStorager = new LabelStorage();
            Label input = new Label("pavlo", new Identifier(34));
            testStorager.Add(input);
            Label output = (Label)testStorager.Get(new Identifier(34));
            Assert.AreEqual(input.Name, output.Name);
        }

        [TestMethod]
        public void AddGetTest2()
        {
            ILabelStorage testStorager = new LabelStorage();
            Label input = new Label("avlo", new Identifier(34));
            testStorager.Add(input);
            Label output = (Label)testStorager.Get(new Identifier(34));
            Assert.AreEqual(input.Name, output.Name);
        }

        [TestMethod]
        public void AddGetTest3()
        {
            ILabelStorage testStorager = new LabelStorage();
            Label input = new Label("vasia", new Identifier(43234));
            testStorager.Add(input);
            Label output = (Label)testStorager.Get(new Identifier(43234));
            Assert.AreEqual(input.Name, output.Name);
        }

        [TestMethod]
        public void AddGetTest4()
        {
            ILabelStorage testStorager = new LabelStorage();
            Label input = new Label("tytom", new Identifier(12334));
            testStorager.Add(input);
            Label output = (Label)testStorager.Get(new Identifier(43234));
            Assert.AreNotEqual(input.Name, output.Name);
        }

        [TestMethod]
        public void AddGetTest5()
        {
            ILabelStorage testStorager = new LabelStorage();
            Label input = new Label("ivan", new Identifier(341));
            testStorager.Add(input);
            Label output = (Label)testStorager.Get(new Identifier(341));
            Assert.AreEqual(input.Name, output.Name);
        }
    }
}
