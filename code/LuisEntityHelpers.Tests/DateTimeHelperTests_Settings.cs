// <copyright file="DateTimeHelperTests_Settings.cs" company="Matt Lacey">
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
    public class DateTimeHelperTests_Settings
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StartOfDayAfterEndOfDay_Throws()
        {
            var settings = new DateTimeHelperSettings
            {
                StartOfDay = DateTime.Parse("19:00"),
                EndOfDay = DateTime.Parse("13:00"),
            };

            var sut = new DateTimeHelper(settings);
        }

        [TestMethod]
        public void StartOfDayAfterEndOfDay_IsFine_IfEndOfDayIsNextDay()
        {
            var settings = new DateTimeHelperSettings
            {
                StartOfDay = DateTime.Parse("19:00"),
                EndOfDay = DateTime.Parse("13:00"),
                EndOfDayIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            Assert.IsTrue(true); // Really just testing that no error on line above
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Morning_StartTimeAfterEndTime_Throws()
        {
            var settings = new DateTimeHelperSettings
            {
                MorningStartTime = DateTime.Parse("10:00"),
                MorningEndTime = DateTime.Parse("09:00"),
            };

            var sut = new DateTimeHelper(settings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Afternoon_StartTimeAfterEndTime_Throws()
        {
            var settings = new DateTimeHelperSettings
            {
                AfternoonStartTime = DateTime.Parse("17:00"),
                AfternoonEndTime = DateTime.Parse("14:00"),
            };

            var sut = new DateTimeHelper(settings);
        }

        [TestMethod]
        public void Afternoon_StartTimeAfterEndTime_IsFine_IfEndOfDayIsNextDay()
        {
            var settings = new DateTimeHelperSettings
            {
                AfternoonStartTime = DateTime.Parse("17:00"),
                AfternoonEndTime = DateTime.Parse("14:00"),
                AfternoonEndTimeIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);

            Assert.IsTrue(true); // Really just testing that no error on line above
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Evening_StartTimeAfterEndTime_Throws()
        {
            var settings = new DateTimeHelperSettings
            {
                EveningStartTime = DateTime.Parse("21:00"),
                EveningEndTime = DateTime.Parse("20:00"),
            };

            var sut = new DateTimeHelper(settings);
        }

        [TestMethod]
        public void Evening_StartTimeAfterEndTime_IsFine_IfEndOfDayIsNextDay()
        {
            var settings = new DateTimeHelperSettings
            {
                EveningStartTime = DateTime.Parse("21:00"),
                EveningEndTime = DateTime.Parse("20:00"),
                EveningEndTimeIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);
            Assert.IsTrue(true); // Really just testing that no error on line above
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Night_StartTimeAfterEndTime_Throws()
        {
            var settings = new DateTimeHelperSettings
            {
                NightStartTime = DateTime.Parse("23:00"),
                NightEndTime = DateTime.Parse("22:00"),
            };

            var sut = new DateTimeHelper(settings);
        }

        [TestMethod]
        public void Night_StartTimeAfterEndTime_IsFine_IfEndOfDayIsNextDay()
        {
            var settings = new DateTimeHelperSettings
            {
                NightStartTime = DateTime.Parse("23:00"),
                NightEndTime = DateTime.Parse("22:00"),
                NightEndTimeIsNextDay = true,
            };

            var sut = new DateTimeHelper(settings);
            Assert.IsTrue(true); // Really just testing that no error on line above
        }

        [TestMethod]
        public void Morning_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""morning"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TMO"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 10, 00, 00)),
                MorningStartTime = DateTime.Parse("08:00"),
                MorningEndTime = DateTime.Parse("12:00"),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 10, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25, 12, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Afternoon_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""afternoon"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TAF"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 15, 00, 00)),
                AfternoonStartTime = DateTime.Parse("11:59"),
                AfternoonEndTime = DateTime.Parse("18:00"),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 15, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25, 18, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Evening_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""evening"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TEV"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 19, 00, 00)),
                EveningStartTime = DateTime.Parse("17:00"),
                EveningEndTime = DateTime.Parse("21:00"),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 19, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25, 21, 00, 00), resp.EndTime);
        }

        [TestMethod]
        public void Night_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""night"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-25TNI"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 21, 00, 00)),
                NightStartTime = DateTime.Parse("19:00"),
                NightEndTime = DateTime.Parse("23:59"),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 21, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 25, 23, 59, 00), resp.EndTime);
        }

        [TestMethod]
        public void SpecificDateInPast_IsIgnored_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""night"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-02-03"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 21, 00, 00)),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.InPastSoIgnored, resp.ResolutionType);
        }

        [TestMethod]
        public void Week_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""this week"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-W13"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 27, 12, 00, 00)), // Wednesday of week 13
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 27, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 04, 02, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void WeekInPast_IsIgnored_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""first week in Jan this year"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-W01"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25)),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.InPastSoIgnored, resp.ResolutionType);
        }

        [TestMethod]
        public void MonthInPast_IsIgnored_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""February this year"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-02"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25)),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.InPastSoIgnored, resp.ResolutionType);
        }

        [TestMethod]
        public void Month_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""this month"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017-03"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 21, 00, 00)),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 03, 31, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void Year_IsIntersectedCorrectly_IfIgnoringPast()
        {
            var json = @"{ ""entity"": ""this year"", ""type"": ""builtin.datetime.date"", ""resolution"": { ""date"": ""2017"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 25, 21, 00, 00)),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.Range, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2017, 03, 25, 00, 00, 00), resp.StartTime);
            Assert.AreEqual(new DateTime(2017, 12, 31, 23, 59, 59), resp.EndTime);
        }

        [TestMethod]
        public void TimePerios_ShouldBeIgnored_IfIgnoringPast()
        {
            var json = @" { ""entity"": ""morning"", ""type"": ""builtin.datetime.time"", ""resolution"": { ""time"": ""2017-03-28TMO"" } }";

            var settings = new DateTimeHelperSettings
            {
                Time = TimeAbstraction.Create(() => new DateTime(2017, 03, 29, 12, 00, 00)),
                IgnoreThePast = true,
            };

            var sut = new DateTimeHelper(settings);

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.AreEqual(DateTimeResolutionType.InPastSoIgnored, resp.ResolutionType);
        }
    }
}
