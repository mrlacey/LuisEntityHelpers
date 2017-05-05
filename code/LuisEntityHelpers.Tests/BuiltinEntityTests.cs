// <copyright file="BuiltinEntityTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class BuiltinEntityTests
    {
        [TestMethod]
        public void Age()
        {
            var json = $"{{\r\n      \"entity\": \"9 years old\",\r\n      \"type\": \"builtin.age\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 10,\r\n      \"resolution\": {{\r\n        \"unit\": \"Year\",\r\n        \"value\": \"9\"\r\n      }}\r\n    }}";

            var sut = new AgeHelper();

            var resp = (AgeParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Datetime()
        {
            var json = $"{{\r\n      \"entity\": \"tomorrow\",\r\n      \"type\": \"builtin.datetime.date\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 7,\r\n      \"resolution\": {{\r\n        \"date\": \"2017-05-06\"\r\n      }}\r\n    }}";

            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Dimension()
        {
            var json = $"{{\r\n      \"entity\": \"2 miles\",\r\n      \"type\": \"builtin.dimension\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 6,\r\n      \"resolution\": {{\r\n        \"unit\": \"Mile\",\r\n        \"value\": \"2\"\r\n      }}\r\n    }}";

            var sut = new DimensionHelper();

            var resp = (DimensionParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Email()
        {
            var json = $"{{\r\n      \"entity\": \"matt@example.com\",\r\n      \"type\": \"builtin.email\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 15\r\n    }}";

            var sut = new EmailHelper();

            var resp = (EmailParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Encyclopedia()
        {
            var json = $"{{\r\n      \"entity\": \"ronald regan\",\r\n      \"type\": \"builtin.encyclopedia.people.person\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 11,\r\n      \"score\": 0.613890767\r\n    }}";

            var sut = new EncyclopediaHelper();

            var resp = (EncyclopediaParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Geography()
        {
            var json = $"{{\r\n      \"entity\": \"paris\",\r\n      \"type\": \"builtin.geography.city\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 4,\r\n      \"score\": 0.985143363\r\n    }}";

            var sut = new GeographyHelper();

            var resp = (GeographyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Money()
        {
            var json = $"{{\r\n      \"entity\": \"100 dollars\",\r\n      \"type\": \"builtin.currency\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 10,\r\n      \"resolution\": {{\r\n        \"unit\": \"Dollar\",\r\n        \"value\": \"100\"\r\n      }}\r\n    }}";

            var sut = new MoneyHelper();

            var resp = (MoneyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Number()
        {
           // var json = System.IO.File.ReadAllText("./Responses/BuiltIn/Number.json");
            var json = $"{{\r\n      \"entity\": \"five\",\r\n      \"type\": \"builtin.number\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 3,\r\n      \"resolution\": {{\r\n        \"value\": \"5\"\r\n      }}\r\n    }}";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Ordinal()
        {
            var json = $"{{\r\n      \"entity\": \"first\",\r\n      \"type\": \"builtin.ordinal\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 4,\r\n      \"resolution\": {{\r\n        \"value\": \"1\"\r\n      }}\r\n    }}";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Percentage()
        {
            var json = $"{{\r\n      \"entity\": \"7%\",\r\n      \"type\": \"builtin.percentage\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 1,\r\n      \"resolution\": {{\r\n        \"value\": \"7%\"\r\n      }}\r\n    }}";

            var sut = new PercentageHelper();

            var resp = (PercentageParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Phonenumber()
        {
            var json = $"{{\r\n      \"entity\": \"555-123-4567\",\r\n      \"type\": \"builtin.phonenumber\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 11\r\n    }}";

            var sut = new PhoneNumberHelper();

            var resp = (PhoneNumberParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Temperature()
        {
            var json = $"{{\r\n      \"entity\": \"7 degrees celsius\",\r\n      \"type\": \"builtin.temperature\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 16,\r\n      \"resolution\": {{\r\n        \"unit\": \"C\",\r\n        \"value\": \"7\"\r\n      }}\r\n    }}";

            var sut = new TemperatureHelper();

            var resp = (TemperatureParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void Url()
        {
            var json = $"{{\r\n      \"entity\": \"http://microsoft.com\",\r\n      \"type\": \"builtin.url\",\r\n      \"startIndex\": 0,\r\n      \"endIndex\": 19\r\n    }}";

            var sut = new UrlHelper();

            var resp = (UrlParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }
    }
}
