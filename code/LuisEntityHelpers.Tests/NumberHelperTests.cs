// <copyright file="NumberHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class NumberHelperTests
    {
        [TestMethod]
        public void SimpleText_ProcessedOk()
        {
            var json = " { \"entity\": \"two\", \"type\": \"builtin.number\", \"startIndex\": 37, \"endIndex\": 39, \"resolution\": { \"value\": \"2\" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(2, resp.Value);
        }

        [TestMethod]
        public void NumericInteger_ProcessedOk()
        {
            var json = @" { ""entity"": ""1"", ""type"": ""builtin.number"", ""startIndex"": 58, ""endIndex"": 58, ""resolution"": { ""value"": ""1"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(1, resp.Value);
        }

        [TestMethod]
        public void NumericDecimal_ProcessedOk()
        {
            var json = @" { ""entity"": ""2.5"", ""type"": ""builtin.number"", ""startIndex"": 46, ""endIndex"": 48, ""resolution"": { ""value"": ""2.5"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(2.5, resp.Value);
        }

        [TestMethod]
        public void TextDecimal_ProcessedOk()
        {
            var json = @" { ""entity"": ""two and a half"", ""type"": ""builtin.number"", ""startIndex"": 46, ""endIndex"": 59, ""resolution"": { ""value"": ""2.5"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(2.5, resp.Value);
        }

        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = @" { ""entity"": ""ten"", ""type"": ""builtin.number"",  ""resolution"": { ""value"": ""10"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(10, resp.Value);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = @" { ""entity"": ""forty two"", ""type"": ""builtin.number"",  ""resolution"": { ""value"": ""42"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(42, resp.Value);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = @" { ""entity"": ""3.141"", ""type"": ""builtin.number"",  ""resolution"": { ""value"": ""3.141"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(3.141, resp.Value);
        }

        [TestMethod]
        public void LuisSample4_ProcessedOk()
        {
            var json = @" { ""entity"": ""10k"", ""type"": ""builtin.number"",  ""resolution"": { ""value"": ""10000"" } }";

            var sut = new NumberHelper();

            var resp = (NumberParseResponse)sut.Parse(json);

            Assert.AreEqual(10000, resp.Value);
        }
    }
}
