using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LandscapeAppWebsite.Models
{
    public class RequestManager
    {
        public int LorX { get; set; } = 4081;
        public int LorY { get; set; } = 4081;

        public int CompSizeX { get; set; }

        public int CompSizeY { get; set; }

        public int NumComponentsX { get; set; } = 4;
        public int NumComponentsY { get; set; } = 4;

        public int CoordX { get; set; } = 694000;
        public int CoordY { get; set; } = 5333500;

        public int NativePictureResX { get; set; }
        public int NativePictureResY { get; set; }
        
        public String ServerName { get; set; } = "https://geoservices.bayern.de/wms/v2/ogc_dop80_oa.cgi?";

        public String Version { get; set; } = "1.1.1";


        public float DOPRes { get; set; } = 0.8f;

        //Resulting URL String
        public String URL { get; set; }

        //Bottom left corner
        private int BL_X { get; set; }
        private int BL_Y { get; set; }

        //Upper right corner
        private int UR_X { get; set; }
        private int UR_Y { get; set; }

        public void UpdateValues()
        {
            CalcComponentSize();
            CalcNativePictureResolution();
            CalcBBox();
            UpdateURL();
        }

        private void UpdateURL()
        {
            URL = "https://geoservices.bayern.de/wms/v2/ogc_dop80_oa.cgi?";
            URL += "&SERVICE=WMS&REQUEST=GetMap&FORMAT=image/png&TRANSPARENT=TRUE&STYLES=default";

            //Version
            URL += "&VERSION=" + Version;

            URL += "&WIDTH=2048&HEIGHT=2048&SRS=EPSG:25832";
            //URL += "&WIDTH=" + NativePictureResX + "&HEIGHT=" + NativePictureResY + "&SRS=EPSG:25832";

            URL += "&BBOX=" + BL_X.ToString("F", CultureInfo.InvariantCulture) + "," + BL_Y.ToString("F", CultureInfo.InvariantCulture) + "," + UR_X.ToString("F", CultureInfo.InvariantCulture) + "," + UR_Y.ToString("F", CultureInfo.InvariantCulture);//691960.00,5331460.00,696040.00,5335540.00";

            URL += "&LAYERS=by_dop80c";
        }

        private void CalcNativePictureResolution()
        {
            //To Int correct?
            NativePictureResX = (int)(CompSizeX / DOPRes);
            NativePictureResY = (int)(CompSizeY / DOPRes);
        }

        private void CalcComponentSize()
        {
            CompSizeX = (LorX - 1) / NumComponentsX;
            CompSizeY = (LorY - 1) / NumComponentsY;
        }

        private void CalcBBox()
        {
            BL_X = CoordX - (LorX - 1) / 2;
            BL_Y = CoordY - (LorY - 1) / 2;

            UR_X = CoordX + (LorX - 1) / 2;
            UR_Y = CoordY + (LorY - 1) / 2;

        }
    }
}
