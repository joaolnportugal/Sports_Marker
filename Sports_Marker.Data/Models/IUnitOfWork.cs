using Sports_Marker.Data.Models.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Marker.Data.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Marker> Marker { get; }
        void Save();
    }
}
