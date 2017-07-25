using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SnipsSolution;

namespace Snips.Test
{
    [TestFixture]
    public class TemperatureTests
    {
        [Test]
        public void Celsius_To_Fahrenheit()
        {
            var service = new Temperatures();
            Assert.AreEqual(212, service.ToFahrenHeit(100, convertFrom: Temperatures.Measurement.Celsius), "100 C == 212 F");
            Assert.AreEqual(74.66, service.ToFahrenHeit(23.7, convertFrom: Temperatures.Measurement.Celsius), "23.7 C == 74.66 F" );
            }

        [Test]
        public void Celsius_To_Kelvin()
        {
            var service = new Temperatures();
            Assert.AreEqual(373.15, service.ToKelvin(100, Temperatures.Measurement.Celsius), "100 C == 373.15 K");
            Assert.AreEqual(265.15, service.ToKelvin(-8, Temperatures.Measurement.Celsius),"-8 C == 265.15 K");
        }

        [Test]
        public void Fahrenhiet_To_Celsius()
        {
            var service = new Temperatures();
            Assert.AreEqual(-4.61, service.ToCelsius(23.7, convertFrom: Temperatures.Measurement.Fahrenheit), "23.7 F == -4.66 C");
            Assert.AreEqual(37.78, service.ToCelsius(100, convertFrom: Temperatures.Measurement.Fahrenheit), "100 F == 37.78 C");
        }

        [Test]
        public void Fahrenheit_To_Kelvin()
        {
            var service = new Temperatures();
            Assert.AreEqual(310.93, service.ToKelvin(100, Temperatures.Measurement.Fahrenheit));
        }

        [Test]
        public void Kelvin_To_Celsius()
        {
            var service = new Temperatures();
            Assert.AreEqual(-173.15, service.ToCelsius(100, Temperatures.Measurement.Kelvin));
            Assert.AreEqual(404.85,service.ToCelsius(678, Temperatures.Measurement.Kelvin));
        }

        [Test]
        public void Kelvin_To_Fahrenheit()
        {
            var service = new Temperatures();
            Assert.AreEqual(1120.73, service.ToFahrenHeit(878, Temperatures.Measurement.Kelvin), "878 F == 1120.73 K");
            Assert.AreEqual(-1874.47, service.ToFahrenHeit(-786, Temperatures.Measurement.Kelvin),"-786 K == -1874.47 F");
        }

    }
}
