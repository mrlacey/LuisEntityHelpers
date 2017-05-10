// <copyright file="DateTimeV2ParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using System;

namespace LuisEntityHelpers
{
    public class DateTimeV2ParseResponse : BaseDateTimeParseResponse
    {
        public DateTimeV2ParseResponse(LuisEntity entity, DateTimeResolutionType resolutionType, DateTime? dateTime = null, DateTime? startTime = null, DateTime? endTime = null, TimeSpan? duration = null)
        {
            this.OriginalInput = null;
            this.Input = entity;
            this.ResolutionType = resolutionType;
            this.DateTime = dateTime;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Duration = duration;
        }

        public LuisEntity Input { get; set; }
    }
}
