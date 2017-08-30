using Events.Entities;
using Events.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LingTest
{
    class Program 
    {
        static void Main(string[] args)
        {

            try
            {

                var u = new UnitOfWork(new LinqTestEntities());
                var f = DateTime.Now.Ticks;
                u.Cities.AddCity(new City
                {
                    Name = "ddd",
                    CountryId = 55
                });
                u.Complete();
                Console.WriteLine(DateTime.Now.Ticks - f);
           
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }



        }

    }
    public class V
    {
        public async Task a()
        {
            await c();
            
        }

        public async void b()
        {
            await c();
        }
        public async Task c()
        {
            await Task.Delay(1000);
            throw new NotImplementedException();
        }
    }
   
}
