// <copyright file="UrlHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class UrlHelperTests
    {
        // TODO: add more tests
        [TestMethod]
        public void Sample1_ProcessedOk()
        {
            // TODO: Replace with appropriate test
            var json = @" { ""entity"": ""name@example.com"", ""type"": ""builtin.email"", ""startIndex"": 0, ""endIndex"": 15 }";

            var sut = new UrlHelper();

            var resp = (UrlParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }
    }
}
