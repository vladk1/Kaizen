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
                case 1:   // acdc.mp3   my home
                    geoPoint1[0] = 51.522725; //lati
                    geoPoint1[1] = -0.133362; //longi

                    geoPoint2[0] = 51.522795;
                    geoPoint2[1] = -0.132968;

                    geoPoint3[0] = 51.522381;
                    geoPoint3[1] = -0.133054;

                    geoPoint4[0] = 51.522576;
                    geoPoint4[1] = -0.132759;
                    break;

                case 2:  //acdc backinblack.mp3   roberts building

                    geoPoint1[0] = 51.522828;
                    geoPoint1[1] = -0.131967;

                    geoPoint2[0] = 51.522992;
                    geoPoint2[1] = -0.131967;

                    geoPoint3[0] = 51.522656;
                    geoPoint3[1] = -0.132289;

                    geoPoint4[0] = 51.522838;
                    geoPoint4[1] = -0.131782;

                    break;

                case 3:       //acdcFlyOnTheWall.mp3    Malet Place

                    geoPoint1[0] = 51.523180;
                    geoPoint1[1] = -0.132810;

                    geoPoint2[0] = 51.523349;
                    geoPoint2[1] = -0.132429;

                    geoPoint3[0] = 51.523022;
                    geoPoint3[1] = -0.132608;

                    geoPoint4[0] = 51.523162;
                    geoPoint4[1] = -0.132252;
                    break;


                case 4:        //acdcshoottothril.mp3  Pearson

                    geoPoint1[0] = 51.523584;
                    geoPoint1[1] = -0.134982;

                    geoPoint2[0] = 51.524849;
                    geoPoint2[1] = -0.134727;

                    geoPoint3[0] = 51.524454;
                    geoPoint3[1] = -0.134639;

                    geoPoint4[0] = 51.524552;
                    geoPoint4[1] = -0.134346;
                    break;

                case 5:
                    geoPoint1[0] = 51.523454;
                    geoPoint1[1] = -0.133089;

                    geoPoint2[0] = 51.523614;
                    geoPoint2[1] = -0.132692;

                    geoPoint3[0] = 51.523205;
                    geoPoint3[1] = -0.132890;

                    geoPoint4[0] = 51.523402;
                    geoPoint4[1] = -0.132469;
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