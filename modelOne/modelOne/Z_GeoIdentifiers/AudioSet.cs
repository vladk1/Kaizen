using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelOne
{
    class AudioSet
    {

        


        public double[][] setLocationSquareFormula(double[] geoLatiLongi1, double[] geoLatiLongi2, 
                                                                              double[] geoLatiLongi3, double[] geoLatiLongi4)
        {

     double a1 = geoLatiLongi1[0];  // 1st coordinate. Put LATI value
     double a2 = geoLatiLongi1[1];  // 1st coordinate. Put LONGI value: 
	
	 double b1 = geoLatiLongi2[0];  // 2st coordinate. Put LATI value:
	 double b2 = geoLatiLongi2[1];  // 2st coordinate. Put LONGI value:

	 double c1 = geoLatiLongi3[0];
	 double c2 = geoLatiLongi3[1];

	 double d1 = geoLatiLongi4[0];
	 double d2 = geoLatiLongi4[1];

	 double k1, k2, e1, e2, e3, e4 = 0.00;
	 

            
	 k1 = (b2-a2)/(b1-a1);
	 e1=a2-k1*a1;

	 e2=c2-k1*c1;


	 k2=(c2-a2)/(c1-a1);
	 e3=a2-k2*a1;

	 e4=b2-k2*b1;
            
       

double[][] bothValues; // input info
double[] kValues;
double[] eValues;

bothValues = new double[2][];


kValues = new double[2];
eValues = new double[4];

kValues = set_kValues(k1, k2);
eValues = set_eValues(e1,e2,e3,e4);

bothValues[0] = kValues;
bothValues[1] = eValues;

return bothValues;

        }



           private double[] set_kValues(double k1, double k2)
            {
                double[] kValues;
                kValues = new double[2];

                kValues[0] = k1;
                kValues[1] = k2;

               return kValues;
            }



           private double[] set_eValues(double e1, double e2, double e3, double e4)
           {
               double[] eValues;
               eValues = new double[4];

               eValues[0] = e1;
               eValues[1] = e2;
               eValues[2] = e3;
               eValues[3] = e4;

               return eValues;
           }



        }




    }

