﻿using Sports_Marker.Data.Models;
using Sports_Marker.Data.Models.Shared;
using Sports_Marker.Web.Infrastructure.Extensions;

namespace Sports_Marker.Web.Models
{
    public class ViewSMViewModel
    {
        public Guid markerId { get; set; }
        public string team { get; set; }
        public bool inGame { get; set; }
        public Color teamColor { get; set; }
        public string colorCssClasses { get; set; }
        public List<MarkerInfo> markers { get; set; } = new List<MarkerInfo>();
        public MarkerInfo markerInfo { get; set; } = new MarkerInfo();
        //public PartialFoulsViewModel FoulsModel { get; set }
        //public PartialGoalsViewModel GoalsModel { get; set }
        //public PartialClockViewModel ClockModel { get; set }

        public ViewSMViewModel(Marker marker, List<Marker> markerList, List<Marker> goalList, List<Marker> foulList, DateTimeOffset clock)
        {
            markerId = marker.Id;
            team = marker.team;
            inGame = marker.inGame;
            teamColor = marker.teamColor;
            colorCssClasses = teamColor.ToString();
            markers = markerList.Select(t => new MarkerInfo(t)).ToList();
            //FoulsModel = new PartialFoulsViewModel(foulList);
            //GoalsModel = new PartialGoalsViewModel(goalList);
            //ClockModel = new PartialClockViewModel(clock);
        }

        public ViewSMViewModel(Marker marker, List<Marker> markers1)
        {
        }
    }

    public class MarkerInfo
    {
        public Guid markerId { get; set; }
        public string team { get; set; }
        public string colorCssClasses { get; set; }
        public bool inGame { get; set; }
        public DateTimeOffset clock { get; set; }
        public int fouls { get; set; }
        

        public MarkerInfo(Marker marker)
        {
            markerId = marker.Id;
            team = marker.team;
            colorCssClasses = marker.teamColor.GetCssClasses();
            inGame = marker.inGame;
            clock = marker.Start;
            fouls = marker.fouls;
        }

        public MarkerInfo()
        {
        }
    }
}