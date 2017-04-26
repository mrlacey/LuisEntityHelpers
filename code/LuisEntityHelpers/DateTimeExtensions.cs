// <copyright file="DateTimeExtensions.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace LuisEntityHelpers
{
    public static class DateTimeExtensions
    {
        public static DateTime AddDayIfEndingNextDay(this DateTime source, bool isNextDay)
        {
            return isNextDay ? source.AddDays(1) : source;
        }
    }
}
