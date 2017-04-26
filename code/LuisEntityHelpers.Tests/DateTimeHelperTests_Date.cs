// <copyright file="DateTimeHelperTests_Date.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class DateTimeHelperTests_Date
    {
        [TestMethod]
        public void Monday_ProcessedOk()
        {
            var json = "{ \"entity\": \"monday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-1\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 3, 27), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void Tuesday_ProcessedOk()
        {
            var json = "{ \"entity\": \"tuesday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-2\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 3, 28), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void Wednesday_ProcessedOk()
        {
            var json = "{ \"entity\": \"wednesday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-3\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 3, 29), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void Thursday_ProcessedOk()
        {
            var json = "{ \"entity\": \"thursday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-4\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 3, 30), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void Friday_ProcessedOk()
        {
            var json = "{ \"entity\": \"friday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-5\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 3, 31), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void Saturday_ProcessedOk()
        {
            var json = "{ \"entity\": \"saturday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-6\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 4, 1), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void Sunday_ProcessedOk()
        {
            var json = "{ \"entity\": \"sunday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-7\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 4, 2), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void IfResolutionTypeIsDate_StartAndEndTimesAlsoSet_SoCanBeUsedLikeARange()
        {
            var json = "{ \"entity\": \"sunday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-7\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)), // A sunday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            var expectedDate = new DateTime(2017, 4, 2);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(expectedDate, resp.DateTime.Value.Date);
            Assert.AreEqual(expectedDate.Date.Add(DateTimeHelperSettings.Default.StartOfDay.TimeOfDay), resp.StartTime);
            Assert.AreEqual(expectedDate.Date.Add(DateTimeHelperSettings.Default.EndOfDay.TimeOfDay), resp.EndTime);
        }
    }
}
