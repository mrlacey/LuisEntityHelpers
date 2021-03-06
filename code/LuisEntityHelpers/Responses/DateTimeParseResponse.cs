﻿// <copyright file="DateTimeParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace LuisEntityHelpers
{
    public class DateTimeParseResponse : BaseDateTimeParseResponse
    {
        public DateTimeParseResponse(EntityRecommendation originalInput, DateTimeResolutionType resolutionType, DateTime? dateTime = null, DateTime? startTime = null, DateTime? endTime = null, TimeSpan? duration = null)
        {
            this.OriginalInput = originalInput;
            this.ResolutionType = resolutionType;
            this.DateTime = dateTime;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Duration = duration;
        }
    }
}
