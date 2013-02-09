using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelOne.GeocodeService;
using modelOne.SearchService;
using modelOne.ImageryService;
using modelOne.RouteService;

namespace modelOne
{
    class getAudioGeoPosition
    {

        public double[][] getFourGeoPoints(int songNumber)
        {
            double[][] four_geoPoints;
            four_geoPoints = new double[4][];

            double[] geoPoint1;
            double[] geoPoint2;
            double[] geoPoint3;
            double[] geoPoint4;

            geoPoint1 = new double[2];
            geoPoint2 = new double[2];
            geoPoint3 = new double[2];
            geoPoint4 = new double[2];

            switch (songNumber)
            {
                case 1:        // acdc.mp3
                    geoPoint1[0] = 51.522725; //lati
                    geoPoint1[1] = -0.133362; //longi

                    geoPoint2[0] = 51.522795;
                    geoPoint2[1] = -0.132968;

                    geoPoint3[0] = 51.522381;
                    geoPoint3[1] = -0.133054;

                    geoPoint4[0] = 51.522576;
                    geoPoint4[1] = -0.132759;
                    break;

                case 2:       //acdc backinblack.mp3

                    geoPoint1[0] = 51.522828;
                    geoPoint1[1] = -0.131967;

                    geoPoint2[0] = 51.522992;
                    geoPoint2[1] = -0.131967;

                    geoPoint3[0] = 51.522656;
                    geoPoint3[1] = -0.132289;

                    geoPoint4[0] = 51.522838;
                    geoPoint4[1] = -0.131782;

                    break;

                case 3:       //acdcFlyOnTheWall.mp3

                    geoPoint1[0] = 12;
                    geoPoint1[1] = 21;

                    geoPoint2[0] = 21;
                    geoPoint2[1] = 21;

                    geoPoint3[0] = 21;
                    geoPoint3[1] = 21;

                    geoPoint4[0] = 21;
                    geoPoint4[1] = 21;
                    break;


                case 4:        //acdcshoottothril.mp3

                    geoPoint1[0] = 12;
                    geoPoint1[1] = 21;

                    geoPoint2[0] = 21;
                    geoPoint2[1] = 21;

                    geoPoint3[0] = 21;
                    geoPoint3[1] = 21;

                    geoPoint4[0] = 21;
                    geoPoint4[1] = 21;
                    break;

            }

            four_geoPoints[0] = geoPoint1;
            four_geoPoints[1] = geoPoint2;
            four_geoPoints[2] = geoPoint3;
            four_geoPoints[3] = geoPoint4;


            return four_geoPoints;
        }
    }

}