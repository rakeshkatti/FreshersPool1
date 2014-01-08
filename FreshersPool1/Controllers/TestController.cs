using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FreshersPool1.Controllers
{
    public class TestController : Controller
    {
        [TestClass]
        public class test1
        {
            [TestMethod]
            public void TestLoginView()
            {

                var controller = new HomeController();
                var result = controller.Index() as ViewResult;
                Assert.AreEqual("", result.ViewName);
            }
            [TestMethod]
            public void TestLoginView1()
            {

                var controller = new HomeController();
                var result = controller.About() as ViewResult;
                Assert.AreEqual("", result.ViewName);
            }

           
        }

    }
}
