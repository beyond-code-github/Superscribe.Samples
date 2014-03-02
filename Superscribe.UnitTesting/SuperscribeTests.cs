namespace Superscribe.UnitTesting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Superscribe.Engine;
    using Superscribe.Models;

    [TestClass]
    public class SuperscribeUnitTests
    {
        private IRouteEngine define;
            
        [TestInitialize]
        public void Setup()
        {
            define = RouteEngineFactory.Create();

            define.Route("Hello/World", o => "Hello World!");
            define.Route("Hello" / (String)"Name", o => "Hello " + o.Parameters.Name);
        }
        
        [TestMethod]
        public void Test_Hello_World_Get()
        {
            var routeWalker = define.Walker();
            var data = routeWalker.WalkRoute("/Hello/World", "Get", new RouteData());

            Assert.AreEqual("Hello World!", data.Response);
        }

        [TestMethod]
        public void Test_Hello_Name_Get()
        {
            var routeWalker = define.Walker();
            var data = routeWalker.WalkRoute("/Hello/Kathryn", "Get", new RouteData());

            Assert.AreEqual("Kathryn", data.Parameters.Name);
            Assert.AreEqual("Hello Kathryn", data.Response);
        }
    }
}
