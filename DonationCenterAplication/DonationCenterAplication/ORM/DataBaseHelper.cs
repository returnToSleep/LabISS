using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DonationCenterAplication.ORM
{
    class DataBaseHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {


                    var cfg = new Configuration();

                    cfg.DataBaseIntegration(x => {
                        x.ConnectionString = "Data Source=den1.mssql2.gear.host;Initial Catalog=blooddonation1;User ID=blooddonation1;Password=Cy1e1bU~?v30";
                        //x.ConnectionString = "Data Source=DESKTOP-ILR06L3;Initial Catalog=Test;Integrated Security=True";
                        //x.ConnectionString = "Data Source=den1.mssql5.gear.host; Initial Catalog = blooddonation1; User Id = blooddonation1; Password = Qz7VGZX2!4!m";

                        x.Driver<SqlClientDriver>();
                                            x.Dialect<MsSql2012Dialect>();
                                            x.LogSqlInConsole = true;
                                        });


                    cfg.AddAssembly(Assembly.GetExecutingAssembly());


                    var mapper = new ModelMapper();
                    mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

                    HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                    cfg.AddMapping(mapping);

                    //cfg.Configure();

                    _sessionFactory = cfg.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

       

    }
}
