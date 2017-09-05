
using Events.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;

using Events.Ioc;
using Microsoft.Practices.Unity;

namespace Events.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventsEntities _db;
 MyContainer v = new MyContainer();

        public UnitOfWork(EventsEntities dbContext)
        {
            _db = dbContext;
           
            v.Register<Repository<City>,CityRepository>();
        }

        public Dictionary<Type,object> repositories = new Dictionary<Type, object>();

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            throw new Exception();
        }
       public  void SetRepo<T>(IRepository<T> r) where T : class

        {
            repositories.Add(typeof(T), r);
        }
        private CityRepository _cities;
        private CountryRepository _countries;
        private DurationRepository _durations;
        private EventRepository _events;
        private LevelRepository _levels;
        private LocationRepository _locations;
        private SessionRepository _sessions;
        private UserRepository _users;
        private VoterRepository _voters;

        //  public CityRepository Cities => _cities ?? (_cities = new CityRepository(_db));
        [Dependency]
        public CityRepository Cities { get; set; }
       // public CountryRepository Countries => _countries?? (_countries = new CountryRepository(_db));
        [Dependency]
        public CountryRepository Countries { get; set; }

        public DurationRepository Durations => _durations?? (_durations = new DurationRepository(_db));

        public EventRepository Events => _events?? (_events = new EventRepository(_db));

        public LevelRepository Levels => _levels?? (_levels = new LevelRepository(_db));

        public LocationRepository Locations => _locations?? (_locations = new LocationRepository(_db));

        public SessionRepository Sessions => _sessions?? (_sessions = new SessionRepository(_db));

        public UserRepository Users => _users?? (_users = new UserRepository(_db));

        public VoterRepository Voters => _voters?? (_voters = new VoterRepository(_db));

        public int Complete()
        {
            var result = 0;
            try
            {
                result = _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
            catch(DataException )
            {
                throw;
            }
            catch(Exception )
            {
                throw ;
            }
            return result;
        }
        public void Undo()
        {
            try
            {
                foreach (var entry in _db.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            entry.Reload();
                            break;
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        int IUnitOfWork.SaveChanges()
        {
            return _db.SaveChanges();
        }


        private void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }


        #region IDisposable Support
        private bool _disposedValue ; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        
        #endregion



    }
}
