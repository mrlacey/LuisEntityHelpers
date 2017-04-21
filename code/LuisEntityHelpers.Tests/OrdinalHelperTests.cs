// <copyright file="OrdinalHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public class OrdinalHelperTests
    {
        [TestMethod]
        public void SimpleText_ProcessedOk()
        {
            var json = @" { ""entity"": ""third"", ""type"": ""builtin.ordinal"", ""resolution"": { ""value"": ""3"" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(3, resp.Value);
        }

        [TestMethod]
        public void LargeSimpleText_ProcessedOk()
        {
            var json = " { \"entity\": \"five hundred and twenty-fifth\", \"type\": \"builtin.ordinal\", \"startIndex\": 8, \"endIndex\": 36, \"resolution\": { \"value\": \"525\" }}";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(525, resp.Value);
        }

        [TestMethod]
        public void SimpleNumeric_ProcessedOk()
        {
            var json = " { \"entity\": \"3rd\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"3\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(3, resp.Value);
        }

        [TestMethod]
        public void LargeSimpleNumeric_ProcessedOk()
        {
            var json = @" { ""entity"": ""12458th"", ""type"": ""builtin.ordinal"", ""startIndex"": 8, ""endIndex"": 14, ""resolution"": { ""value"": ""12458"" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(12458, resp.Value);
        }

        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = "{ \"entity\": \"first\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"1\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(1, resp.Value);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = "{ \"entity\": \"second\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"2\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(2, resp.Value);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = "{ \"entity\": \"tenth\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"10\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(10, resp.Value);
        }

        [TestMethod]
        public void LuisSample4_ProcessedOk()
        {
            var json = "{ \"entity\": \"1st\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"1\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(1, resp.Value);
        }

        [TestMethod]
        public void LuisSample5_ProcessedOk()
        {
            var json = "{ \"entity\": \"2nd\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"2\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(2, resp.Value);
        }

        [TestMethod]
        public void LuisSample6_ProcessedOk()
        {
            var json = "{ \"entity\": \"10th\", \"type\": \"builtin.ordinal\", \"resolution\": { \"value\": \"10\" } }";

            var sut = new OrdinalHelper();

            var resp = (OrdinalParseResponse)sut.Parse(json);

            Assert.AreEqual(10, resp.Value);
        }
    }
}
