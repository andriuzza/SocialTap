using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using SocialType.Models;
using SocialType.Controllers;
using System.Linq;
using System.Collections.Generic;
using SocialType.Repositories;

namespace LocationControllerUnitTest
{
    [TestFixture] /*tells Nunit that there are some test in this unit */
    [TestClass]
    public class LocationsControllerUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IRepository<Location>> mock = new Mock<IRepository<Location>>();
            mock.Setup(m => m.GetAll()).Returns(new Location[]
            {
              new Location {Id = 245, Name="Snekutis", Address="Vilniaus g.1"},
              new Location {Id = 246, Name="Snekutis1", Address="Vilniaus g.2"},
              new Location {Id = 247, Name="Snekutis2", Address="Vilniaus g.3"}
            }.AsQueryable());

            LocationsController ctrl = new LocationsController(mock.Object);
            var actual = (List<Location>)ctrl.ShowBars().Model;
        }
        [TestMethod]
        public void TestMethod2()
        {
            Mock<IRepository<Location>> mock = new Mock<IRepository<Location>>();
            mock.Setup(m => m.GetAll()).Returns(new Location[]
            {
              new Location {Id = 245, Name="Snekutis", Address="Vilniaus g.1"},
              new Location {Id = 246, Name="Snekutis1", Address="Vilniaus g.2"},
              new Location {Id = 247, Name="Snekutis2", Address="Vilniaus g.3"}
            }.AsQueryable());

            LocationsController ctrl = new LocationsController(mock.Object);

            var actual = (List<Location>)ctrl.ShowBars().Model;

            var skaicius = actual.Where(m => m.Id == 245).SingleOrDefault();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(skaicius.Id, 246);
            /*Now TestMethod2 failed to pass a test, because
             * the true ID is 245(not 246) and I made it in purpose to
             see if a unit test working properly and can catch wrong data as well*/
        }
    }
}
