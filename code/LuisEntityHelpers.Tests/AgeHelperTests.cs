// <copyright file="AgeHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public class AgeHelperTests
    {
        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = @"{ ""entity"": ""100 year old"", ""type"": ""builtin.age"", ""startIndex"": 0, ""endIndex"": 11, ""score"": 0.959810138 }";

            var sut = new AgeHelper();

            var resp = (AgeParseResponse)sut.Parse(json);

           Assert.IsNotNull(resp);
            Assert.AreEqual(100, resp.NumericValue);
            Assert.AreEqual("year", resp.Scale);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = @" { ""entity"": ""19 years old"", ""type"": ""builtin.age"", ""startIndex"": 0, ""endIndex"": 11, ""score"": 0.914432466 }";

            var sut = new AgeHelper();

            var resp = (AgeParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(19, resp.NumericValue);
            Assert.AreEqual("years", resp.Scale);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = @"{ ""entity"": ""69 year - old"", ""type"": ""builtin.age"", ""startIndex"": 0, ""endIndex"": 10, ""score"": 0.9848503 }";

            var sut = new AgeHelper();

            var resp = (AgeParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(69, resp.NumericValue);
            Assert.AreEqual("year", resp.Scale);
        }

        [TestMethod]
        public void LuisSample4_ProcessedOk()
        {
            var json = @" { ""entity"": ""10 - month - old"", ""type"": ""builtin.age"", ""startIndex"": 0, ""endIndex"": 11, ""score"": 0.9398869 }";

            var sut = new AgeHelper();

            var resp = (AgeParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(10, resp.NumericValue);
            Assert.AreEqual("month", resp.Scale);
        }

        [TestMethod]
        public void TextNumberPart_ProcessedOk()
        {
            var json = @" { ""entity"": ""eighteen year - old"", ""type"": ""builtin.age"", ""score"": 0.9398869 }";

            var sut = new AgeHelper();

            var resp = (AgeParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(18, resp.NumericValue);
            Assert.AreEqual("year", resp.Scale);
        }
    }
}
