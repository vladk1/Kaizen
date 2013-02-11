using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace modelOne
{
    class LocationCheck
    {

        public void startAnalysis(Geolocator sender, PositionChangedEventArgs args)
        {
            double[] geoPoint1;
            double[] geoPoint2;
            double[] geoPoint3;
            double[] geoPoint4;


            double[][] four_geoPoints;
            four_geoPoints = new double[4][];

            geoPoint1 = new double[2];
            geoPoint2 = new double[2];
            geoPoint3 = new double[2];
            geoPoint4 = new double[2];




            // 4 points algorithm usage 
            double[][] geoCoordinateCode;
            geoCoordinateCode = new double[2][];

            AudioSet setSong = new AudioSet();
            getAudioGeoPosition getAudioGeoPoint = new getAudioGeoPosition();

            int songNumber = 1;
            int exitLoop = 0; //depends if the song starting playing in checkCoordinates function


            while ((songNumber < 2) && (exitLoop != 1)) // check location for each songNumber 
            {
                four_geoPoints = getAudioGeoPoint.getFourGeoPoints(songNumber); // for each song (represented in songNumber) read its coordinates

                geoPoint1 = four_geoPoints[0]; // takes 4 geoPoints with (lati,longi) coordinates
                geoPoint2 = four_geoPoints[1];
                geoPoint3 = four_geoPoints[2];
                geoPoint4 = four_geoPoints[3];

                // getting particular variables, which will give criteria of geoLocation comparison
                geoCoordinateCode = setSong.setLocationSquareFormula(geoPoint1, geoPoint2, geoPoint3, geoPoint4);

                CheckGeoToPlayMusic checkUser = new CheckGeoToPlayMusic();
                exitLoop = checkUser.checkCoordinates(sender, args, geoCoordinateCode, songNumber);

                songNumber++;
            }
        }

    }
}
