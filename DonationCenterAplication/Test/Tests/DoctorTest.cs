using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using Repository;
using Test.TestService;
using Controller;
using Common.Model;
using Client.Controller;

namespace Test
{
    [TestClass]
    public class DoctorTest
    {

        public DoctorController doctorControllerFactory()
        {
            TestRemotingService testService = new TestRemotingService();

            Random rng = new Random();
            var doctorList = testService.GetAllFromDatabase<Doctor>();
            Doctor doctor = doctorList[rng.Next(doctorList.Count - 1)];

            return new DoctorController(testService, doctor);
        }



        [TestMethod]
        public void Test_getBloodDonatedForPacient()
        {

            //TODO Ladi
        }

        [TestMethod]
        public void Test_getRequiredBloodForPacient()
        {
            var doctorController = this.doctorControllerFactory();
            doctorController.doctor = doctorController.service.GetOneFromDatabase<Doctor>(1);
            #region FillData
            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 46.766539,
                    longitude = 23.62596
                },
                1,
                "TestPacient",
                "TestPacient",
                "Plasma,B,12",
                "Centrul Save-A-Life"
                );

            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 46.766539,
                    longitude = 23.62596
                },
                1,
                "TestPacient",
                "TestPacient",
                "Plasma,B,12",
                "Centrul Save-A-Life"
                );
            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 46.766539,
                    longitude = 23.62596
                },
                1,
                "TestPacient",
                "TestPacient",
                "Red,AB,1,11.5",
                "Centrul Save-A-Life"
                );
            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 46.766539,
                    longitude = 23.62596
                },
                1,
                "TestPacient",
                "TestPacient",
                "Red,AB,1,11.5",
                "Centrul Save-A-Life"
                );
            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 46.766539,
                    longitude = 23.62596
                },
                1,
                "TestPacient",
                "TestPacient",
                "Tromb,30",
                "Centrul Save-A-Life"
                );
            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 46.766539,
                    longitude = 23.62596
                },
                1,
                "TestPacient",
                "TestPacient",
                "Tromb,11.5",
                "Centrul Save-A-Life"
                );
            #endregion
            var result = doctorController.getRequiredBloodForPacient("TestPacient");
            Assert.AreEqual(result.Item1, 41.5);
            Assert.AreEqual(result.Item2, 24);
            Assert.AreEqual(result.Item3, 23);
            doctorController.deleteRequest("TestPacient");//delete the test request
        }

        [TestMethod]
        public void Test_makeRequest()
        {
            //TODO Andi
        }

        [TestMethod]
        public void Test_reviewBloodStocks()
        {
            //TODO Andi
        }

        [TestMethod]
        public void Test_matchBloodWithRequest()
        {
            //TODO Biju
        }

        [TestMethod]
        public void Test_acceptBlood()
        {
            //TODO Biju
        }



    }
}
