using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.TestService;
using Client.Controller;
using Common.Model;

namespace Test.Tests
{
    [TestClass]
    public class DonationCenterTest
    {
        public DonationCenterController donationCenterControllerFactory()
        {
            TestRemotingService testService = new TestRemotingService();

            Random rng = new Random();
            var donationCenterList = testService.GetAllFromDatabase<DonationCenter>();
            DonationCenter donationCenter = donationCenterList[rng.Next(donationCenterList.Count)];

            return new DonationCenterController(testService, donationCenter);
        }

        [TestMethod]
        public void Test_getNearestDonor()
        {
            //TODO Emu
        }

        [TestMethod]
        public void Test_sortRequest()
        {
            //TODO Emu 
        }

        [TestMethod]
        public void Test_getAvailableBloodGreedy()
        {
            //TODO Lecu
        }

        [TestMethod]
        public void Test_getAvailableBloodForRequest()
        {
            //TODO Lecu
        }

        [TestMethod]
        public void Test_updateAmmounts()
        {
            //TODO Radu
        }

        [TestMethod]
        public void Test_sendBlood()
        {
            //TODO Radu 
        }

    }
}
