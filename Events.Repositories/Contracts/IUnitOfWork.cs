using Events.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repositories
{
    public interface IUnitOfWork : IDisposable 
    {
        CityRepository Cities { get; }
     
               

        int SaveChanges();
        int Complete();
        void Undo();

    }
}
