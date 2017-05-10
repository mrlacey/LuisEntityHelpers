// <copyright file="DateTimeV2Tests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class DateTimeV2Tests
    {
        [TestMethod]
        public void Duration_ProcessedOk()
        {
            var json = @" {
      ""entity"": ""3 hours"",
      ""type"": ""builtin.datetimeV2.duration"",
      ""startIndex"": 21,
      ""endIndex"": 27,
      ""resolution"": {
        ""values"": [
          {
            ""timex"": ""PT3H"",
            ""type"": ""duration"",
            ""value"": ""10800""
          }
        ]
      }
    }";

            var sut = new DateTimeV2Helper();

            var resp = (DateTimeV2ParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Set_ProcessedOk()
        {
            var json = @" {
      ""entity"": ""every week"",
      ""type"": ""builtin.datetimeV2.set"",
      ""startIndex"": 17,
      ""endIndex"": 26,
      ""resolution"": {
        ""values"": [
          {
            ""timex"": ""P1W"",
            ""type"": ""set"",
            ""value"": ""not resolved""
          }
        ]
      }
    }
";

            var sut = new DateTimeV2Helper();

            var resp = (DateTimeV2ParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Time_ProcessedOk()
        {
            var json = @"      {
      ""entity"": ""4pm"",
      ""type"": ""builtin.datetimeV2.time"",
      ""startIndex"": 17,
      ""endIndex"": 19,
      ""resolution"": {
        ""values"": [
          {
            ""timex"": ""T16"",
            ""type"": ""time"",
            ""value"": ""16:00:00""
          }
        ]
      }
    }
";

            var sut = new DateTimeV2Helper();

            var resp = (DateTimeV2ParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Date_ProcessedOk()
        {
            var json = @" {
      ""entity"": ""yesterday"",
      ""type"": ""builtin.datetimeV2.date"",
      ""startIndex"": 17,
      ""endIndex"": 25,
      ""resolution"": {
        ""values"": [
          {
            ""timex"": ""2017-05-08"",
            ""type"": ""date"",
            ""value"": ""2017-05-08""
          }
        ]
      }
    }
";

            var sut = new DateTimeV2Helper();

            var resp = (DateTimeV2ParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void WeekOfDate_ProcessedOk()
        {
            var json = @" {
      ""entity"": ""april 1"",
      ""type"": ""builtin.datetimeV2.date"",
      ""startIndex"": 25,
      ""endIndex"": 31,
      ""resolution"": {
        ""values"": [
          {
            ""timex"": ""XXXX-04-01"",
            ""type"": ""date"",
            ""value"": ""2017-04-01""
          },
          {
            ""timex"": ""XXXX-04-01"",
            ""type"": ""date"",
            ""value"": ""2018-04-01""
          }
        ]
      }
    }";

            var sut = new DateTimeV2Helper();

            var resp = (DateTimeV2ParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void DateTimeRange_ProcessedOk()
        {
            var json = @" {
      ""entity"": ""tonight"",
      ""type"": ""builtin.datetimeV2.datetimerange"",
      ""startIndex"": 17,
      ""endIndex"": 23,
      ""resolution"": {
        ""values"": [
          {
            ""timex"": ""2017-05-09TNI"",
            ""type"": ""datetimerange"",
            ""start"": ""2017-05-09 20:00:00"",
            ""end"": ""2017-05-09 23:59:59""
          }
        ]
      }
    }";

            var sut = new DateTimeV2Helper();

            var resp = (DateTimeV2ParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void ResultWithValueAndValues()
        {
            var json = System.IO.File.ReadAllText("./Responses/ValueAndValues.json");

            var result = JsonConvert.DeserializeObject<ResultV2>(json);

            Assert.IsNotNull(result);
        }
    }
}
