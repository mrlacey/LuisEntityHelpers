// <copyright file="DateTimeHelperTests_WeekNumberCalculator.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public class DateTimeHelperTests_WeekNumberCalculator
    {
        [TestMethod]
        public void Y2010_W01_Jan4()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2010, 01, 4, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2010, 1));
        }

        [TestMethod]
        public void Y2011_W01_Jan3()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2011, 01, 3, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2011, 1));
        }

        [TestMethod]
        public void Y2012_W01_Jan2()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2012, 01, 2, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2012, 1));
        }

        [TestMethod]
        public void Y2013_W01_Dec31()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2012, 12, 31, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2013, 1));
        }

        [TestMethod]
        public void Y2014_W01_Dec30()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2013, 12, 30, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2014, 1));
        }

        [TestMethod]
        public void Y2015_W01_Dec29()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2014, 12, 29, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2015, 1));
        }

        [TestMethod]
        public void Y2016_W01_Jan4()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2016, 01, 4, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2016, 1));
        }

        [TestMethod]
        public void Y2016_W52_Dec26()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2016, 12, 26, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2016, 52));
        }

        [TestMethod]
        public void Y2017_W01_January2()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2017, 01, 2, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2017, 1));
        }

        [TestMethod]
        public void Y2017_W13_March27()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2017, 03, 27, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2017, 13));
        }

        [TestMethod]
        public void Y2018_W01_January1()
        {
            var sut = new DateTimeHelper();

            Assert.AreEqual(new DateTime(2018, 01, 1, 00, 00, 00), sut.GetFirstDayOfFirstWeek(2018, 1));
        }
    }
}
