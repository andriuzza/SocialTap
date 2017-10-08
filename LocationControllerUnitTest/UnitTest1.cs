using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using SocialType.Models;
using SocialType.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace LocationControllerUnitTest
{
    [TestFixture] /*tells Nunit that there are some test in this unit */
    [TestClass]
    public class LocationsControllerUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
         Mock<ILocationRepository> mock = new Mock<ILocationRepository>();
            mock.Setup(m=>m.Locations()).Returns(new Location[]
            {
              new Location {Id = 245, Name="Snekutis", Address="Vilniaus g.1"},
              new Location {Id = 245, Name="Snekutis1", Address="Vilniaus g.2"},
              new Location {Id = 245, Name="Snekutis2", Address="Vilniaus g.3"}
            }.AsQueryable());

            LocationsController ctrl = new LocationsController(mock.Object);
            var actual = (List<Location>)ctrl.ShowBars().Model;
        }
    }
}
