using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace modelOne
{
    class AudioGet
    {
        public int getLocationCheck(Geolocator sender, PositionChangedEventArgs args, double[][] geoCoordinateCode)
        {
            double[][] bothValues;
            double[] kValues;
            double[] eValues;

            int decision; // we will return decision which consist from <in\out> variable and <mediaNumberOptions> variable which decides about
            // next song to play


            bothValues = new double[1][];
            kValues = new double[1];
            eValues = new double[4];



            kValues = geoCoordinateCode[0];
            eValues = geoCoordinateCode[1];



            decision = In_or_Out(sender, args, kValues, eValues);


            return decision;


        }



        private int In_or_Out(Geolocator sender, PositionChangedEventArgs args, double[] kValues, double[] eValues)
        {

            // no we will have real current position
            double t1 = args.Position.Coordinate.Latitude; //lati 
            double t2 = args.Position.Coordinate.Longitude; //longi

            int decision = 0;

            double v1 = 0.00;
            double v2 = 0.00;


            double k1, k2, e1, e2, e3, e4;

            k1 = kValues[0];
            k2 = kValues[1];

            e1 = eValues[0];
            e2 = eValues[1];
            e3 = eValues[2];
            e4 = eValues[3];



            double e1Copy = 0.00;
            double e2Copy = 0.00;


            v1 = t2 - k1 * t1;


            bool boolCounter = true;
            int counter = 0;
            while (boolCounter)
            {
                if (e2 > e1)
                {
                    e1Copy = e2;
                    e2Copy = e1;
                    counter += checkValidity(v1, e1Copy, e2Copy);
                    if (counter == 2)
                    {
                        //in
                        decision = 1;
                        boolCounter = false;
                    }

                    if (counter > 2)
                    {
                        //out
                        decision = 0;
                        boolCounter = false;
                    }
                    e1 = e3;
                    e2 = e4;
                    v1 = t2 - k2 * t1;
                }
                else
                {
                    e2Copy = e2;
                    e1Copy = e1;
                    counter += checkValidity(v1, e1Copy, e2Copy);
                    if (counter == 2)
                    {
                        //in
                        decision = 1;
                        boolCounter = false;
                    }

                    if (counter > 2)
                    {
                        //out
                        decision = 0;
                        boolCounter = false;
                    }
                    e1 = e3;
                    e2 = e4;
                    v1 = t2 - k2 * t1;
                }

            }

            return decision;
        }

        private int checkValidity(double v1, double e1Copy, double e2Copy)
        {


            if ((v1 <= e1Copy) && (v1 >= e2Copy)) return 1;

            else return 3;



        }




    }
}
