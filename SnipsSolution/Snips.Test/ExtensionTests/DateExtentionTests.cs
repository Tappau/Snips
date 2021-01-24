using NUnit.Framework;
using SnipsSolution;
using SnipsSolution.Extensions;
using System;

namespace Snips.Test.ExtensionTests
{
    [TestFixture]
    public class DateExtentionTests
    {
        [TestCase("January", 1)]
        [TestCase("FEBRUARY", 2)]
        [TestCase("March", 3)]
        [TestCase("April", 4)]
        [TestCase("May", 5)]
        [TestCase("June", 6)]
        [TestCase("July", 7)]
        [TestCase("August", 8)]
        [TestCase("September", 9)]
        [TestCase("October", 10)]
        [TestCase("November", 11)]
        [TestCase("December", 12)]
        public void Test_ToMonthNumber_Lang_English(string testMonthName, int expected)
        {
            Assert.AreEqual(expected, testMonthName.ToMonthNumber());
        }

        [SetCulture("es-ES")]
        [TestCase("enero", 1)]
        [TestCase("febrero", 2)]
        [TestCase("Marzo", 3)]
        [TestCase("Abril", 4)]
        [TestCase("Mayo", 5)]
        [TestCase("junio", 6)]
        [TestCase("Julio", 7)]
        [TestCase("Agosto", 8)]
        [TestCase("Septiembre", 9)]
        [TestCase("Octubre", 10)]
        [TestCase("Noviembre", 11)]
        [TestCase("Diciembre", 12)]
        public void Test_ToMonthNumber_Lang_Spanish(string testMonthName, int expected)
        {
            Assert.AreEqual(expected, testMonthName.ToMonthNumber());
        }

        [TestCase("15/06/1962", 56)]
        [TestCase("30/11/1989", 29)]
        [SetCulture("en-GB")]
        public void Test_CalculateAge_ToCurrentDate(string testDate, int expectedResult)
        {
            using (Clock.NowIs(new DateTime(2019, 01, 01)))
            {
                Assert.AreEqual(expectedResult, DateTime.Parse(testDate).CalculateAge());
            }
        }

        [TestCase("2018-12-05", true)] //Wednesday
        [TestCase("2018-12-07", true)] //Friday
        [TestCase("2018-12-08", false)] //Saturday
        [TestCase("2018-12-09", false)]
        //Sunday
        public void Test_IsWorkingDay(DateTime testDate, bool expectedOutcome)
        {
            Assert.AreEqual(expectedOutcome, testDate.IsWorkingDay());
        }

        [TestCase("2018-12-05", false)] //Wednesday
        [TestCase("2018-12-07", false)] //Friday
        [TestCase("2018-12-08", true)] //Saturday
        [TestCase("2018-12-09", true)]
        //Sunday
        public void Test_IsWeekend(DateTime testDate, bool expected)
        {
            Assert.AreEqual(expected, testDate.IsWeekend());
        }

        [TestCase("2018-12-05", "2018-12-06")]
        [TestCase("2019-01-04", "2019-01-07")]
        [TestCase("2018-12-08", "2018-12-10")]
        public void Test_NextWorkingDay(DateTime testDate, DateTime expected)
        {
            Assert.AreEqual(expected, testDate.NextWorkDay());
        }

        [TestCase("2018-12-05", "2018-12-12", DayOfWeek.Wednesday)]
        [TestCase("2018-12-05", "2018-12-11", DayOfWeek.Tuesday)]
        [TestCase("2018-12-01", "2018-12-08", DayOfWeek.Saturday)]
        public void Test_DateOfNextDay(DateTime testDate, DateTime expected, DayOfWeek weekDay)
        {
            Assert.AreEqual(expected, testDate.GetNextDay(weekDay));
        }

        [Test]
        [SetCulture("en-GB")]
        public void Return_False_BetweenDates()
        {
            var pastDate = DateTime.Parse("15/06/2008 12:45:23");
            var futureDate = DateTime.Parse("15/06/2016 09:00:03");
            var currentDate = DateTime.Now;
            Assert.IsFalse(currentDate.Between(pastDate, futureDate));
        }

        [Test]
        [SetCulture("en-GB")]
        public void Return_False_DateTime_Is_InPast()
        {
            var futureDate = DateTime.Parse("15/06/2056 12:24:48");
            Assert.IsFalse(futureDate.IsPast());
        }

        [Test]
        [SetCulture("en-GB")]
        public void Return_False_IsDateInFuture_From_CurrentTime()
        {
            var futureDate = DateTime.Parse("15/06/1998 15:07:32");
            Assert.IsFalse(futureDate.IsFuture());
        }

        [Test]
        [SetCulture("en-GB")]
        public void Return_True_BetweenDates()
        {
            var pastDate = DateTime.Parse("15/06/2008 12:45:23");
            var futureDate = DateTime.Parse("15/06/2050 09:00:03");
            var currentDate = DateTime.Now;
            Assert.IsTrue(currentDate.Between(pastDate, futureDate));
        }

        [Test]
        [SetCulture("en-GB")]
        public void Return_True_DateTime_Is_InPast()
        {
            var pastDate = DateTime.Parse("15/06/1998 12:24:48");
            Assert.IsTrue(pastDate.IsPast());
        }

        [Test]
        [SetCulture("en-GB")]
        public void Returns_True_IsDateInFuture_From_CurrentTime()
        {
            var futureDate = DateTime.Parse("15/05/2056 15:26:43");
            Assert.IsTrue(futureDate.IsFuture());
        }

        [TestCase("2018-12-01", "1st")]
        [TestCase("2018-12-02", "2nd")]
        [TestCase("2018-12-03", "3rd")]
        [TestCase("2018-12-04", "4th")]
        [TestCase("2018-12-21", "21st")]
        [TestCase("2018-12-22", "22nd")]
        [TestCase("2018-12-23", "23rd")]
        [TestCase("2018-12-18", "18th")]
        public void Test_OrdinalSuffix(DateTime testDate, string expected)
        {
            Assert.AreEqual(expected, testDate.OrdinalSuffix());
        }


        [TestCase("2019-01-14 11:00:00", "an hour ago")]
        [TestCase("2019-01-14 10:00:00", "2 hours ago")]
        [TestCase("2019-01-14 11:59:59", "one second ago")]
        [TestCase("2019-01-14 11:59:55", "5 seconds ago")]
        [TestCase("2019-01-14 11:59:00", "a minute ago")]
        [TestCase("2019-01-14 11:55:00", "5 minutes ago")]
        [TestCase("2019-01-13 12:00:00", "yesterday")]
        [TestCase("2019-01-12 12:00:00", "2 days ago")]
        [TestCase("2018-12-14 12:00:00", "one month ago")]
        [TestCase("2018-11-14 12:00:00", "2 months ago")]
        [TestCase("2018-01-14 12:00:00", "one year ago")]
        [TestCase("2009-01-14 12:00:00", "10 years ago")]
        public void Test_ToReadableTime(DateTime testDate, string expected)
        {
            using (Clock.UtcNowIs(new DateTime(2019, 01, 14, 12, 0, 0)))
            {
                var result = testDate.ToReadableTime();
                Assert.AreEqual(expected, result);
            }
        }
    }
}