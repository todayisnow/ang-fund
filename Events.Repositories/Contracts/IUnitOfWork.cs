using System;

namespace Events.Repositories
{
    public interface IUnitOfWork : IDisposable 
    {
       
        CityRepository Cities { get; }
        CountryRepository Countries { get; }
        DurationRepository Durations { get; }
        EventRepository Events { get; }
        LevelRepository Levels { get; }
        LocationRepository Locations { get; }
        SessionRepository Sessions { get; }
        UserRepository Users { get; }
        VoterRepository Voters { get; }

        IRepository<T> GetRepository<T>() where T : class;
        void SetRepo<T>(IRepository<T> r) where T : class;
        int SaveChanges();
        int Complete();
        void Undo();

    }
}
