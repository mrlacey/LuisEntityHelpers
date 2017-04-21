// <copyright file="DimensionHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public class DimensionHelperTests
    {
        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = @" { ""entity"": ""650 square kilometers"", ""type"": ""builtin.dimension"", ""startIndex"": 0, ""endIndex"": 20, ""score"": 0.834644437 }";

            var sut = new DimensionHelper();

            var resp = (DimensionParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(650, resp.NumericValue);
            Assert.AreEqual("square kilometers", resp.Scale);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = @" { ""entity"": ""2 miles"", ""type"": ""builtin.dimension"", ""startIndex"": 0, ""endIndex"": 6, ""score"": 0.9962368 }";

            var sut = new DimensionHelper();

            var resp = (DimensionParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(2, resp.NumericValue);
            Assert.AreEqual("miles", resp.Scale);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = @" { ""entity"": ""9 , 350 feet"", ""type"": ""builtin.dimension"", ""startIndex"": 0, ""endIndex"": 9, ""score"": 0.9317738 }";

            var sut = new DimensionHelper();

            var resp = (DimensionParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(9350, resp.NumericValue);
            Assert.AreEqual("feet", resp.Scale);
        }

        [TestMethod]
        public void DecimalValue_ProcessedOk()
        {
            var json = @" { ""entity"": ""1 . 5 miles"", ""type"": ""builtin.dimension"", ""startIndex"": 0, ""endIndex"": 9, ""score"": 0.9317738 }";

            var sut = new DimensionHelper();

            var resp = (DimensionParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(1.5, resp.NumericValue);
            Assert.AreEqual("miles", resp.Scale);
        }

        [TestMethod]
        public void AMile_ProcessedOk()
        {
            var json = @" { ""entity"": ""a mile"", ""type"": ""builtin.dimension"", ""startIndex"": 0, ""endIndex"": 9, ""score"": 0.9317738 }";

            var sut = new DimensionHelper();

            var resp = (DimensionParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(1, resp.NumericValue);
            Assert.AreEqual("mile", resp.Scale);
        }
    }
}
