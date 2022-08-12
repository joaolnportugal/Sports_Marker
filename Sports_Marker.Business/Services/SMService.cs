﻿using Microsoft.EntityFrameworkCore;
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
        



    }

    public class SMService : ISMService
    {
        private readonly IGenericRepo<Marker> _markerRepo;

        public SMService(IGenericRepo<Marker> markerRepo)
        {
            _markerRepo = markerRepo;
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

     
    }
}
