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
    public class KATTEsts
    {
        KATContext ctx = DBContextManager.GetKATContext();
        KAT kat;

        [TestInitialize]
        public void Setup()
        {
            try
            {
                ctx.Delete(666999);
                //tries to delete the test user if tests have been ran before
            }
            catch (Exception e) { }
            KAT customitem = new KAT(666999, "Plovdiv");
            ctx.Create(customitem);
            kat = customitem;
        }
        [TestCleanup]
        public void Cleanup()
        {
            ctx.Delete(666999);
            ctx.Create(kat);
        }
        [TestMethod]
        public void CreateTest()
        {
            Assert.IsNotNull(ctx.Read(666999));
        }
        [TestMethod]
        public void ReadTest()
        {
            Assert.AreEqual("Plovdiv", ctx.Read(666999).City);
        }
        [TestMethod]
        public void ReadAllTest()
        {
            Assert.IsNotNull(ctx.ReadAll());
        }
        [TestMethod]
        public void UpdateTest()
        {
            KAT newgame = new KAT(666999, "Sofia");
            ctx.Update(newgame);
            Assert.AreEqual("Sofia", ctx.Read(666999).City);
        }
        [TestMethod]
        public void DeleteTest()
        {
            ctx.Delete(666999);
            Assert.IsNull(ctx.Read(666999));
            ctx.Create(kat);
        }

    }
}
