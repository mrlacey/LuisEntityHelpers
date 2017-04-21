// <copyright file="DateTimeHelperSettings.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace Mrlacey.LuisEntityHelpers
{
#pragma warning disable SA1623 // PropertySummaryDocumentationMustMatchAccessors
    public class DateTimeHelperSettings
    {
        public static DateTimeHelperSettings Default => new DateTimeHelperSettings
        {
            StartOfWeek = DayOfWeek.Monday,
            MorningStartTime = DateTime.Parse("00:00"),
            MorningEndTime = DateTime.Parse("12:00"),
            AfternoonStartTime = DateTime.Parse("12:00"),
            AfternoonEndTime = DateTime.Parse("18:00"),
            AfternoonEndTimeIsNextDay = false,
            EveningStartTime = DateTime.Parse("17:00"),
            EveningEndTime = DateTime.Parse("20:00"),
            EveningEndTimeIsNextDay = false,
            NightStartTime = DateTime.Parse("19:00"),
            NightEndTime = DateTime.Parse("23:59:59"),
            NightEndTimeIsNextDay = false,
            StartOfDay = DateTime.Parse("00:00"),
            EndOfDay = DateTime.Parse("23:59:59"),
            EndOfDayIsNextDay = false,
            PresumeTimeIsPmIfNotClear = false,
            IgnoreThePast = false,
            Time = new DefaultTimeAbstraction(),
        };

        // This exists purely for testing.
        public ITimeAbstraction Time { get; set; }

        /// <summary>
        /// If set to True will not return dates in the past and will limit time ranges if they are happening now.
        /// </summary>
        public bool IgnoreThePast { get; set; }

        /// <summary>
        /// If true "10 O'clock" = "22:00", if false "10:00am"
        /// </summary>
        public bool PresumeTimeIsPmIfNotClear { get; set; }

        /// <summary>
        /// Used to set the start of a range when only a day is known
        /// </summary>
        public DateTime StartOfDay { get; set; }

        public bool EndOfDayIsNextDay { get; set; }

        /// <summary>
        /// Used to set the end of a range when only a day is known
        /// </summary>
        public DateTime EndOfDay { get; set; }

        public bool NightEndTimeIsNextDay { get; set; }

        public DateTime NightEndTime { get; set; }

        public DateTime NightStartTime { get; set; }

        public bool EveningEndTimeIsNextDay { get; set; }

        public DateTime EveningEndTime { get; set; }

        public DateTime EveningStartTime { get; set; }

        public bool AfternoonEndTimeIsNextDay { get; set; }

        public DateTime AfternoonEndTime { get; set; }

        public DateTime AfternoonStartTime { get; set; }

        public DateTime MorningEndTime { get; set; }

        public DateTime MorningStartTime { get; set; }

        public DayOfWeek? StartOfWeek { get; set; }
    }
#pragma warning restore SA1623 // PropertySummaryDocumentationMustMatchAccessors
}
