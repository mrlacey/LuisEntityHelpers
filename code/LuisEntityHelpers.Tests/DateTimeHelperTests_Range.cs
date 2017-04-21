// <copyright file="DateTimeHelperTests_Range.cs" company="Matt Lacey">
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
    public class DateTimeHelperTests_Range
    {
        [TestMethod]
        public void WeekendOfDate_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""weekend of april 1"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-W13-WE"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 04, 01, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 04, 02, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void WeekOfDate_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""week of april 1"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""comment"": ""weekof"", ""date"": ""XXXX-04-01"" } }";

            var settings = new DateTimeHelperSettings { Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 25)) };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 27, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 04, 02, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void NextWeek_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""next week"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-W14"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 04, 03, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 04, 09, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void NextWeek_WithCustomStartOfWeekSetting_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""next week"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-W14"" } }";

            var settings = new DateTimeHelperSettings
            {
                StartOfWeek = DayOfWeek.Saturday
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 04, 15, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 04, 21, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void NextMonth_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""next month"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-04"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 04, 01, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 04, 30, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void NextYear_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""next year"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2018"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2018, 01, 01, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2018, 12, 31, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void FirstWeekOfJanuary_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""first week of january"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""XXXX-01-W01"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 27)),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 01, 02, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 01, 08, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void SecondWeekOfJune_ProcessedCorrectly()
        {
            var json = @" { ""entity"": ""second week of june"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""XXXX-06-W02"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 3, 27)),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 06, 5, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 06, 11, 23, 59, 59), resp.EndTime);
        }
    }
}
