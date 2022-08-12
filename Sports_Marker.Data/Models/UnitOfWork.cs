using Sports_Marker.Data.Models.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Marker.Data.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private SMDbContext _context;
        public IGenericRepo<Marker> _marker;

        public UnitOfWork(SMDbContext dbContext)
        {
            _context = dbContext;           
        }

        public IGenericRepo<Marker> MarkerRepo
        {
            get
            {

                if (this._marker == null)
                {
                    this._marker = new GenericRepo<Marker>(_context);
                }
                return _marker;
            }
        }

        public IGenericRepo<Marker> Marker => throw new NotImplementedException();

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
