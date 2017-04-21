// <copyright file="PercentageHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public class PercentageHelperTests
    {
        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = @" { ""entity"": ""5.6 percent"", ""type"": ""builtin.percentage"", ""startIndex"": 0, ""endIndex"": 10, ""resolution"": { ""value"": ""5.6%"" } }";

            var sut = new PercentageHelper();

            var resp = (PercentageParseResponse)sut.Parse(json);

            Assert.AreEqual("5.6%", resp.Value);
            Assert.AreEqual(5.6, resp.NumericValue);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = @" { ""entity"": ""10%"", ""type"": ""builtin.percentage"", ""startIndex"": 0, ""endIndex"": 2, ""resolution"": { ""value"": ""10%"" } }";

            var sut = new PercentageHelper();

            var resp = (PercentageParseResponse)sut.Parse(json);

            Assert.AreEqual("10%", resp.Value);
            Assert.AreEqual(10, resp.NumericValue);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = @" { ""entity"": ""7 %"", ""type"": ""builtin.percentage"", ""startIndex"": 28, ""endIndex"": 30, ""resolution"": { ""value"": ""7%"" } }";

            var sut = new PercentageHelper();

            var resp = (PercentageParseResponse)sut.Parse(json);

            Assert.AreEqual("7%", resp.Value);
            Assert.AreEqual(7, resp.NumericValue);
        }
    }
}
