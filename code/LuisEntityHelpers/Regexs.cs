// <copyright file="Regexs.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace LuisEntityHelpers
{
    public struct Regexs
    {
        public const string YearMonthDay = @"^\d{4}-\d{2}-\d{2}$";
        public const string XxxxMonthDay = @"^XXXX-\d{2}-\d{2}$";
        public const string XxxxWeeknumberDay = @"^XXXX-WXX-\d{1}$";
        public const string XxxxxMonthWeeknumber = @"^XXXX-\d{2}-W\d{2}$";
        public const string YearMonth = @"^\d{4}-\d{2}$";
        public const string Year = @"^\d{4}$";
        public const string YearWeeknumber = @"^\d{4}-W\d{2}$";
        public const string YearWeeknumberWeekend = @"^\d{4}-W\d{2}-WE$";

        public const string TimeHour = @"^T\d{2}$";
        public const string TimeHourMinute = @"^T\d{2}:\d{2}$";
        public const string DateTimeshorthand = @"^\d{4}-\d{2}-\d{2}T[A-Z]{2}$";
        public const string DateTimeHours = @"^\d{4}-\d{2}-\d{2}T\d{2}$";
        public const string Timeshorthand = @"^T[A-Z]{2}$";
    }
}
