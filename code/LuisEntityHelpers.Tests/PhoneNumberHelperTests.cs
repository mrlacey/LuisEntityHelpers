// <copyright file="PhoneNumberHelperTests.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuisEntityHelpers.Tests
{
    [TestClass]
    public class PhoneNumberHelperTests
    {
        // TODO: add more tests
        [TestMethod]
        public void Sample1_ProcessedOk()
        {
            var json = @"{ ""entity"": ""555-123-4567"", ""type"": ""builtin.phonenumber"", ""startIndex"": 0, ""endIndex"": 11 }";

            var sut = new PhoneNumberHelper();

            var resp = (PhoneNumberParseResponse)sut.Parse(json);

            Assert.IsNotNull(resp);
        }
    }
}
