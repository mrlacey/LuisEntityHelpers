// <copyright file="BaseDateTimeParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using System;

namespace LuisEntityHelpers
{
    public abstract class BaseDateTimeParseResponse : BaseParseResponse
    {
        public DateTimeResolutionType ResolutionType { get; internal set; }

        public DateTime? DateTime { get; internal set; }

        public DateTime? StartTime { get; internal set; }

        public DateTime? EndTime { get; internal set; }

        public TimeSpan? Duration { get; internal set; }
    }
}