using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using Repository;
using Test.TestService;
using Controller;
using Common.Model;
using Client.Controller;
using System.Linq;

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

            List<DonationCenter> donList = testService.GetAllFromDatabase<DonationCenter>().ToList();


            doctor.requests.ToList()
                .ForEach(x => testService.DeleteFromDatabase(x));

            donList.ForEach(donationCenter =>
           {
               /*
               donationCenter.plasmaList.ToList()
                 .ForEach(x => testService.DeleteFromDatabase(x));

               donationCenter.trombocyteList.ToList()
                  .ForEach(x => testService.DeleteFromDatabase(x));

               donationCenter.redBloodCellList.ToList()
                  .ForEach(x => testService.DeleteFromDatabase(x));
                  */
               testService.DeleteFromDatabase(donationCenter);
           });
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
                donationCenter_id = "1,1"
            };
            var red = new RedBloodCell
            {
                ammount = 53,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1",
                antigen ="B",
                rh=false
            };
            var plasma = new Plasma
            {
                ammount = 23,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1",
                antibody ="B"
            };

            DonationCenter don = new DonationCenter("1,1", "test");

            doctorController.service.AddToDatabase(don);
            doctorController.service.AddToDatabase(tromb);
            doctorController.service.AddToDatabase(red);
            doctorController.service.AddToDatabase(plasma);
     
#endregion
            var result = doctorController.getBloodDonatedForPacient("TestDonatedFor", "1,1");
            Assert.AreEqual(result.Item1, 10);
            Assert.AreEqual(result.Item2, 23);
            Assert.AreEqual(result.Item3, 53);

            //DELETE NEW DATA
            doctorController.service.DeleteFromDatabase(tromb);
            doctorController.service.DeleteFromDatabase(red);
            doctorController.service.DeleteFromDatabase(plasma);
            doctorController.service.DeleteFromDatabase(don);
        }

        [TestMethod]
        public void Test_getRequiredBloodForPacient()
        {
            var doctorController = this.doctorControllerFactory();
            
            //doctorController.doctor = doctorController.service.GetOneFromDatabase<Doctor>(1);
            #region FillData

            doctorController.service.AddToDatabase(new DonationCenter("1,1", "test"));

            doctorController.makeRequest(
                new Location
                {
                    addressString = "Test",
                    id = 1001,
                    latitude = 1,
                    longitude = 1
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
                    latitude = 1,
                    longitude = 1
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
                    latitude = 1,
                    longitude = 1
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
                    latitude = 1,
                    longitude = 1
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
                    latitude = 1,
                    longitude = 1
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
                    latitude = 1,
                    longitude = 1
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
            doctorController.deleteRequest("TestPacient");
            //delete the test request
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
            /*
             * Returns the component that matches the request based on requestString
             * 
             * requestString
             *      Type,[Group][Rh],Quantity
             * 
             * Examples:
             *      requestString for RedBloodCells 
             *           "Red,A,true,100" 
             *           "Red,AB,false,200"
             *      
             *      requestString for Plasma 
             *           "Plasma,B,100" 
             *           "Plasma,0,200"
             *       
             *       requestString for Trombocytes
             *           "Tromb,100"
             *           "Tromb,200"
             */
            var doctorController = this.doctorControllerFactory();
            #region FillData
            var tromb = new Trombocyte
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1"
            };
            var red = new RedBloodCell
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1",
                antigen = "B",
                rh = false
            };
            var plasma = new Plasma
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1",
                antibody = "B"
            };

            DonationCenter don = new DonationCenter("1,1", "test");

            doctorController.service.AddToDatabase(don);
            doctorController.service.AddToDatabase(tromb);
            doctorController.service.AddToDatabase(red);
            doctorController.service.AddToDatabase(plasma);

            #endregion
            //Tromb test
            var docReq = new DoctorRequest(1,"1,1",1,"testPacientName", "Tromb,100","test");
            var result = doctorController.matchBloodWithRequest(docReq);
            Assert.AreEqual(result.amount, 100);
            Assert.IsTrue(result is Trombocyte);

            //Plasma test
            var docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Plasma,B,100", "test");
            var result = doctorController.matchBloodWithRequest(docReq);
            Assert.AreEqual(result.amount, 100);
            Assert.AreEqual(result.antibody, "B");
            Assert.IsTrue(result is Plasma);

            //Red test
            var docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Red,AB,false,200", "test");
            var result = doctorController.matchBloodWithRequest(docReq);
            Assert.AreEqual(result.amount, 200);
            Assert.IsTrue(result is RedBloodCell);
            Assert.IsTrue(!result.rh);
            Assert.AreEqual(result.antigen, "AB");

            //DELETE NEW DATA
            doctorController.service.DeleteFromDatabase(tromb);
            doctorController.service.DeleteFromDatabase(red);
            doctorController.service.DeleteFromDatabase(plasma);
            doctorController.service.DeleteFromDatabase(don);
        }

        [TestMethod]
        public void Test_acceptBlood()
        {
            /*
             * This one is a bit tricky
             * 
             * If the doctor accepts the blood
             *      then it and the request are removed from the database
             * else 
             *      The way blood delivery works:
             *          donationCenter_Id from the component is set to null 
             *          doctor_Id is set to request.doctor_Id
             *          request.isBeeingDelivered is set to true
             *          
             *      That way, the component no longer appears in the donation center gui (beeing delivered)
             *      and can be added back if the doctor refuses it
             */
            var doctorController = this.doctorControllerFactory();
            #region FillData
            var tromb = new Trombocyte
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1"
            };
            var red = new RedBloodCell
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1",
                antigen = "B",
                rh = false
            };
            var plasma = new Plasma
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1,1",
                antibody = "B"
            };

            DonationCenter don = new DonationCenter("1,1", "test");

            doctorController.service.AddToDatabase(don);
            doctorController.service.AddToDatabase(tromb);
            doctorController.service.AddToDatabase(red);
            doctorController.service.AddToDatabase(plasma);

            #endregion
            //Tromb test
            var docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Tromb,100", "test");
            int first = doctorController.service.GetAllFromDatabase<Trombocyte>();
            doctorController.acceptBlood(docReq,tromb,true);
            Assert.IsTrue(first > doctorController.service.GetAllFromDatabase<Trombocyte>());

            //Plasma test
            var docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Plasma,B,100", "test");
            int first = doctorController.service.GetAllFromDatabase<Plasma>();
            doctorController.acceptBlood(docReq,plasma,true);
            Assert.IsTrue(first > doctorController.service.GetAllFromDatabase<Plasma>());

            //Red test
            var docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Red,AB,false,200", "test");
            int first = doctorController.service.GetAllFromDatabase<RedBloodCell>();
            doctorController.acceptBlood(docReq,red,true);
            Assert.IsTrue(first > doctorController.service.GetAllFromDatabase<RedBloodCell>());

            //DELETE NEW DATA
            doctorController.service.DeleteFromDatabase(don);
        }



    }
}
