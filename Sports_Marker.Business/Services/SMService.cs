using Microsoft.EntityFrameworkCore;
using Sports_Marker.Data.Models;
using Sports_Marker.Data.Models.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Marker.Business.Services
{
    public interface ISMService
    {
        IEnumerable<Marker> GetMarkers();
        Marker CreateMarker(Marker marker);
        Marker GetTeam(string team, bool trackEntity);
        Marker GetId (Guid id);
        Marker GetGoals(int goals, bool trackEntity);
        void AddGoals(Guid id);
        Marker GetFouls(int fouls, bool trackEntity = true);
        //IEnumerable<Marker> GetFouls();
        //IEnumerable<Marker> GetGoals();
        void AddFouls(Guid id);//, int fouls);
        Marker GetTime(DateTimeOffset time, bool trackEntity);
        void LogOut (Guid id);

    }

    public class SMService : ISMService
    {
        private readonly IGenericRepo<Marker> _markerRepo;

        public SMService(IGenericRepo<Marker> markerRepo)
        {
            _markerRepo = markerRepo;
        }

        public void AddFouls(Guid id)//, int fouls)
        {

            var _marker = GetId(id);
            if (_marker is not null)
            {
                _marker.fouls++;
                //fouls ++;
            };
            //_markerRepo.Add(_marker);
            _markerRepo.Save();

            //var _fouls = _markerRepo.Find(id);
            //_fouls.fouls ++;
            //_markerRepo.Save();
        }

       

        public void AddGoals(Guid id)
        {
            var _marker = GetId(id);
            if (_marker is not null)
            {
                _marker.goals++;
                
            };
           
            _markerRepo.Save();
        }

        public Marker CreateMarker(Marker marker)
        {
            var _marker = GetTeam(marker.team, true);

            if (_marker is not null)
            {
                _marker.inGame = true;
                _marker.teamColor = marker.teamColor;

                _markerRepo.Save();
                return _marker;
            }
            else
            {
                _markerRepo.Add(marker);
                _markerRepo.Save();

                return marker;
            }
        }

        public Marker GetFouls(int fouls, bool trackEntity)
        {
            var query = _markerRepo.PrepareQuery();
            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }
            return query.SingleOrDefault(x => x.fouls == fouls);
        }


        public Marker GetGoals(int goals, bool trackEntity)
        {
            var query = _markerRepo.PrepareQuery();
            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }
            return query.SingleOrDefault(x => x.goals == goals);
        }

        //public IEnumerable<Marker> GetGoals() =>

        //        _markerRepo.PrepareQuery()
        //        .AsNoTracking()
        //        .ToList();

        public Marker GetId(Guid id)
        {
            return _markerRepo.Find(id);
        }

        public IEnumerable<Marker> GetMarkers() =>
        
            _markerRepo.PrepareQuery()
            .Where(x => x.inGame == true)
            .AsNoTracking()
            .ToList();
        

        public Marker GetTeam(string team, bool trackEntity)
        {
           var query = _markerRepo.PrepareQuery();
            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }
            return query.SingleOrDefault(x => x.team == team);
        }

        public Marker GetTime(DateTimeOffset time, bool trackEntity)
        {
            var query = _markerRepo.PrepareQuery();
            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }
            return query.SingleOrDefault(x => x.Start == time);
        }

        public void LogOut(Guid id)
        {
            var marker = _markerRepo.Find(id);
            marker.inGame = false;
            _markerRepo.Save();
        }
    }
}
