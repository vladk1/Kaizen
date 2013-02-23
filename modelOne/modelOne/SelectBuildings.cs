using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace modelOne
{
    class SelectBuildings
    {
         double[] finalArray;
         double[][] output;

        double[][] order_distance_array = new double[5][];

         public double[] sortArray(int order, Geolocator sender, PositionChangedEventArgs args)
        {
            double[][] inputArray;
            
            inputArray = new double[5][];
             output = new double[5][];
            finalArray = new double[5];
           
            inputArray = arrayOfDistances(sender, args);

            for (int counter = 0; counter < 5; counter++)
            {
                finalArray[counter] = inputArray[counter][1];
            }

            quickSort(finalArray, 0, finalArray.Length);

            for (int counter = 0; counter < 5; counter++)
            {
                for (int counter2 = 0; counter2 < 5; counter2++)
                {
                    if (finalArray[counter] == inputArray[counter2][1]) output[counter] = inputArray[counter2];

                }

            }

                //finalArray =
                return output[order];
        }



         private void quickSort(double[] finalArray, int left, int right)
         {
            //static void QuickSort(int[] data, int left 0, int right length - 1)
//{
             //int left =0;
             //int right = finalArray.Length - 1;

    int i = left - 1,
        j = right;

    while (true)
    {
        double d = finalArray[left];
        do i++; while (finalArray[i] < d);
        do j--; while (finalArray[j] > d);

        if (i < j) 
        {
            double tmp = finalArray[i];
            finalArray[i] = finalArray[j];
            finalArray[j] = tmp;
        }
        else
        {
            if (left < j)    quickSort(finalArray, left, j);
            if (++j < right) quickSort(finalArray, j, right);
            return;
        }
    }
}

         

        // from getAudioGeoPosition
         private double[][] arrayOfDistances(Geolocator sender, PositionChangedEventArgs args)
    {
        double[][] four_geoPoints;
        
        double[] order_distance;

        four_geoPoints = new double[4][];
        

            getAudioGeoPosition getAudioPosition = new getAudioGeoPosition();

            for (int songNumber = 0; songNumber < 5; songNumber++)
            {
                four_geoPoints = getAudioPosition.getFourGeoPoints(songNumber+1);
                order_distance = new double[2];
                order_distance[0] = songNumber;
                order_distance[1] = findDistance(sender, args, findMidPoint(four_geoPoints));

                order_distance_array[songNumber] = order_distance; 
            }

            return order_distance_array;
    }


         private double[] findMidPoint(double[][] four_geoPoints)
         {
             double[] midPoint;
             midPoint = new double[2];
             //for (int counter = 0; counter<3; counter++) // need only 3 points actually
             //{
             midPoint[0] = (four_geoPoints[1][0] + four_geoPoints[2][0]) / 2;
             midPoint[1] = (four_geoPoints[1][1] + four_geoPoints[2][1]) / 2;
            // }
             return midPoint;
         }

         private double findDistance(Geolocator sender, PositionChangedEventArgs args, double[] midPoint)
         {
             double midPointLati = midPoint[0]*Math.PI / 180.0;
             //double midPointLati = midPoint[0] * Math.PI / 180.0;
             double midPointLongi = midPoint[1] * Math.PI / 180.0;
             double userLati = args.Position.Coordinate.Latitude * Math.PI / 180.0;
             double userLongi = args.Position.Coordinate.Longitude * Math.PI / 180.0;

             double a,c,d;
             double R = 6371000.00;
             a = Math.Pow(Math.Sin(midPointLati - userLati)/2,2) + Math.Cos(midPointLati) * Math.Cos(userLati) *  Math.Pow( Math.Sin(midPointLati - userLati)/2,2);
             c = 2 * Math.Atan2(Math.Sqrt(a),Math.Sqrt(1 - a));
             d = R * c;

             return d;
         }

    }
}
