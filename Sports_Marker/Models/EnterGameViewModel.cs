using Sports_Marker.Data.Models;
using Sports_Marker.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace Sports_Marker.Web.Models
{
    public record EnterGameViewModel
    {
        [Display(Name = "Name", Prompt = "Enter Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a valid Username")]
        public string Team { get; set; }
        public List<Marker> TeamList { get; set; } = new List<Marker>();
        [Range(10, 80,
       ErrorMessage = "Please choose a color")]
        public int SelectedColor { get; set; }
        public List<TeamColor> AvailableColors { get; set; }
        public bool inGame { get; set; }

        public EnterGameViewModel()
        {
            AvailableColors = Enum.GetValues<Color>().Select(c => new TeamColor(c)).ToList();
        }

        public record TeamColor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CssClassName { get; set; }

            public TeamColor(Color color)
            {
                Id = (int)color;
                Name = color.ToString();
                CssClassName = color switch
                {
                    Color.DarkBlue => "btn-outline-primary",
                    Color.DarkGray => "btn-outline-secondary",
                    Color.Green => "btn-outline-success",
                    Color.Red => "btn-outline-danger",
                    Color.Yellow => "btn-outline-warning",
                    Color.LightBlue => "btn-outline-info",
                    Color.Black => "btn-outline-dark",
                    Color.White => "btn-outline-white",
                    _ => "btn-outline-primary"
                };
            }
        }
    }
}
