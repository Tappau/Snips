using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnipsSolution
{
   public class Temperatures
    {
       private const double Kelvin = 273.15;

       public enum Measurement
        {
            Fahrenheit,
            Celsius,
            Kelvin
        }
       private  double CelsiusToFahrenheit(double celsius)
       {
           return ((9.0/5.0)*celsius) + 32;
       }

       private static double FahrenheitToCelsius(double fahrenheit)
       {
           return (5.0/9.0)*(fahrenheit - 32);
       }



       public double ToKelvin(double num, Measurement convertFrom)
       {
            double result = 0.0;

           if (Equals(convertFrom,  Measurement.Celsius))
           {
               if (num <= 0.0)
               {
                   result = Kelvin - num;
               }else if (num > 0.0)
               {
                   result = num + Kelvin;
               }
           }

           if (Equals(convertFrom, Measurement.Fahrenheit))
           {
                if (num <= 0.0)
                {
                    result = Kelvin - FahrenheitToCelsius(num);
                }
                if (num > 0.0)
                {
                    result = FahrenheitToCelsius(num) + Kelvin;
                }
            }

           return result;
       }


       public double ToCelsius(double input, Measurement convertFrom)
       {
            var result = 0.0;
            
            if (Equals(convertFrom, Measurement.Fahrenheit))
            {
                //Convert FahrenHeit to Celsius
                    result = FahrenheitToCelsius(input);
                
            }
            if (Equals(convertFrom, Measurement.Kelvin))
            {
                //Convert Kelvin to Celsius
                result = input - Kelvin;
            }

            return result;
        }

       public double ToFahrenHeit(double input, Measurement convertFrom)
       {
           var result = 0.0;

           if (Equals(convertFrom, Measurement.Celsius))
           {
                //Celsius to Fahrenheit
               result = CelsiusToFahrenheit(input);
           }
           if (Equals(convertFrom, Measurement.Kelvin))
           {
                //Kelvin to Fahrenheit
               result = 1.8*(input - Kelvin) + 32;
           }

           return result;
           
       }
    }
}
