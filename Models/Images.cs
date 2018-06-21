using System.Text;

namespace devfestweekend.Models
{
    public class Images : BaseDataObject
    {
        public string SplashScreenLogo { get; set; }
        public string VenueMaps { get; set; }
        public string HotelLogo { get; set; }
        public string AppIcons { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine( "\n---- IMAGES ----\n" );

            result.AppendLine( "SplashScreenLogo: " + SplashScreenLogo );
            result.AppendLine( "VenueMaps: " + VenueMaps );
            result.AppendLine( "HotelLogo: " + HotelLogo );
            result.AppendLine( "AppIcons: " + AppIcons );

            return result.Append( "\n" ).ToString();
        }
    }
}