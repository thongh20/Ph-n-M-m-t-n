using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dangnhapjed
{
    public static class Themecolor

    {
        public static Color primarycolor {  get; set; }
         public static Color secondarycolor { get; set; }
        public static List<string> colorList = new List<string>()
        {
         "#7FFFD4",
        " #F0FFFF",
        " #F5F5DC",
         "#FFE4C4",
        " #8A2BE2",
         "#A52A2A",
         "#DEB887",
         "#5F9EA0",
        " #7FFF00",
        " #D2691E",
        " #FF7F50",
       "  #DC143C",
        " #00FFFF",
        " #00008B",
       "  #008B8B",
        "  #B8860B",
        "#FFFF00"

  };
  public static Color ChangeColorBirght(Color color , double conrrectionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            if(conrrectionFactor <0) {
                conrrectionFactor = 1 + conrrectionFactor;
                red  *= conrrectionFactor;
                green *= conrrectionFactor;
                blue *= conrrectionFactor;

            
            
            
            }
            else
            {
                red = (255 - red) * conrrectionFactor + red;
                green= (255 - green) * conrrectionFactor + green;
                blue = (255 - blue) * conrrectionFactor + blue;
                
            }
                return Color.FromArgb(color.A , (byte)red , (byte)green , (byte)blue );
        }


        
    }
}
