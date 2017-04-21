// <copyright file="ResolutionType.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public enum DateTimeResolutionType
    {
        /// <summary>
        /// A specific date (ignore the time part)
        /// Can also access startTime and endTime so can be treated like a range
        /// </summary>
        Date,

        /// <summary>
        /// A specific time (ignore the date part)
        /// </summary>
        Time,

        /// <summary>
        /// A specifc date and time
        /// </summary>
        DateAndTime,

        /// <summary>
        /// A period with a start datetime and an end datetime
        /// </summary>
        Range,

        /// <summary>
        /// A length of time
        /// </summary>
        Duration,

        /// <summary>
        /// No value will be accessible as setting to ignore the datetime was set
        /// </summary>
        InPastSoIgnored,

        /// <summary>
        /// The resolution cannot be parsed
        /// </summary>
        Unsupported // Set
    }
}
