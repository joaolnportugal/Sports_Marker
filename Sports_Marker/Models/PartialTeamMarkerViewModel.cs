using Sports_Marker.Data.Models;

namespace Sports_Marker.Web.Models
{
    public class PartialTeamMarkerViewModel
    {
        //public List<MarkerInfo> Fouls { get; set; } = new List<MarkerInfo>();
        //public List<MarkerInfo> Goals { get; set; } = new List<MarkerInfo>();
        public List<MarkerInfo> markers { get; set; } = new List<MarkerInfo>();

        public MarkerInfo markerInfo = new MarkerInfo();
        //private Marker goals;
        //private Marker fouls;

        public PartialTeamMarkerViewModel(/*IEnumerable<Marker> fouls, IEnumerable<Marker> goals,*/ IEnumerable<Marker> _markers)
        {
            //Fouls = fouls.Select(t => new MarkerInfo(t)).ToList();
            //Goals = goals.Select(t => new MarkerInfo(t)).ToList();
            markers = _markers.Select(t => new MarkerInfo(t)).ToList();
          
        }

      

    //    public PartialTeamMarkerViewModel(Marker fouls, Marker goals) 
    //    {
    //        this.goals = goals;
    //        this.fouls = fouls;

    //    }

    //    public PartialTeamMarkerViewModel(List<Marker> markerList)
    //    {
    //    }
    }
}
