using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandscapeAppWebsite.Models
{
    public class RequestManager
    {
        public int LorX { get; set; }
        public int LorY { get; set; }

        public int CompSizeX { get; set; }

        public int CompSizeY { get; set; }

        public int NumComponentsX { get; set; }

        public int NumComponentsY { get; set; }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public String ServerName { get; set; }

        public String Version { get; set; }

        public int NativePictureResX { get; set; }

        public int NativePictureResY { get; set; }

        public float DOPRes { get; set; }

        public void UpdateValues()
        {
            CalcComponentSize();
            CalcNativePictureResolution();
            UpdateURLParts();
        }

        private void UpdateURLParts()
        {
           
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
    }
}
