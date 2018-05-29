using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Test.TestService;
using Common.Model;

namespace Test.Tests
{
    [TestClass]
    public class DonorTest
    {

        public DonorController donorControllerFactory()
        { 
            TestRemotingService testService = new TestRemotingService();

            Random rng = new Random();
            var donorList = testService.GetAllFromDatabase<Donor>();
            Donor donor = donorList[rng.Next(donorList.Count - 1)];

            return new DonorController(testService, donor);
        }


        [TestMethod]
        public void Test_isDonorFit()
        {
            //TODO VLAD AJUTA-MA SA TE TREC 
        }

        [TestMethod]
        public void Test_getLastDonation()
        {
            //TODO VLAD AJUTA-MA SA TE TREC 
        }
    }
}
