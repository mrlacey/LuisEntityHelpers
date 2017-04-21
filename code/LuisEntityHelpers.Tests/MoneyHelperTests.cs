// <copyright file="MoneyHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public partial class MoneyHelperTests
    {
        [TestMethod]
        public void LuisSample1_ProcessedOk()
        {
            var json = @" { ""entity"": ""1000 . 00 us dollars"", ""type"": ""builtin.money"", ""startIndex"": 0, ""endIndex"": 17, ""score"": 0.7404626 }";

            var sut = new MoneyHelper();

            var resp = (MoneyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(1000.00m, resp.NumericValue);
            Assert.AreEqual("us dollars", resp.Currency);
        }

        [TestMethod]
        public void LuisSample2_ProcessedOk()
        {
            var json = @" { ""entity"": ""$ 67 . 5"", ""type"": ""builtin.money"", ""startIndex"": 0, ""endIndex"": 5, ""score"": 0.7716727 }";

            var sut = new MoneyHelper();

            var resp = (MoneyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(67.5m, resp.NumericValue);
            Assert.AreEqual("$", resp.Currency);
        }

        [TestMethod]
        public void LuisSample3_ProcessedOk()
        {
            var json = @" { ""entity"": ""£ 20 . 00"", ""type"": ""builtin.money"", ""startIndex"": 1, ""endIndex"": 6, ""score"": 0.989509761 }";

            var sut = new MoneyHelper();

            var resp = (MoneyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(20.00m, resp.NumericValue);
            Assert.AreEqual("£", resp.Currency);
        }

        [TestMethod]
        public void AUsDollar_ProcessedOk()
        {
            var json = @" { ""entity"": ""a us dollar"", ""type"": ""builtin.money"", ""score"": 0.989509761 }";

            var sut = new MoneyHelper();

            var resp = (MoneyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(1, resp.NumericValue);
            Assert.AreEqual("us dollar", resp.Currency);
        }

        [TestMethod]
        public void Euros_ProcessedOk()
        {
            var json = @" { ""entity"": ""5 euro"", ""type"": ""builtin.money"", ""score"": 0.989509761 }";

            var sut = new MoneyHelper();

            var resp = (MoneyParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
            Assert.AreEqual(5, resp.NumericValue);
            Assert.AreEqual("euro", resp.Currency);
        }
    }
}
