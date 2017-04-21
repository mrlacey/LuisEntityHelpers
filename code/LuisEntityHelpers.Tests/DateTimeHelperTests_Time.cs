// <copyright file="DateTimeHelperTests_Time.cs" company="Matt Lacey">
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
    public class DateTimeHelperTests_Time
    {
        [TestMethod]
        public void MidnightToday_ProcessedOk()
        {
            var json = @"{ ""entity"": ""midnight"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25T00"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.DateAndTime, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 00, 00, 00), resp.DateTime);
        }

        [TestMethod]
        public void MorningToday_ProcessedOk()
        {
            var json = @"{ ""entity"": ""morning"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25TMO"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.MorningStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.MorningEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void MiddayToday_ProcessedOk()
        {
            var json = @"{ ""entity"": ""midday"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25TMI"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.DateAndTime, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 12, 00, 00), resp.DateTime);
        }

        [TestMethod]
        public void NoonToday_ProcessedOk()
        {
            var json = @"{ ""entity"": ""noon"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25T12"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.DateAndTime, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 12, 00, 00), resp.DateTime);
        }

        [TestMethod]
        public void AfternoonToday_ProcessedOk()
        {
            var json14 =
                @"{ ""entity"": ""afternoon"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25TAF"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json14);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.AfternoonStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.AfternoonEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void EveningToday_ProcessedOk()
        {
            var json = @"{ ""entity"": ""evening"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25TEV"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.EveningStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.EveningEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void NightToday_ProcessedOk()
        {
            var json = @"{ ""entity"": ""night"", ""type"": ""builtin.datetime.time"", ""startIndex"": 22, ""endIndex"": 27, ""resolution"": { ""time"": ""2017-03-25TNI"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.NightStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(DateTimeHelperSettings.Default.NightEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void Morning_WithCustomSettings_ProcessedOk()
        {
            var json = @"{ ""entity"": ""morning"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TMO"" } }";

            var settings = new DateTimeHelperSettings
            {
                MorningStartTime = DateTime.Parse("07:43:23"),
                MorningEndTime = DateTime.Parse("11:56:58"),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.MorningStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.MorningEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void Afternoon_WithCustomSettings_ProcessedOk()
        {
            var json = @"{ ""entity"": ""afternoon"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TAF"" } }";

            var settings = new DateTimeHelperSettings
            {
                AfternoonStartTime = DateTime.Parse("13:37:23"),
                AfternoonEndTime = DateTime.Parse("17:29:59"),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.AfternoonStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.AfternoonEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void Evening_WithCustomSettings_ProcessedOk()
        {
            var json = @"{ ""entity"": ""evening"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TEV"" } }";

            var settings = new DateTimeHelperSettings
            {
                EveningStartTime = DateTime.Parse("18:25:18"),
                EveningEndTime = DateTime.Parse("19:49:59"),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.EveningStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.EveningEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void Night_WithCustomSettings_ProcessedOk()
        {
            var json = @"{ ""entity"": ""night"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TNI"" } }";

            var settings = new DateTimeHelperSettings
            {
                NightStartTime = DateTime.Parse("21:14:27"),
                NightEndTime = DateTime.Parse("23:46:26"),
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.NightStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25).Add(settings.NightEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void Morning_WithoutDate_ProcessedOk()
        {
            var json = @"{ ""entity"": ""half four in the morning"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""TMO"" } }";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(DateTime.MinValue.Add(DateTimeHelperSettings.Default.MorningStartTime.TimeOfDay), resp.StartTime);
            Assert.AreEqual(DateTime.MinValue.Add(DateTimeHelperSettings.Default.MorningEndTime.TimeOfDay), resp.EndTime);
        }

        [TestMethod]
        public void AssumeMorning_IfTimeOfDayNotSpecified()
        {
            var json = "{ \"type\": \"builtin.datetime.time\", \"entity\": \"3 : 00\", \"resolution\": {\"comment\": \"ampm\", \"time\": \"T03:00\"} }";
            var expectedDt = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, 3, 00, 00);

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Time, resp.ResolutionType);
            Assert.AreEqual(expectedDt, resp.DateTime);
        }

        [TestMethod]
        public void SettingsCanOverride_AssumeAfternoon_IfTimeOfDayNotSpecified()
        {
            var json = "{ \"type\": \"builtin.datetime.time\", \"entity\": \"3 : 00\", \"resolution\": {\"comment\": \"ampm\", \"time\": \"T03:00\"} }";
            var expectedDt = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, 15, 00, 00);

            var settings = new DateTimeHelperSettings
            {
                PresumeTimeIsPmIfNotClear = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Time, resp.ResolutionType);
            Assert.AreEqual(expectedDt, resp.DateTime);
        }

        [TestMethod]
        public void Afternoon_CanEndNextDay()
        {
            var json = @"{ ""entity"": ""afternoon"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TAF"" } }";

            var settings = new DateTimeHelperSettings
            {
                AfternoonStartTime = DateTime.Parse("11:59"),
                AfternoonEndTime = DateTime.Parse("00:00"),
                AfternoonEndTimeIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 11, 59, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 26, 00, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Evening_CanEndNextDay()
        {
            var json = @"{ ""entity"": ""evening"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TEV"" } }";

            var settings = new DateTimeHelperSettings
            {
                EveningStartTime = DateTime.Parse("18:00"),
                EveningEndTime = DateTime.Parse("01:00"),
                EveningEndTimeIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 18, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 26, 01, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Night_CanEndNextDay()
        {
            var json = @"{ ""entity"": ""night"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TNI"" } }";

            var settings = new DateTimeHelperSettings
            {
                NightStartTime = DateTime.Parse("18:00"),
                NightEndTime = DateTime.Parse("02:00"),
                NightEndTimeIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 18, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 26, 02, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Day_CanEndNextDay()
        {
            var json = "{ \"type\": \"builtin.datetime.date\", \"entity\": \"tomorrow\", \"resolution\": {\"date\": \"2015-08-15\"} }";

            // This is what a nightclubs day may look like
            // A day starts at 4am and runs until 6am the following day
            var settings = new DateTimeHelperSettings
            {
                StartOfDay = DateTime.Parse("04:00"),
                EndOfDay = DateTime.Parse("06:00"),
                EndOfDayIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 15, 04, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2015, 8, 16, 06, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Day_CanStartAndEndAtMidnight()
        {
            var json = "{ \"type\": \"builtin.datetime.date\", \"entity\": \"tomorrow\", \"resolution\": {\"date\": \"2015-08-15\"} }";

            var settings = new DateTimeHelperSettings
            {
                StartOfDay = DateTime.Parse("00:00"),
                EndOfDay = DateTime.Parse("00:00"),
                EndOfDayIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2015, 8, 15, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2015, 8, 16, 00, 00, 00), resp.EndTime);
        }
    }
}
