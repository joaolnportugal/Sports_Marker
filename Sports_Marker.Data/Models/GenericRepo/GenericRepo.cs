using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sports_Marker.Data.Models.GenericRepo
{
    public interface IGenericRepo<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> PrepareQuery();
        TEntity Find(Guid id);
      
        void Add(TEntity entity);
        int Save();
        

    }
    public class GenericRepo<TEntity> : IGenericRepo<TEntity>
        where TEntity : EntityBase
    {
        private readonly SMDbContext _dbContext;
        protected DbSet<TEntity> dbSet { get; init; }

        public GenericRepo(SMDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.dbSet = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> PrepareQuery() =>
            dbSet.AsQueryable();

        public TEntity Find(Guid id)
            => PrepareQuery().SingleOrDefault(x => x.Id == id);

        public void Add(TEntity entity) =>
            dbSet.Add(entity);



        public int Save()
            => _dbContext.SaveChanges();


    }
}
