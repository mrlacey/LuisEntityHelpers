// <copyright file="DateTimeHelperTests_Parsing.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mrlacey.LuisEntityHelpers.Tests
{
    [TestClass]
    public class DateTimeHelperTests_Parsing
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullObject_RaisesCorrectError()
        {
            var sut = new DateTimeHelper();

            var resp = sut.Parse((EntityRecommendation)null);
        }

        [TestMethod]
        public void EmptyObject_RaisesCorrectError()
        {
            var sut = new DateTimeHelper();

            var resp = (DateTimeParseResponse)sut.Parse(new EntityRecommendation());

            Assert.AreEqual(DateTimeResolutionType.Unsupported, resp.ResolutionType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullString_RaisesCorrectError()
        {
            var sut = new DateTimeHelper();

            var resp = sut.Parse((string)null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyString_RaisesCorrectError()
        {
            var sut = new DateTimeHelper();

            var resp = sut.Parse(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhitespaceString_RaisesCorrectError()
        {
            var sut = new DateTimeHelper();

            var resp = sut.Parse(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidString_RaisesCorrectError()
        {
            var sut = new DateTimeHelper();

            var resp = sut.Parse(" { }");
        }
    }
}
