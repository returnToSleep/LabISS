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
            Doctor doctor = doctorList[rng.Next(doctorList.Count)];

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
            //TODO Ladi

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
