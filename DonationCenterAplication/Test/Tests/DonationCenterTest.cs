using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.TestService;
using Client.Controller;
using Common.Model;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Test.Tests
{
    [TestClass]
    public class DonationCenterTest
    {
        public DonationCenterController donationCenterControllerFactory()
        {
            TestRemotingService testService = new TestRemotingService();

            DonationCenter don = new DonationCenter("123,123", "testName");
            /*
            foreach ( Plasma plasma in don.plasmaList.ToList() )
            {
                testService.DeleteFromDatabase(plasma);
            }
            foreach (RedBloodCell red in don.redBloodCellList.ToList())
            {
                testService.DeleteFromDatabase(red);
            }
            foreach (Trombocyte tromb in don.trombocyteList.ToList())
            {
                testService.DeleteFromDatabase(tromb);
            }
            testService.DeleteFromDatabase(don);
            testService.AddToDatabase(don);
            */


            DonationCenter donationCenter = testService.GetOneFromDatabase<DonationCenter>("123,123");
            DonationCenterController dcc = new DonationCenterController(testService, donationCenter);

            dcc.addBloodToStock(new Plasma("0", dcc.donationCenter.id, "1 980324 080030", 100f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new Plasma("A", dcc.donationCenter.id, "1 980324 080030", 101f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new Plasma("B", dcc.donationCenter.id, "1 980324 080030", 102f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new Plasma("AB", dcc.donationCenter.id, "1 980324 080030", 103f, DateTime.Now, "asdfas@scsd.cs"));

            dcc.addBloodToStock(new RedBloodCell("0", true, dcc.donationCenter.id, "1 980324 080030", 104f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("A", true, dcc.donationCenter.id, "1 980324 080030", 105f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("B", true, dcc.donationCenter.id, "1 980324 080030", 106f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("AB", true, dcc.donationCenter.id, "1 980324 080030", 107f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("0", false, dcc.donationCenter.id, "1 980324 080030", 108f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("A", false, dcc.donationCenter.id, "1 980324 080030", 109f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("B", false, dcc.donationCenter.id, "1 980324 080030", 110f, DateTime.Now, "asdfas@scsd.cs"));
            dcc.addBloodToStock(new RedBloodCell("AB", false, dcc.donationCenter.id, "1 980324 080030", 111f, DateTime.Now, "asdfas@scsd.cs"));

            dcc.addBloodToStock(new Trombocyte(dcc.donationCenter.id, "1 980324 0800", 112f, DateTime.Now, "asdfasdf@gmasd.cd"));


            return dcc;
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

            try
            {
                #region content

                #region setUp

                DonationCenterController dcc = donationCenterControllerFactory();

                dcc.service.AddToDatabase(new Doctor("asdf", "asdf", "asdf", new Location("test", 1, 1)));

                int? doctor_id = dcc.service.GetAllFromDatabase<Doctor>()[0].id;

                #endregion

                #region fail Case

                // not enought blood - return null
                Assert.IsNull(dcc.getAvailableBloodGreedy<RedBloodCell>(new List<RedBloodCell>(), 100));

                #endregion

                #region celule rosii

                String res = dcc.getAvailableBloodGreedy<RedBloodCell>(dcc.donationCenter.redBloodCellList.ToList(), 111);

                Assert.AreEqual(res.Split(';')[0], "Red Cells");
                Assert.AreEqual(res.Split(';')[1].Split(',')[1], "111");

                #endregion

                #region trombocite

                res = dcc.getAvailableBloodGreedy<Trombocyte>(dcc.donationCenter.trombocyteList.ToList(), 112);

                Assert.AreEqual(res.Split(';')[0], "Trombocyte");
                Assert.AreEqual(res.Split(';')[1].Split(',')[1], "112");

                #endregion

                #region plasma

                res = dcc.getAvailableBloodGreedy<Plasma>(dcc.donationCenter.plasmaList.ToList(), 103);

                Assert.AreEqual(res.Split(';')[0], "Plasma");
                Assert.AreEqual(res.Split(';')[1].Split(',')[1], "103");

                #endregion

                #endregion
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /* Sterge blood component-urile din baza de date ca sa mearga ok
        query:

        delete from redbloodcell;
        delete from plasma;
        delete from trombocyte;
        */
        [TestMethod]
        public void Test_updateAmmounts()
        {

            /*
            try
            {
                #region setUp

                DonationCenterController dcc = donationCenterControllerFactory();

                dcc.service.AddToDatabase(new Doctor("asdf", "asdf", "asdf", new Location("test", 1, 1)));

                int? doctor_id = dcc.service.GetAllFromDatabase<Doctor>()[0].id;

                #endregion

                #region red

                var redBCs = dcc.service.GetAllFromDatabase<RedBloodCell>();
                int minID = redBCs.First().id;


                int size = redBCs.Count;
                var emailList = dcc.updateAmmounts(compStr, "Red", new DoctorRequest());

                Assert.AreNotEqual(size, dcc.service.GetAllFromDatabase<RedBloodCell>().Count);
                Assert.AreEqual(emailList.Count, 3);

                #endregion

                #region trombocite

                var tromb = dcc.service.GetAllFromDatabase<Trombocyte>();
                minID = tromb.First().id;
                compStr = new string[1] { minID + ",12" };
                size = tromb.Count;
                emailList = dcc.updateAmmounts(compStr, "Tromb", new DoctorRequest());
                Assert.AreEqual(emailList.Count, 1);

                compStr[0] = minID + ",100";
                dcc.updateAmmounts(compStr, "Tromb", new DoctorRequest());
                Assert.AreNotEqual(size, dcc.service.GetAllFromDatabase<RedBloodCell>().Count);

                #endregion

                #region plasma

                var plasma = dcc.service.GetAllFromDatabase<Plasma>();
                minID = plasma.First().id;
                compStr = new string[2] { minID + ",100", (minID + 1) + ",100" };
                size = dcc.service.GetAllFromDatabase<Plasma>().Count;
                emailList = dcc.updateAmmounts(compStr, "Plasma", new DoctorRequest());

                Assert.AreNotEqual(size, dcc.service.GetAllFromDatabase<Plasma>().Count);
                Assert.AreEqual(emailList.Count, 2);

                #endregion
                //Lazy loading exception - ammount :/
                Assert.AreEqual(dcc.service.GetOneFromDatabase<Plasma>(2).ammount, 1);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            */
        }

        [TestMethod]
        public void Test_getAvailableBloodForRequest()
        {
            #region content
            #region setUp

            DonationCenterController dcc = donationCenterControllerFactory();

            dcc.service.AddToDatabase(new Doctor("asdf", "asdf", "asdf", new Location("test", 1, 1)));

            int? doctor_id = dcc.service.GetAllFromDatabase<Doctor>()[0].id;

            #endregion

            #region Trombocites
            DoctorRequest req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Tromb,112", "test");

            string compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Trombocyte");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "112");
            #endregion

            #region plasma
            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Plasma,0,100", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Plasma");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "100");


            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Plasma,A,101", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Plasma");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "101");


            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Plasma,B,102", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Plasma");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "102");
            

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Plasma,AB,103", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Plasma");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "103");
            #endregion



            #region red 
            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,0,true,104", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "104");

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,A,true,105", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "105");

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,B,true,106", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "106");

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,AB,true,107", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "107");

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,0,false,108", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "108");

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,A,false,109", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "109");

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,B,false,110", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "110");


            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,AB,false,111", "test");

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual(compString.Split(';')[0], "Red Cells");
            Assert.AreEqual(compString.Split(';')[1].Split(',')[1], "111");

            #endregion

            #region FailScenario
            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,AB,false,200", "test");
            req.isBeeingDelivered = true;

            compString = dcc.getAvailableBloodForRequest(req);

            Assert.AreEqual("Package is beeing delivered to the doctor", compString);

            req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Red,AB,false,200", "test");
           
            compString = dcc.getAvailableBloodForRequest(req);

            //Assert.AreEqual(null, compString);

            #endregion
            #endregion
        }
      
        [TestMethod]
        public void Test_sendBlood()
        {
        
            #region setUp

            DonationCenterController dcc = donationCenterControllerFactory();

            dcc.service.AddToDatabase(new Doctor("asdf", "asdf", "asdf", new Location("test", 1, 1)));

            int? doctor_id = dcc.service.GetAllFromDatabase<Doctor>()[0].id;

            #endregion

            DoctorRequest req = new DoctorRequest(doctor_id, dcc.donationCenter.id, 0, "test", "Tromb,112", "test");
            req.doctor_name = "test";
            req.hospital = "test";

            dcc.service.AddToDatabase(req);

            var emailList = dcc.sendBlood("ok;12/12/12", req);

            Assert.AreEqual(req.isBeeingDelivered, true);

            Doctor doc = dcc.service.GetOneFromDatabase<Doctor>(doctor_id);

            Trombocyte tromb = doc.trombocyteList.First(x => x.ammount == 112);

            Assert.AreNotEqual(tromb, null);
            Assert.AreEqual(tromb.doctor_id, doctor_id);

            emailList.ToList()
                .ForEach(x => Assert.AreEqual(x.Item1, "asdfas@scsd.cs"));

        }

    }
}
