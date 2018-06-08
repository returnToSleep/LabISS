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

            doctor.requests.ToList()
                .ForEach(x => testService.DeleteFromDatabase(x));

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
                donationCenter_id = null,
                doctor_id = doctorController.doctor.id
            };
            var red = new RedBloodCell
            {
                ammount = 300,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = null,
                doctor_id = doctorController.doctor.id,
                antigen = "B",
                rh = false
            };
            var plasma = new Plasma
            {
                ammount = 100,
                donatedFor = "TestDonatedFor",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = null,
                doctor_id = doctorController.doctor.id,
                antibody = "B"
            };

            DonationCenter don = new DonationCenter("1,1", "test");

            doctorController.service.AddToDatabase(don);
            doctorController.service.AddToDatabase(tromb);
            doctorController.service.AddToDatabase(red);
            doctorController.service.AddToDatabase(plasma);

            doctorController.refresh();

            #endregion
            //Tromb test
            var docReq = new DoctorRequest(1,"1,1",1,"testPacientName", "Tromb,100","test");
            Trombocyte result = (Trombocyte)doctorController.matchBloodWithRequest(docReq);
            Assert.AreEqual(result.ammount, 100);
            Assert.IsTrue(result is Trombocyte);

            //Plasma test
            docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Plasma,B,100", "test");
            Plasma plasmaResult = (Plasma)doctorController.matchBloodWithRequest(docReq);
            Assert.AreEqual(plasmaResult.ammount, 100);
            Assert.AreEqual(plasmaResult.antibody, "B");
            Assert.IsTrue(plasmaResult is Plasma);

            //Red test
            docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Red,B,false,300", "test");
            RedBloodCell redResult = (RedBloodCell)doctorController.matchBloodWithRequest(docReq);
            Assert.AreEqual(redResult.ammount, 300);
            Assert.IsTrue(!redResult.rh);
            Assert.AreEqual(redResult.antigen, "B");

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
            int first = doctorController.service.GetAllFromDatabase<Trombocyte>().Count;
            doctorController.acceptBlood(docReq,tromb,true);
            Assert.IsTrue(first > doctorController.service.GetAllFromDatabase<Trombocyte>().Count);

            //Plasma test
            docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Plasma,B,100", "test");
            first = doctorController.service.GetAllFromDatabase<Plasma>().Count;
            doctorController.acceptBlood(docReq,plasma,true);
            Assert.IsTrue(first > doctorController.service.GetAllFromDatabase<Plasma>().Count);

            //Red test
            docReq = new DoctorRequest(1, "1,1", 1, "testPacientName", "Red,AB,false,200", "test");
            first = doctorController.service.GetAllFromDatabase<RedBloodCell>().Count;
            doctorController.acceptBlood(docReq,red,true);
            Assert.IsTrue(first > doctorController.service.GetAllFromDatabase<RedBloodCell>().Count);

            //DELETE NEW DATA
            doctorController.service.DeleteFromDatabase(don);
        }


        [TestMethod]
        public void Test_makeRequest()
        {
            #region Fill data
            var doctorController = this.doctorControllerFactory();
            doctorController.service.AddToDatabase(new DonationCenter("1,1", "test"));


            doctorController.doctor.requests.ToList()
                .ForEach(x => doctorController.service.DeleteFromDatabase(x));


            Location l = new Location
            {
                addressString = "Test",
                id = 1001,
                latitude = 1,
                longitude = 1
            };

            int count = doctorController.service.GetAllFromDatabase<DoctorRequest>().Count;

            doctorController.makeRequest(
                l,
                1,
                "TestPacient",
                "TestPacient",
                "hello world",
                "Centrul Save-A-Life"
                );
            #endregion

            //count should have increased
            Assert.IsTrue(doctorController.service.GetAllFromDatabase<DoctorRequest>().Count != count);
            Assert.IsTrue(doctorController.service.GetAllFromDatabase<DoctorRequest>().Count == count + 1);

            //the inserted request should have the same fields
            DoctorRequest req = doctorController.service.GetAllFromDatabase<DoctorRequest>().First(x => x.pacientName == "TestPacient");
            
            Assert.IsTrue(req.pacientName == "TestPacient"
                && req.requestString == "hello world"
                && req.priority == 1);

            //the initial state should be false
            Assert.IsFalse(req.isBeeingDelivered);

            req.isBeeingDelivered = false;

            doctorController.service.DeleteFromDatabase(req);
        }

        [TestMethod]
        public void Test_reviewBloodStocks()
        {
            var doctorController = doctorControllerFactory();

            #region Fill data
            var d1 = new DonationCenter("1,1", "test");
            var d2 = new DonationCenter("1000000,1000000", "test2");
            doctorController.service.AddToDatabase(d1);
            doctorController.service.AddToDatabase(d2);

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
                donatedFor = "bob",
                donationDate = DateTime.Parse("2018-05-30"),
                donationCenter_id = "1000000,1000000",
                antibody = "B"
            };

            #endregion

            //why do you need a location for this function, if the location is never used?
            var init_bloodStocks = doctorController.reviewBloodStocks(new Location());

            doctorController.service.AddToDatabase(tromb);
            doctorController.service.AddToDatabase(red);
            doctorController.service.AddToDatabase(plasma);

            var after_bloodStocks = doctorController.reviewBloodStocks(new Location());

            // count should have increased for all 3 lists
            Assert.IsTrue(
                init_bloodStocks.Item1.Count != after_bloodStocks.Item1.Count &&
                init_bloodStocks.Item2.Count != after_bloodStocks.Item2.Count &&
                init_bloodStocks.Item3.Count != after_bloodStocks.Item3.Count
                );

            //the items should be the same as the ones we inserted
            Assert.IsTrue(
                after_bloodStocks.Item1.Last().ammount == plasma.ammount &&
                after_bloodStocks.Item1.Last().donatedFor == plasma.donatedFor &&
                after_bloodStocks.Item1.Last().donationCenter_id == plasma.donationCenter_id &&
                after_bloodStocks.Item1.Last().antibody == plasma.antibody &&

                after_bloodStocks.Item2.Last().ammount == tromb.ammount &&
                after_bloodStocks.Item2.Last().donatedFor == tromb.donatedFor &&
                after_bloodStocks.Item2.Last().donationCenter_id == tromb.donationCenter_id &&

                after_bloodStocks.Item3.Last().ammount == red.ammount &&
                after_bloodStocks.Item3.Last().donatedFor == red.donatedFor &&
                after_bloodStocks.Item3.Last().donationCenter_id == red.donationCenter_id &&
                after_bloodStocks.Item3.Last().antigen == red.antigen
                );

            //this would be true if == operator was overloaded
            //Assert.IsTrue(
            //    after_bloodStocks.Item1.Last() == plasma &&
            //    after_bloodStocks.Item2.Last() == tromb &&
            //    after_bloodStocks.Item3.Last() == red
            //    );
            
            #region Clear data
            doctorController.service.DeleteFromDatabase(plasma);
            doctorController.service.DeleteFromDatabase(red);
            doctorController.service.DeleteFromDatabase(tromb);
            doctorController.service.DeleteFromDatabase(d1);
            doctorController.service.DeleteFromDatabase(d2);
            #endregion
        }

    }
}
