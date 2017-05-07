using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL.Data;
using System.Collections.Generic;

namespace DressingApplicationTest
{
    //<summary>This is class for test methods.</summary>
    [TestClass]
    public class HelperMethodTest
    {
        IHelper helper;
        Db db;

        [TestInitialize]
        public void TestSetUp()
        {
            helper = new Helper();
            db = new Db();
            db.Initialize();
        }

        [TestMethod]
        public void CheckInitialCommand()
        {
            bool result = helper.IsInitialCommand(new CommandDTO(1, "Put on footwear", "sandals", "boots", false, false));
            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void CheckLastCommand()
        {
            bool result = helper.isLastCommand(new CommandDTO(7, "Leave house", "leaving house", "leaving house", false, true));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckDoublePieceDress()
        {
            Dictionary<int, string> processedList = new Dictionary<int, string>() { { 8, "Removing PJs" }, { 6, "shorts" } };
            bool result = helper.IsDoublePiece(processedList, 6);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfAllItemsPutOn()
        {
            Dictionary<int, string> processedList = new Dictionary<int, string>() { { 8, "Removing PJs" }, { 6, "pants" }, { 3, "socks" }, { 4, "shirt" }, { 2, "hat" }, { 5, "jacket" } };
            bool result = helper.IsAllItemsPutOn(processedList, Enums.TemperatureType.COLD);
            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void CheckPrerequisitesIsFulfilled()
        {
            Dictionary<int, string> processedList = new Dictionary<int, string>() { { 8, "Removing PJs" }, { 6, "pants" }, { 3, "socks" } };
            bool result = helper.CheckPrerequisites(processedList, 2, db, Enums.TemperatureType.COLD);
            Assert.IsTrue(!result);
        }

        [TestMethod]
        public void CheckProcessCommands()
        {
            int[] commands = new int[] { 8, 6, 6 };
            Dictionary<int, string> expectedResult = new Dictionary<int, string>() { { 8, "Removing PJs" }, { 6, "shorts" }, { 0, "fail" } };
            Dictionary<int, string> actualResult = helper.ProcessCommands("HOT", commands);
            Assert.IsTrue(helper.DictionaryComparer(expectedResult,actualResult));
        }

        [TestMethod]
        public void CheckDressIsApplicable()
        {            
            bool result = helper.IsDressApplicable(db, 3,Enums.TemperatureType.HOT);
            Assert.IsTrue(!result);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            db = null;
            helper = null;
        }

    }
}
