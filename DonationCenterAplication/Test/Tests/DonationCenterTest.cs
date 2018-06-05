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
            
            DonationCenter don = new DonationCenter("46.75771,23.61778", "testName");
     
            
            testService.DeleteFromDatabase(don);
            
            testService.AddToDatabase(don);
            

            
            DonationCenter donationCenter = testService.GetOneFromDatabase<DonationCenter>("46.75771,23.61778");
            DonationCenterController dcc = new DonationCenterController(testService, donationCenter);

            donationCenter.plasmaList.ToList()
                .ForEach(x => testService.DeleteFromDatabase(x));

            donationCenter.trombocyteList.ToList()
               .ForEach(x => testService.DeleteFromDatabase(x));

            donationCenter.redBloodCellList.ToList()
               .ForEach(x => testService.DeleteFromDatabase(x));

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
            TestRemotingService testService = new TestRemotingService();
            DonationCenter don = new DonationCenter("46.75771,23.61778", "testName");
            testService.DeleteFromDatabase(don);
            testService.AddToDatabase(don);
            DonationCenter donationCenter = testService.GetOneFromDatabase<DonationCenter>("46.75771,23.61778");
            DonationCenterController dcc = new DonationCenterController(testService, donationCenter);
            
            dcc.donationCenter.donors = new List<Donor>();
            dcc.donationCenter.donors.Add(
                new Donor(
                    "1980415330827", 
                    "Alex",
                    new DateTime(1998, 04, 13),
                    "Str Buna Ziua",
                    new Location("str. Buna Ziua", 46.74784f, 23.59856f),
                    "testMail@test.com"
                ));

            dcc.donationCenter.donors.Add(
                new Donor(
                    "1980415386827",
                    "Mircea",
                    new DateTime(1998, 08, 13),
                    "Bloc O1, Strada Ion Meșter 1, Cluj-Napoca 400000, Romania",
                    new Location("Bloc O1, Strada Ion Meșter 1, Cluj-Napoca 400000, Romania", 46.74845f, 23.53742f),
                    "testMail@test.com"
                ));

            dcc.donationCenter.donors.Add(
                new Donor(
                    "1980411386827",
                    "Gheorghe",
                    new DateTime(1988, 02, 13),
                    "Sesame Street",
                    new Location("Sesame Street", 46.75517f, 23.57762f),
                    "testMail@test.com"
                ));

            IList<Donor> res = dcc.getNearestDonors(dcc.donationCenter.donors);
            Assert.AreEqual(res[0].name, "Alex");

            dcc.donationCenter.donors.Add(
                new Donor(
                    "1983211386827",
                    "Barbu",
                    new DateTime(1988, 02, 13),
                    "Sesame Street",
                    new Location("Megalodon Street", 46.74694f, 23.58302f),
                    "testMail@test.com"
                ));

            res = dcc.getNearestDonors(dcc.donationCenter.donors);
            Assert.AreEqual(res[0].name, "Alex");

            dcc.donationCenter.donors.Add(
                new Donor(
                    "1983211386927",
                    "Vasile Turbo",
                    new DateTime(1988, 02, 13),
                    "Sesame Street",
                    new Location("Megalodon Street", 46.76111f, 23.61271f),
                    "testMail@test.com"
                ));

            res = dcc.getNearestDonors(dcc.donationCenter.donors);
            Assert.AreEqual(res[0].name, "Vasile Turbo");

        }

        [TestMethod]
        public void Test_sortRequest()
        {
            TestRemotingService testService = new TestRemotingService();
            DonationCenter don = new DonationCenter("123,123", "testName");
            testService.DeleteFromDatabase(don);
            testService.AddToDatabase(don);
            DonationCenter donationCenter = testService.GetOneFromDatabase<DonationCenter>("46.75771,23.61778");
            DonationCenterController dcc = new DonationCenterController(testService, donationCenter);
        
            Doctor doctor = new Doctor("ion","Neurology","Burdujeni", new Location("Marelbo", 46f, 23f));
            dcc.service.AddToDatabase(doctor);

            DoctorRequest d1 = new DoctorRequest(
                6,
                "123,123",
                0,
                "Grigore",
                "Not so important",
                "Margineanu"
                );
            d1.doctor_name = "Terry";
            d1.hospital = "Terry's Hospital";

            dcc.service.AddToDatabase(d1);

            DoctorRequest d2 = new DoctorRequest(
                6,
                "123,123",
                5,
                "Marcel",
                "Very important",
                "Margineanu"
                );
            d2.doctor_name = "Terry";
            d2.hospital = "Terry's Hospital";
            dcc.service.AddToDatabase(d2);

            DoctorRequest d3 = new DoctorRequest(
                6,
                "123,123",
                3,
                "Marcel",
                "Pretty important",
                "Margineanu"
                );
            d3.doctor_name = "Terry";
            d3.hospital = "Terry's Hospital";

            dcc.service.AddToDatabase(d3);

            IList<DoctorRequest> res;

            res = dcc.sortRequests();

            Assert.AreEqual(res[0].requestString, "Very important");
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
                Assert.IsNull(dcc.getAvailableBloodGreedy(new List<RedBloodCell>(), 100));

                #endregion

            
                #region trombocite

                string res = dcc.getAvailableBloodGreedy(dcc.donationCenter.trombocyteList.ToList(), 112);

                Assert.AreEqual(res.Split(';')[0], "Trombocyte");
                Assert.AreEqual(res.Split(';')[1].Split(',')[1], "112");

                #endregion

                #region plasma

                res = dcc.getAvailableBloodGreedy(dcc.donationCenter.plasmaList.ToList(), 103);

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

            
            #region setUp

            DonationCenterController dcc = donationCenterControllerFactory();

            dcc.service.AddToDatabase(new Doctor("asdf", "asdf", "asdf", new Location("test", 1, 1)));

            int? doctor_id = dcc.service.GetAllFromDatabase<Doctor>()[0].id;

                


            #endregion

            #region red


            string gStr = dcc.getAvailableBloodGreedy(dcc.donationCenter.redBloodCellList.ToList(), 12);
            string[] compStr = gStr.Replace("\n", "").Split(';');

            compStr = compStr.Skip(1).ToArray();

            var emailList = dcc.updateAmmounts(compStr.Take(compStr.Count() - 1).ToArray(), "Red", new DoctorRequest());


            int size = dcc.donationCenter.redBloodCellList.Count;
            Assert.AreNotEqual(size, dcc.service.GetAllFromDatabase<RedBloodCell>().Count);

            Assert.AreEqual(emailList.Count, 1);

            #endregion

            #region trombocite

            gStr = dcc.getAvailableBloodGreedy(dcc.donationCenter.trombocyteList.ToList(), 12);
            compStr = gStr.Replace("\n", "").Split(';');

            compStr = compStr.Skip(1).ToArray();

            size = dcc.donationCenter.trombocyteList.Count;

            dcc.updateAmmounts(compStr.Take(compStr.Count() - 1).ToArray(), "Tromb", new DoctorRequest());
            Assert.AreNotEqual(size, dcc.service.GetAllFromDatabase<RedBloodCell>().Count);

            #endregion

            #region plasma

            var plasma = dcc.service.GetAllFromDatabase<Plasma>();

            gStr = dcc.getAvailableBloodGreedy(dcc.donationCenter.plasmaList.ToList(), 12);
            compStr = gStr.Replace("\n", "").Split(';');

            compStr = compStr.Skip(1).ToArray();

            size = dcc.service.GetAllFromDatabase<Plasma>().Count;
            emailList = dcc.updateAmmounts(compStr.Take(compStr.Count() - 1).ToArray(), "Plasma", new DoctorRequest());

            size = dcc.donationCenter.plasmaList.Count;

            Assert.AreNotEqual(size, dcc.service.GetAllFromDatabase<Plasma>().Count);

            #endregion
            
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
