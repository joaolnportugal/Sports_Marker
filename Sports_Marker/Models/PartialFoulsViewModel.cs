using Sports_Marker.Data.Models;

namespace Sports_Marker.Web.Models
{
    public class PartialFoulsViewModel
    {
        public List<MarkerInfo> Fouls { get; set; } = new List<MarkerInfo>();
        public MarkerInfo markerInfo = new MarkerInfo();


        public PartialFoulsViewModel(IEnumerable<Marker> fouls)
        {
            Fouls = fouls.Select(t => new MarkerInfo(t)).ToList();
            markerInfo = new MarkerInfo();
        }

        public PartialFoulsViewModel(Marker fouls)
        {
        }
    }
}
