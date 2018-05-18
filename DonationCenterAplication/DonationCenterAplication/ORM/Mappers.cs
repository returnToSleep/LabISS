using Common.Model;
using Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace DonationCenterServer.ORM
{

    //Please don't touch these 

    #region DoctorMap
    [Serializable]
    public class DoctorMap : ClassMapping<Doctor>
    {
        public DoctorMap()
        {

            Lazy(false);

            Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });

            Property(x => x.name);
            Property(x => x.speciality);
            Property(x => x.hospital);
            
         
            Bag(x => x.requests, map =>
            {
                
                map.Table("DoctorRequest");
                map.Key(k => k.Column(col => col.Name("doctor_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
            action => action.OneToMany());

            Component(x => x.location, c =>
            {
                // mappings for component's parts
                
                c.Property(x => x.latitude);
                c.Property(x => x.longitude);
                c.Class<Location>();

                c.Insert(true);
                c.Update(true);
                c.OptimisticLock(true);
                c.Lazy(false);
            });

           

            Bag(x => x.redBloodCellList, map =>
            {
                map.Lazy(CollectionLazy.NoLazy);
                map.Table("RedBloodCell");
                map.Key(k => k.Column(col => col.Name("doctor_id")));
             
            },
          action => action.OneToMany());

            Bag(x => x.plasmaList, map =>
            {
                map.Lazy(CollectionLazy.NoLazy);
                map.Table("Plasma");
                map.Key(k => k.Column(col => col.Name("doctor_id")));
               
            },
            action => action.OneToMany());

            Bag(x => x.trombocyteList, map =>
            {
                map.Lazy(CollectionLazy.NoLazy);
                map.Table("Trombocyte");
                map.Key(k => k.Column(col => col.Name("doctor_id")));

            },
           action => action.OneToMany());
        }
    }
    #endregion
   
    #region DoctorRequestMap
    [Serializable]
    public class DoctorRequestMap : ClassMapping<DoctorRequest>
    {
        public DoctorRequestMap()
        {
         
            Property(x => x.doctor_id);
            Property(x => x.donationCenter_id);
            
            Property(x => x.priority);
            Property(x => x.patientCnp);
            Property(x => x.requestString);

            Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });

            Property(x => x.doctor_name);
            Property(x => x.hospital);
            
            Property(x => x.isBeeingDelivered, map => map.Column("status"));

        }
    }
    #endregion
   
    #region DonationCenterMap
    [Serializable]
    public class DonationCenterMap : ClassMapping<DonationCenter>
    {
        public DonationCenterMap()
        {
            Lazy(false);
            Id(x => x.id);      
            Property(x => x.name);

            Bag(x => x.requests, map =>
            {

                map.Table("DoctorRequest");
                map.Key(k => k.Column(col => col.Name("donationCenter_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
            action => action.OneToMany());

            Bag(x => x.donors, map =>
            {

                map.Table("Donor");
                map.Key(k => k.Column(col => col.Name("donationCenter_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
            action => action.OneToMany());

            Bag(x => x.redBloodCellList, map =>
            {

                map.Table("RedBloodCell");
                map.Key(k => k.Column(col => col.Name("donationCenter_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
           action => action.OneToMany());

            Bag(x => x.plasmaList, map =>
            {

                map.Table("Plasma");
                map.Key(k => k.Column(col => col.Name("donationCenter_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
          action => action.OneToMany());

            Bag(x => x.trombocyteList, map =>
            {

                map.Table("Trombocyte");
                map.Key(k => k.Column(col => col.Name("donationCenter_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
          action => action.OneToMany());


        }
    }


    #endregion
    
    #region LogInfoMap
    [Serializable]
    public class LogInfoMap : ClassMapping<LogInfo>
    {
        public LogInfoMap()
        {

            Id(x => x.username);
            Property(x => x.password);
            
            Property(x => x.intId);
            Property(x => x.type);
            Property(x => x.varId);
            Lazy(false);
        }
    }
    #endregion
    
    #region DonorMap
    [Serializable]
    public class DonorMap : ClassMapping<Donor>
    {
        public DonorMap()
        {
            Property(x => x.name);
            Id(x => x.cnp);
            Property(x => x.birthdate);
            Property(x => x.email);
            Property(x => x.isPending);
            Property(x => x.donationCenter_id);
            

            Component(x => x.location, c =>
            {
                // mappings for component's parts
                c.Property(x => x.latitude);
                c.Property(x => x.longitude);
                c.Class<Location>();

                c.Insert(true);
                c.Update(true);
                c.OptimisticLock(true);
                c.Lazy(false);
            });


                Bag(x => x.donationHistory, map =>
                {
                    map.Table("Donation");
                    map.Key(k => k.Column(col => col.Name("donor_Cnp")));
                    map.Lazy(CollectionLazy.NoLazy);
                },
               action => action.OneToMany());

              Bag(x => x.trombocyteList, map =>
                {
                    map.Table("Trombocyte");
                    map.Key(k => k.Column(col => col.Name("donor_Cnp")));
                    map.Lazy(CollectionLazy.NoLazy);
                },
              action => action.OneToMany());

                Bag(x => x.redBloodCellList, map =>
                {
                    map.Table("RedBloodCell");
                    map.Key(k => k.Column(col => col.Name("donor_Cnp")));
                    map.Lazy(CollectionLazy.NoLazy);
                },
              action => action.OneToMany());

              Bag(x => x.plasmaList, map =>
                {
                    map.Table("Plasma");
                    map.Key(k => k.Column(col => col.Name("donor_Cnp")));
                    map.Lazy(CollectionLazy.NoLazy);
                },
              action => action.OneToMany());

            Property(x => x.bloodType);
            Property(x => x.rh);
         
        }



    }

    #endregion
    
    #region RedBloodCellMap
    [Serializable]
    public class RedBloodCellMap : ClassMapping<RedBloodCell>
    {
        public RedBloodCellMap()
        {
            Property(x => x.antigen);
            Property(x => x.rh);
            Property(x => x.donationCenter_id);
            Property(x => x.donor_cnp);
            Property(x => x.ammount);
            Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });
            Property(x => x.donationDate);
            Property(x => x.doctor_id);
            Property(x => x.email);
        }
    }
    #endregion
    
    #region TrombocyteMap
    [Serializable]
    public class TrobocyteMap : ClassMapping<Trombocyte>
    {
        public TrobocyteMap()
        {
            Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });
            Property(x => x.donationCenter_id);
            Property(x => x.donor_cnp);
            Property(x => x.ammount);
            Property(x => x.donationDate);
            Property(x => x.doctor_id);
            Property(x => x.email);
        }
    }
    #endregion
          
    #region PlasmaMap
    [Serializable]
    public class PlasmaMap : ClassMapping<Plasma>
    {
        public PlasmaMap()
        {
            Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });
            Property(x => x.antibody);
            Property(x => x.donationCenter_id);
            Property(x => x.donor_cnp);
            Property(x => x.ammount);
            Property(x => x.donationDate);
            Property(x => x.doctor_id);
            Property(x => x.email);
        }
    }
    #endregion

    #region Donation
       
    [Serializable]
    public class DonationMap : ClassMapping<Donation>
    {
        public DonationMap()
        {
            Table("Donation");
            Id(x => x.id); Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });
            Property(x => x.donor_Cnp);
            Property(x => x.quantity);
            Property(x => x.bloodPressure);
            Property(x => x.donationDate);
        }
    }
    #endregion
}

