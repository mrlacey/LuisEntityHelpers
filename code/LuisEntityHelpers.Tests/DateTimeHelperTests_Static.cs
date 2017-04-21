// <copyright file="DateTimeHelperTests_Static.cs" company="Matt Lacey">
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
    public class DateTimeHelperTests_Static
    {
        [TestMethod]
        public void CanUseStaticMethodToParse_String()
        {
            var json = "{ \"type\": \"builtin.datetime.date\", \"entity\": \"january 10 2009\", \"resolution\": {\"date\": \"2009-01-10\"} }";

            var resp = (DateTimeParseResponse)DateTimeHelper.ParseEntity(json);

            Assert.AreEqual(DateTimeResolutionType.Date, resp.ResolutionType);
            Assert.AreEqual(new DateTime(2009, 1, 10), resp.DateTime.Value.Date);
        }
    }
}
