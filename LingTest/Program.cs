using Events.Entities;
using Events.Ioc;
using Events.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace LingTest
{
    class Program 
    {
        static void Main(string[] args)
        {



            UnityContainer uc = new UnityContainer();
            uc.RegisterType<IUnitOfWork, UnitOfWork>();
            uc.RegisterType<EventsEntities, EventsEntities>(new PerThreadLifetimeManager());
            uc.RegisterType<CityRepository, CityRepository>();
            uc.RegisterType<CountryRepository, CountryRepository>();
    
            var u = uc.Resolve<IUnitOfWork>();
            
           u.Cities.AddCity(new City()
           {
               NameAr = "dd",
               CountryId = 1
           });

        }
       

    }

   
}
