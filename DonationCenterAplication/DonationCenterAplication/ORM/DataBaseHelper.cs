﻿using NHibernate;
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
                        x.ConnectionString = "Data Source = CTRLSOFT-FM1A7D\\MYSQL; Initial Catalog = Blood; Integrated Security = True";

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
