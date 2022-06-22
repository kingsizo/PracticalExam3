using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using DataLayer;
using ServiceLayer;
using System;

namespace TestingLayer
{
    [TestClass]
    public class LicensePlateTests
    {
        LicensePlateContext ctx = DBContextManager.GetLicensePlateContext();
        LicensePlate lp;
        
        [TestInitialize]
        public void Setup()
        {
            try
            {
                ctx.Delete("customid");
                //tries to delete the test user if tests have been ran before
            }
            catch (Exception e) { }
            LicensePlate customitem = new LicensePlate("customid", "Normal", "10.10.2021");
            ctx.Create(customitem);
            lp = customitem;
        }
        [TestCleanup]
        public void Cleanup()
        {
            ctx.Delete("customid");
            ctx.Create(lp);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(ctx.Read("customid"));
        }
        [TestMethod]
        public void ReadTest()
        {
            Assert.AreEqual("Normal", ctx.Read("customid").PlateType);
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(ctx.ReadAll());
        }
        [TestMethod]
        public void UpdateTest()
        {
            LicensePlate newperson = new LicensePlate("customid", "Diplomatic", "11.11.2011");
            ctx.Update(newperson);
            Assert.AreEqual("Diplomatic", ctx.Read("customid").PlateType);
        }
        [TestMethod]
        public void DeleteTest()
        {
            ctx.Delete("customid");
            Assert.IsNull(ctx.Read("customid"));
            ctx.Create(lp);
        }

    }
}