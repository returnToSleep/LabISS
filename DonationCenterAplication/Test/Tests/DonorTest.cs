using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller;
using Test.TestService;
using Common.Model;
using System.Collections.Generic;

namespace Test.Tests
{
    [TestClass]
    public class DonorTest
    {

        public DonorController donorControllerFactory()
        {
            TestRemotingService testService = new TestRemotingService();

            Donor donor = new Donor("1971210016651", "Donor101", new DateTime(1997, 12, 10), "Acasa", new Location("Cluj-Napoca, Calea Manastur nr. 5", 46.762467, 23.570993), "mail");

            try
            {
                testService.GetOneFromDatabase<Donor>("1971210016651");
            }catch (Exception)
            {
                testService.AddToDatabase(donor);
            }

            return new DonorController(testService, donor);
        }


        [TestMethod]
        public void Test_isDonorFit()
        {
            DonorController dc = donorControllerFactory();

            //Donor is in the pending list
            Assert.AreEqual(dc.isDonorFit(), "Medical results pending");

            dc.donor.isPending = false;

            //Donor is fit to donate
            Assert.AreEqual(dc.isDonorFit(), "Good to go!");

            Donation don = new Donation("test", 10f, 10, 10, new DateTime(2018, 06, 04), 10f, 10f, 10f);
            IList<Donation> donationList = new List<Donation>();
            donationList.Add(don);
            dc.donor.donationHistory=donationList;

            //Donor donated in the last 2 months -> not fit
            Assert.AreNotEqual("Good to go!", dc.isDonorFit());
            Assert.AreNotEqual("Medical results pending", dc.isDonorFit());
        }

        [TestMethod]
        public void Test_getLastDonation()
        {
            DonorController dc = donorControllerFactory();
            //test for null donation
            Assert.IsNull(dc.getDonationHistory());
            Assert.AreEqual(dc.donor.getLastDonation(), new DateTime(1,1,1));

            IList<Donation> donationList = new List<Donation>();
            donationList.Add(new Donation("test", 10f, 10, 10, new DateTime(2018, 06, 04), 10f, 10f, 10f));
            dc.donor.donationHistory = donationList;

            //testing for the latest donation
            Assert.AreEqual(dc.donor.getLastDonation(), new DateTime(2018, 06, 04));

            //adding older donations
            donationList.Add(new Donation("test", 10f, 10, 10, new DateTime(2017, 06, 04), 10f, 10f, 10f));
            donationList.Add(new Donation("test", 10f, 10, 10, new DateTime(2016, 06, 04), 10f, 10f, 10f));
            donationList.Add(new Donation("test", 10f, 10, 10, new DateTime(2015, 06, 04), 10f, 10f, 10f));

            dc.donor.donationHistory = donationList;

            //the last donation is the most recent one, hence 2018/06/04
            Assert.AreEqual(dc.donor.getLastDonation(), new DateTime(2018, 06, 04));

        }
    }
}
