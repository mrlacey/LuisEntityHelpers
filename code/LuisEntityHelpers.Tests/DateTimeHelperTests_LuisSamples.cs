// <copyright file="DateTimeHelperTests_LuisSamples.cs" company="Matt Lacey">
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
    public class DateTimeHelperTests_LuisSamples
    {
        [TestMethod]
        public void SampleResponse01_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.date\", \"entity\": \"tomorrow\", \"resolution\": {\"date\": \"2015-08-15\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 15), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void SampleResponse02_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.date\", \"entity\": \"january 10 2009\", \"resolution\": {\"date\": \"2009-01-10\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2009, 1, 10), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void SampleResponse03_ProcessedOk()
        {
            var json = "{ \"entity\": \"monday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"XXXX-WXX-1\"} }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 26)),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 3, 27), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void SampleResponse04_ProcessedOk()
        {
            var json = "{ \"entity\": \"next week\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"2015-W34\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 17, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2015, 8, 23, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void SampleResponse05_ProcessedOk()
        {
            var json = "{ \"entity\": \"next monday\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"date\": \"2015-08-17\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 17), resp.DateTime.Value.Date);
        }

        [TestMethod]
        public void SampleResponse06_ProcessedOk()
        {
            var json = "{ \"entity\": \"week of september 30th\", \"type\": \"builtin.datetime.date\", \"resolution\": {\"comment\": \"weekof\", \"date\": \"XXXX-09-30\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 9, 25, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 10, 1, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void SampleResponse07_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.time\", \"entity\": \"3 : 00\", \"resolution\": {\"comment\": \"ampm\", \"time\": \"T03:00\"} }";
            var expectedDt = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, 3, 00, 00);

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Time, resp.ResolutionType);
            Assert.AreEqual(expectedDt, resp.DateTime);
        }

        [TestMethod]
        public void SampleResponse08_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.time\", \"entity\": \"4 pm\", \"resolution\": {\"time\": \"T16\"} }";
            var expectedDt = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, 16, 00, 00);

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Time, resp.ResolutionType);
            Assert.AreEqual(expectedDt, resp.DateTime.Value);
        }

        [TestMethod]
        public void SampleResponse09_ProcessedOk()
        {
            var json = "{ \"entity\": \"tomorrow morning\", \"type\": \"builtin.datetime.time\", \"resolution\": {\"time\": \"2015-08-15TMO\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 15, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2015, 8, 15, 12, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void SampleResponse10_ProcessedOk()
        {
            var json = "{ \"entity\": \"tonight\", \"type\": \"builtin.datetime.time\", \"resolution\": {\"time\": \"2015-08-14TNI\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 14, 19, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2015, 8, 14, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void SampleResponse11_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.duration\", \"entity\": \"3 hours\", \"resolution\": {\"duration\": \"PT3H\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Duration, resp.ResolutionType);
            Assert.AreEqual(new TimeSpan(3, 0, 0), resp.Duration);
        }

        [TestMethod]
        public void SampleResponse12_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.duration\", \"entity\": \"30 minutes\", \"resolution\": {\"duration\": \"PT30M\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Duration, resp.ResolutionType);
            Assert.AreEqual(new TimeSpan(0, 30, 0), resp.Duration);
        }

        [TestMethod]
        public void SampleResponse13_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.duration\", \"entity\": \"all day\", \"resolution\": {\"duration\": \"P1D\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Duration, resp.ResolutionType);
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), resp.Duration);
        }

        [TestMethod]
        public void SampleResponse14_ProcessedOk()
        {
            var json = "{ \"type\": \"builtin.datetime.set\", \"entity\": \"daily\", \"resolution\": { \"time\": \"XXXX-XX-XX\"} }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Unsupported, resp.ResolutionType);
        }
    }
}
