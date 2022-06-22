using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingLayer
{
    [TestClass]
    public class DriversLicenseTests
    {
        DriversLicenseContext ctx = DBContextManager.GetDriversLicenseContext();
        DriversLicense License;
        
        [TestInitialize]
        public void Setup()
        {
            try
            {
                ctx.Delete("customid");
                //tries to delete the test user if tests have been ran before
            }
            catch (Exception e) { }
            DriversLicense customitem = new DriversLicense("customid", "Gosho Goshov", "321321321442");
            ctx.Create(customitem);
            License = customitem;
        }
        [TestCleanup]
        public void Cleanup()
        {
            ctx.Delete("customid");
            ctx.Create(License);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(ctx.Read("customid"));
        }
        [TestMethod]
        public void ReadTest()
        {
            Assert.AreEqual("Gosho Goshov", ctx.Read("customid").FullName);
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(ctx.ReadAll());
        }
        [TestMethod]
        public void UpdateTest()
        {
            DriversLicense newcompany = new DriversLicense("customid", "Ivan Ivanov", "1234");
            ctx.Update(newcompany);
            Assert.AreEqual("Ivan Ivanov", ctx.Read("customid").FullName);
        }
        [TestMethod]
        public void DeleteTest()
        {
            ctx.Delete("customid");
            Assert.IsNull(ctx.Read("customid"));
            ctx.Create(License);
        }

    }
}
