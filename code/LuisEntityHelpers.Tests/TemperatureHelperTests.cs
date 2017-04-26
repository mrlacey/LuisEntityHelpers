// <copyright file="TemperatureHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class TemperatureHelperTests
    {
        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = @" { ""entity"": ""32 f"", ""type"": ""builtin.temperature"", ""startIndex"": 0, ""endIndex"": 3, ""score"": 0.9685943 }";

            var sut = new TemperatureHelper();

            var resp = (TemperatureParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(32, resp.NumericValue);
            Assert.AreEqual(TemperatureScale.Fahrenheit, resp.Scale);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = @"{ ""entity"": ""34 degrees celsius"", ""type"": ""builtin.temperature"", ""startIndex"": 0, ""endIndex"": 17, ""score"": 0.9692719 }";

            var sut = new TemperatureHelper();

            var resp = (TemperatureParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(34, resp.NumericValue);
            Assert.AreEqual(TemperatureScale.Celsius, resp.Scale);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = @"{ ""entity"": ""2 deg c"", ""type"": ""builtin.temperature"", ""startIndex"": 0, ""endIndex"": 6, ""score"": 0.945079565 }";

            var sut = new TemperatureHelper();

            var resp = (TemperatureParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(2, resp.NumericValue);
            Assert.AreEqual(TemperatureScale.Celsius, resp.Scale);
        }

        [TestMethod]
        public void Decimals_ProcessedOk()
        {
            var json = @"{ ""entity"": ""2 . 5 degs c"", ""type"": ""builtin.temperature"", ""startIndex"": 0, ""endIndex"": 6, ""score"": 0.945079565 }";

            var sut = new TemperatureHelper();

            var resp = (TemperatureParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(2.5, resp.NumericValue);
            Assert.AreEqual(TemperatureScale.Celsius, resp.Scale);
        }
    }
}
