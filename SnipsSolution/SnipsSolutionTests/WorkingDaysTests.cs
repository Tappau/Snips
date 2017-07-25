using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnipsSolution;

namespace SnipsSolutionTests
{
    [TestClass()]
    public class WorkingDaysTests
    {
       

        [TestMethod]
        public void AccountForHolidays()
        {
            var service = new WorkingDays();

            var from = new DateTime(2017, 8, 23);

            Assert.AreEqual(2, service.GetWorkingDays(from, new DateTime(2017, 8, 25)), "Fri - Mon = 0");

            Assert.AreEqual(3, service.GetWorkingDays(from, new DateTime(2017, 8, 29)), "Fri - Tues = 1");
        }

        [TestMethod]
        public void CalculateDaysInWorkingWeek()
        {
            var service = new WorkingDays();
            var start = new DateTime(2017, 8, 12);
            var to = new DateTime(2017, 8, 16);

            Assert.AreEqual(4, service.GetWorkingDays(start, to), "Fri - Fri = 5");
            Assert.AreEqual(1, service.GetWorkingDays(start, new DateTime(2017, 8, 13)), "Mon - Tues =1");
        }

        [TestMethod]
        public void NotIncludeWeekends()
        {
            var service = new WorkingDays();

            var from = new DateTime(2017, 8, 9);
            var to = new DateTime(2017, 8, 16);

            Assert.AreEqual(5, service.GetWorkingDays(from, to), "Fri - Fri = 5");

            Assert.AreEqual(2, service.GetWorkingDays(from, new DateTime(2017, 8, 13)), "Fri - Tues = 2");
            Assert.AreEqual(1, service.GetWorkingDays(from, new DateTime(2017, 8, 12)), "Fri - Mon = 1");
        }

        [TestMethod]
        public void SameDayIsZero()
        {
            var service = new WorkingDays();
            var begin = new DateTime(2017, 8, 12);

            Assert.AreEqual(0, service.GetWorkingDays(begin, begin));
        }
    }
}