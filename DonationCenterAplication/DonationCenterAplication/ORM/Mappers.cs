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
            Id(x => x.id);
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
            Property(x => x.patientName);
            Property(x => x.requestString);

            Id(x => x.id, m => {
                m.UnsavedValue(0);
                m.Generator(Generators.Native);
            });
        }
    }
    #endregion
   
    #region DonationCenterMap
    [Serializable]
    public class DonationCenterMap : ClassMapping<DonationCenter>
    {
        public DonationCenterMap()
        {
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

            Bag(x => x.redBloodCellList, map =>
            {

                map.Table("Plasma");
                map.Key(k => k.Column(col => col.Name("donationCenter_id")));
                map.Lazy(CollectionLazy.NoLazy);
            },
          action => action.OneToMany());

            Bag(x => x.redBloodCellList, map =>
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

            ComposedId(x =>
            {
                x.Property(y => y.username);
                x.Property(y => y.password);
            });
            Property(x => x.id);
            Property(x => x.type);
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
            Property (x => x.address);
            Property(x => x.email);
            Property(x => x.isPending);
            Property(x => x.donationCenter_id);

            Component(x => x.location, c =>
            {
                // mappings for component's parts
                c.Property(x => x.addressString);
                c.Property(x => x.latitude);
                c.Property(x => x.longitude);
                c.Class<Location>();

                c.Insert(true);
                c.Update(true);
                c.OptimisticLock(true);
                c.Lazy(false);
            });



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
            Id(x => x.id);
            Property(x => x.donationDate);
        }
    }
    #endregion
    
    #region TrombocyteMap
    [Serializable]
    public class TrobocyteMap : ClassMapping<Trombocyte>
    {
        public TrobocyteMap()
        {
            Id(x => x.id);
            Property(x => x.donationCenter_id);
            Property(x => x.donor_cnp);
            Property(x => x.ammount);
            Property(x => x.donationDate);
        }
    }
    #endregion
          
    #region PlasmaMap
    [Serializable]
    public class PlasmaMap : ClassMapping<Plasma>
    {
        public PlasmaMap()
        {
            Id(x => x.id);
            Property(x => x.antibody);
            Property(x => x.donationCenter_id);
            Property(x => x.donor_cnp);
            Property(x => x.ammount);
            Property(x => x.donationDate);
        }
    }
    #endregion

}
