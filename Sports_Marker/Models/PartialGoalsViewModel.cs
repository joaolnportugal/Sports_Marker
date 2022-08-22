using Sports_Marker.Data.Models;

namespace Sports_Marker.Web.Models
{
    public class PartialGoalsViewModel
    {
        public List<MarkerInfo> Goals { get; set; } = new List<MarkerInfo>();

        public PartialGoalsViewModel(IEnumerable<Marker> goals)
        {
            Goals = goals.Select(t => new MarkerInfo(t)).ToList();
        }
    }
}
