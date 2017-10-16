using NUnit.Framework;
using Moq;
using SocialType.Models;
using SocialType.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Routing;
using SocialType.Services;
using System.Web.Mvc;

namespace LocationControllerUnitTest

{
   
    [TestClass]
    public class LocationControllerUnitTest
    {
        [Test]
        [TestMethod]
        public void testLoginViewWhenUserNotLoggedIn()
        {


            var session = new Mock<HttpSessionStateBase>();
            session.Setup(ses => ses["UserID"]).Returns(null);
            HttpContextManager.SetCurrentContext(GetMockedHttpContext(session));

            var userAccountController = new UserAccountController();
            var result = userAccountController.Login() as ViewResult;
            NUnit.Framework.Assert.AreEqual("Login", result.ViewName);

        }


        [TestMethod]
        public void testLoginViewWhenUserLoggedIn()
        {
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(ses => ses["UserID"]).Returns("1");
            HttpContextManager.SetCurrentContext(GetMockedHttpContext(session));

            var userAccountController = new UserAccountController();
            var result = userAccountController.Login() as ViewResult;
            NUnit.Framework.Assert.AreEqual("LoggedIn", result.ViewName);
        }

        [TestMethod]
        public void testLoginHttpPost()
        {
            UserAccount acc = new UserAccount();
            acc.UserID = 1;
            acc.Username = "testUser";
            acc.Password = "admin";

            var session = new Mock<HttpSessionStateBase>();
            HttpContextManager.SetCurrentContext(GetMockedHttpContext(session));

            UserAccountController userAccountController = new UserAccountController();

            var result = userAccountController.Login(acc) as ViewResult;

            
            NUnit.Framework.Assert.AreEqual("LoggedIn", result.ViewName);




        }

        [TestMethod]
        public void testLogOutWhenUserIsLoggedIn()
        {
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(ses => ses["UserID"]).Returns("1");
            HttpContextManager.SetCurrentContext(GetMockedHttpContext(session));

            UserAccountController accountController = new UserAccountController();
            var result = accountController.LogOut() as ViewResult;
            NUnit.Framework.Assert.AreEqual("LogOut", result.ViewName);
            
        }

        [TestMethod]
        public void testLogOutWhenUserIsNotLoggedIn()
        {
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(ses => ses["UserID"]).Returns(null);
            HttpContextManager.SetCurrentContext(GetMockedHttpContext(session));

            UserAccountController accountController = new UserAccountController();
            var result = accountController.LogOut() as ViewResult;
            NUnit.Framework.Assert.AreEqual("NotLoggedIn", result.ViewName);
        }

        private HttpContextBase GetMockedHttpContext(Mock<HttpSessionStateBase> session)
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();

            var server = new Mock<HttpServerUtilityBase>();
            var user = new Mock<UserAccount>();
            var routes = new RouteCollection();
            var requestContext = new Mock<RequestContext>();

            requestContext.Setup(x => x.HttpContext).Returns(context.Object);

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);
            context.Setup(ctx => ctx.Server).Returns(server.Object);
            request.Setup(req => req.RequestContext).Returns(requestContext.Object);


            return context.Object;
        }


}


    
}
