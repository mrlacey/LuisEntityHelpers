// <copyright file="Builtin.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public struct Builtin
    {
        public const string Number = "builtin.number";
        public const string Ordinal = "builtin.ordinal";
        public const string Temperature = "builtin.temperature";
        public const string Dimension = "builtin.dimension";
        public const string Money = "builtin.money";
        public const string Age = "builtin.age";
        public const string Percentage = "builtin.percentage";
        public const string Url = "builtin.url";
        public const string Email = "builtin.email";
        public const string PhoneNumber = "builtin.phonenumber";

        public struct DateTime
        {
            public const string Prefix = "builtin.datetime";

            public const string Date = "builtin.datetime.date";
            public const string Time = "builtin.datetime.time";
            public const string Duration = "builtin.datetime.duration";
            public const string Set = "builtin.datetime.set";
        }

        public struct Geography
        {
            public const string Prefix = "builtin.geography";

            public const string City = "builtin.geography.city";
            public const string Country = "builtin.geography.country";
            public const string PointOfInterest = "builtin.geography.pointOfInterest";
        }

        public struct Encyclopedia
        {
            public const string Prefix = "builtin.encyclopedia";
        }
    }
}
