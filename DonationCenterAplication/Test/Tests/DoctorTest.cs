﻿using System;
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
            var doctorController = this.doctorControllerFactory();
            #region FillDate
            var tromb = new Trombocyte
            {
                ammount = 10,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "46.751727,23.594825"
            };
            var red = new RedBloodCell
            {
                ammount = 53,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "46.751727,23.594825",
                antigen="B",
                rh=false
            };
            var plasma = new Plasma
            {
                ammount = 23,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "46.751727,23.594825",
                antibody="B"
            };
            doctorController.service.AddToDatabase(tromb);
            doctorController.service.AddToDatabase(red);
            doctorController.service.AddToDatabase(plasma);
#endregion
            var result = doctorController.getBloodDonatedForPacient("TestDonatedFor", "46.751727,23.594825");
            Assert.AreEqual(result.Item1, 10);
            Assert.AreEqual(result.Item2, 23);
            Assert.AreEqual(result.Item3, 53);

            //DELETE NEW DATA
            doctorController.service.DeleteFromDatabase(tromb);
            doctorController.service.DeleteFromDatabase(red);
            doctorController.service.DeleteFromDatabase(plasma);
        }

        [TestMethod]
        public void Test_getRequiredBloodForPacient()
        {
            var doctorController = this.doctorControllerFactory();
            //doctorController.doctor = doctorController.service.GetOneFromDatabase<Doctor>(1);
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
