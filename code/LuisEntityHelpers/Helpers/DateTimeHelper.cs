// <copyright file="DateTimeHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Mrlacey.LuisEntityHelpers
{
    public class DateTimeHelper : HelperCore
    {
        public DateTimeHelper()
        {
            this.Settings = DateTimeHelperSettings.Default;
        }

        public DateTimeHelper(DateTimeHelperSettings settings)
        {
            this.Settings = settings == null ? DateTimeHelperSettings.Default : this.VerifiedSettings(settings);
        }

        public DateTimeHelperSettings Settings { get; }

        public static IParseResponse ParseEntity(string entityRecommendation, DateTimeHelperSettings settings = null)
        {
            var helper = new DateTimeHelper(settings);

            return helper.Parse(entityRecommendation);
        }

        public static IParseResponse ParseEntity(EntityRecommendation entityRecommendation, DateTimeHelperSettings settings = null)
        {
            var helper = new DateTimeHelper(settings);

            return helper.Parse(entityRecommendation);
        }

        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            DateTimeParseResponse result;

            if (entityRecommendation.Name?.StartsWith(Builtin.DateTime.Prefix) ?? false)
            {
                var resType = DateTimeResolutionType.Unsupported; // default to something to keep compiler happy while writing logic below - should be able to remove this eventually
                DateTime? datetime = null;
                DateTime? starttime = null;
                DateTime? endtime = null;
                TimeSpan? duration = null;

                switch (entityRecommendation.Name)
                {
                    case Builtin.DateTime.Date:
                        if (!entityRecommendation.Resolution.ContainsKey("date"))
                        {
                            throw new ArgumentException("Resolution was missing expected 'date' key");
                        }

                        var resolvedDate = entityRecommendation.Resolution["date"];

                        this.ParseDate(entityRecommendation, resolvedDate, ref resType, ref datetime, ref starttime, ref endtime);

                        if (this.Settings.IgnoreThePast)
                        {
                            if (resType == DateTimeResolutionType.Date)
                            {
                                if (datetime < this.Settings.Time.GetNow())
                                {
                                    resType = DateTimeResolutionType.InPastSoIgnored;
                                    datetime = null;
                                    starttime = null;
                                    endtime = null;
                                }
                            }
                            else if (resType == DateTimeResolutionType.Range)
                            {
                                var now = this.Settings.Time.GetNow();

                                if (endtime.Value < now)
                                {
                                    resType = DateTimeResolutionType.InPastSoIgnored;
                                    starttime = null;
                                    endtime = null;
                                }
                                else if (starttime.Value < now)
                                {
                                    starttime = now.Date;
                                }
                            }
                        }

                        break;

                    case Builtin.DateTime.Time:
                        if (!entityRecommendation.Resolution.ContainsKey("time"))
                        {
                            throw new ArgumentException("Resolution was missing expected 'time' key");
                        }

                        var resolvedTime = entityRecommendation.Resolution["time"];

                        this.ParseTime(resolvedTime, ref resType, ref datetime, ref starttime, ref endtime);

                        break;

                    case Builtin.DateTime.Duration:
                        resType = DateTimeResolutionType.Duration;

                        if (!entityRecommendation.Resolution.ContainsKey("duration"))
                        {
                            throw new ArgumentException("Resolution was missing expected 'duration' key");
                        }

                        var resolvedDuration = entityRecommendation.Resolution["duration"];

                        if (resolvedDuration.StartsWith("PT"))
                        {
                            var matchHours = new Regex(@"(?<hours>\d{1,2}H)").Match(resolvedDuration);
                            var matchMins = new Regex(@"(?<mins>\d{1,2}M)").Match(resolvedDuration);

                            var timespan = TimeSpan.Zero;

                            if (!string.IsNullOrWhiteSpace(matchHours.Value))
                            {
                                timespan = timespan.Add(TimeSpan.FromHours(int.Parse(matchHours.Value.Substring(0, matchHours.Value.Length - 1))));
                            }

                            if (!string.IsNullOrWhiteSpace(matchMins.Value))
                            {
                                timespan = timespan.Add(TimeSpan.FromMinutes(int.Parse(matchMins.Value.Substring(0, matchMins.Value.Length - 1))));
                            }

                            duration = timespan;
                        }
                        else
                        {
                            if (resolvedDuration.StartsWith("P") && resolvedDuration.EndsWith("D"))
                            {
                                duration = TimeSpan.FromDays(double.Parse(resolvedDuration.Substring(1, resolvedDuration.Length - 2)));
                            }
                        }

                        break;

                    case Builtin.DateTime.Set:
                    default:
                        resType = DateTimeResolutionType.Unsupported;
                        break;
                }

                result = new DateTimeParseResponse(
                                                   originalInput: entityRecommendation,
                                                   resolutionType: resType,
                                                   dateTime: datetime,
                                                   startTime: starttime,
                                                   endTime: endtime,
                                                   duration: duration);
            }
            else
            {
                result = new DateTimeParseResponse(
                                                   originalInput: entityRecommendation,
                                                   resolutionType: DateTimeResolutionType.Unsupported);
            }

            return result;
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is a datetime
        public DateTimeParseResponse ParseDateTime(EntityRecommendation entityRecommendation)
        {
            return (DateTimeParseResponse)this.Parse(entityRecommendation);
        }

        // Internal for testing
        internal DateTime GetFirstDayOfFirstWeek(int year, int weekNumber, int month = 1)
        {
            var jan1 = new DateTime(year, month, 1);
            var daysOffset = this.Settings.StartOfWeek.Value - jan1.DayOfWeek;

            var startOfFirstWeek = jan1.AddDays(daysOffset);

            var weekNum = weekNumber;
            if (daysOffset > -4 && daysOffset < 4)
            {
                weekNum -= 1;
            }

            return startOfFirstWeek.AddDays(weekNum * 7);
        }

        private void ParseTime(string resolvedTime, ref DateTimeResolutionType resType, ref DateTime? datetime, ref DateTime? starttime, ref DateTime? endtime)
        {
            if (new Regex(Regexs.TimeHour).IsMatch(resolvedTime))
            {
                resType = DateTimeResolutionType.Time;
                var hours = int.Parse(resolvedTime.Substring(1, 2));
                datetime = DateTime.MinValue.AddHours(hours);
            }
            else if (new Regex(Regexs.TimeHourMinute).IsMatch(resolvedTime))
            {
                resType = DateTimeResolutionType.Time;
                var time = DateTime.ParseExact(resolvedTime, "Thh:mm", CultureInfo.InvariantCulture);

                if (time.Hour < 13 && this.Settings.PresumeTimeIsPmIfNotClear)
                {
                    datetime = DateTime.MinValue.AddHours(time.Hour + 12);
                }
                else
                {
                    datetime = DateTime.MinValue.AddHours(time.Hour);
                }

                datetime = datetime.Value.AddMinutes(time.Minute);
            }
            else if (new Regex(Regexs.DateTimeshorthand).IsMatch(resolvedTime))
            {
                var date = DateTime.ParseExact(resolvedTime.Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var timeShorthand = resolvedTime.Substring(11, 2);

                this.ParseTimeShorthand(date, timeShorthand, out resType, out datetime, out starttime, out endtime);
            }
            else if (new Regex(Regexs.DateTimeHours).IsMatch(resolvedTime))
            {
                var date = DateTime.ParseExact(resolvedTime.Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var time = resolvedTime.Substring(11, 2);

                resType = DateTimeResolutionType.DateAndTime;
                datetime = date.Date.AddHours(int.Parse(time));
            }
            else if (new Regex(Regexs.Timeshorthand).IsMatch(resolvedTime))
            {
                var date = DateTime.MinValue.Date;
                var timeShorthand = resolvedTime.Substring(1, 2);

                this.ParseTimeShorthand(date, timeShorthand, out resType, out datetime, out starttime, out endtime);
            }
            else
            {
                throw new Exception("don't yet know input that could get here. record it if you find something");
            }
        }

        private void ParseTimeShorthand(DateTime date, string timeShorthand, out DateTimeResolutionType resType, out DateTime? datetime, out DateTime? starttime, out DateTime? endtime)
        {
            // Ensure all outparameters are set
            datetime = null;
            starttime = null;
            endtime = null;

            switch (timeShorthand)
            {
                case TimeShorthand.Afternoon:
                    resType = DateTimeResolutionType.Range;
                    starttime = date.Add(this.Settings.AfternoonStartTime.TimeOfDay);
                    endtime = date.Add(this.Settings.AfternoonEndTime.TimeOfDay).AddDayIfEndingNextDay(this.Settings.AfternoonEndTimeIsNextDay);
                    break;

                case TimeShorthand.Evening:
                    resType = DateTimeResolutionType.Range;
                    starttime = date.Add(this.Settings.EveningStartTime.TimeOfDay);
                    endtime = date.Add(this.Settings.EveningEndTime.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EveningEndTimeIsNextDay);
                    break;

                case TimeShorthand.Midday:
                    resType = DateTimeResolutionType.DateAndTime;
                    datetime = date.Date.AddHours(12);
                    break;

                case TimeShorthand.Morning:
                    resType = DateTimeResolutionType.Range;
                    starttime = date.Add(this.Settings.MorningStartTime.TimeOfDay);
                    endtime = date.Add(this.Settings.MorningEndTime.TimeOfDay);
                    break;

                case TimeShorthand.Night:
                    resType = DateTimeResolutionType.Range;
                    starttime = date.Add(this.Settings.NightStartTime.TimeOfDay);
                    endtime = date.Add(this.Settings.NightEndTime.TimeOfDay).AddDayIfEndingNextDay(this.Settings.NightEndTimeIsNextDay);
                    break;

                default:
                    throw new ArgumentException(timeShorthand);
            }

            if (this.Settings.IgnoreThePast && resType == DateTimeResolutionType.Range)
            {
                var now = this.Settings.Time.GetNow();

                if (now.Date > endtime.Value.Date)
                {
                    resType = DateTimeResolutionType.InPastSoIgnored;
                    datetime = null;
                    starttime = null;
                    endtime = null;
                }
               else if (now.Date == starttime.Value.Date && starttime.Value.TimeOfDay < now.TimeOfDay)
                {
                    // current time intersects this period then start time should be changed to now
                    starttime = starttime.Value.Date.Add(now.TimeOfDay);
                }
            }
        }

        private void ParseDate(EntityRecommendation entityRecommendation, string resolvedDate, ref DateTimeResolutionType resType, ref DateTime? datetime, ref DateTime? starttime, ref DateTime? endtime)
        {
            if (new Regex(Regexs.YearMonthDay).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Date;
                datetime = DateTime.ParseExact(resolvedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                starttime = datetime.Value.Date.Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = datetime.Value.Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else if (new Regex(Regexs.XxxxMonthDay).IsMatch(resolvedDate))
            {
                if (entityRecommendation.Resolution.ContainsKey("comment"))
                {
                    var comment = entityRecommendation.Resolution["comment"];

                    if (comment == "weekof")
                    {
                        resType = DateTimeResolutionType.Range;

                        var month = int.Parse(resolvedDate.Substring(5, 2));
                        var day = int.Parse(resolvedDate.Substring(8, 2));

                        int year = this.Settings.Time.GetNow().Year;

                        if (this.Settings.Time.GetNow().Date > new DateTime(this.Settings.Time.GetNow().Year, month, day))
                        {
                            year = this.Settings.Time.GetNow().Year + 1;
                        }

                        var targetDate = new DateTime(year, month, day);

                        var startOfWeek = this.Settings.StartOfWeek;

                        var daysSinceStartOfWeek = 0;

                        while (targetDate.AddDays(0 - daysSinceStartOfWeek).DayOfWeek != startOfWeek)
                        {
                            daysSinceStartOfWeek++;
                        }

                        starttime = targetDate.AddDays(0 - daysSinceStartOfWeek).Date.Add(this.Settings.StartOfDay.TimeOfDay);
                        endtime = targetDate.AddDays(6 - daysSinceStartOfWeek).Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
                    }
                    else
                    {
                        throw new Exception("don't yet know input that could get here. record it if you find something");
                    }
                }
                else
                {
                    resType = DateTimeResolutionType.Date;
                    datetime = DateTime.ParseExact(resolvedDate.Replace("XXXX", this.Settings.Time.GetNow().Year.ToString()), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    starttime = datetime.Value.Date.Add(this.Settings.StartOfDay.TimeOfDay);
                    endtime = datetime.Value.Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
                }
            }
            else if (new Regex(Regexs.XxxxWeeknumberDay).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Date;

                var dayOfWeek = int.Parse(resolvedDate.Substring(resolvedDate.Length - 1));

                var today = this.Settings.Time.GetNow();

                var daysInFuture = 1;

                // LUIS uses Sunday = 7, DotNet uses Sunday = 0
                while ((int)today.AddDays(daysInFuture).DayOfWeek != dayOfWeek % 7)
                {
                    daysInFuture++;
                }

                datetime = today.Date.AddDays(daysInFuture);
                starttime = datetime.Value.Date.Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = datetime.Value.Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else if (new Regex(Regexs.XxxxxMonthWeeknumber).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Range;

                var month = int.Parse(resolvedDate.Substring(5, 2));
                var week = int.Parse(resolvedDate.Substring(resolvedDate.Length - 2));

                var start = this.GetFirstDayOfFirstWeek(this.Settings.Time.GetNow().Year, week, month);

                starttime = start.Date.Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = start.AddDays(6).Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else if (new Regex(Regexs.YearMonth).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Range;

                var month = int.Parse(resolvedDate.Substring(resolvedDate.Length - 2));
                var year = int.Parse(resolvedDate.Substring(0, 4));

                starttime = new DateTime(year, month, 1).Date.Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = starttime.Value.AddMonths(1).AddDays(-1).Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else if (new Regex(Regexs.Year).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Range;

                var year = int.Parse(resolvedDate);

                starttime = new DateTime(year, 1, 1).Date.Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = new DateTime(year, 12, 31).Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else if (new Regex(Regexs.YearWeeknumber).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Range;

                var weekNumber = int.Parse(resolvedDate.Substring(resolvedDate.Length - 2));

                var startOfWeek = this.GetFirstDayOfFirstWeek(int.Parse(resolvedDate.Substring(0, 4)), weekNumber);

                starttime = startOfWeek.Date.Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = startOfWeek.AddDays(6).Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else if (new Regex(Regexs.YearWeeknumberWeekend).IsMatch(resolvedDate))
            {
                resType = DateTimeResolutionType.Range;

                var weekNumber = int.Parse(resolvedDate.Substring(6, 2));

                var startOfWeek = this.GetFirstDayOfFirstWeek(int.Parse(resolvedDate.Substring(0, 4)), weekNumber);

                var daysToSaturday = 0;

                while (startOfWeek.AddDays(daysToSaturday).DayOfWeek != DayOfWeek.Saturday)
                {
                    daysToSaturday++;
                }

                starttime = startOfWeek.Date.AddDays(daysToSaturday).Add(this.Settings.StartOfDay.TimeOfDay);
                endtime = starttime.Value.AddDays(1).Date.Add(this.Settings.EndOfDay.TimeOfDay).AddDayIfEndingNextDay(this.Settings.EndOfDayIsNextDay);
            }
            else
            {
                throw new Exception("don't yet know input that could get here. record it if you find something");
            }
        }

#pragma warning disable SA1501 // StatementMustNotBeOnSingleLine
        private DateTimeHelperSettings VerifiedSettings(DateTimeHelperSettings settings)
        {
            var result = DateTimeHelperSettings.Default;

            if (settings.StartOfWeek != null) { result.StartOfWeek = settings.StartOfWeek; }
            if (settings.MorningStartTime != default(DateTime)) { result.MorningStartTime = settings.MorningStartTime; }
            if (settings.MorningEndTime != default(DateTime)) { result.MorningEndTime = settings.MorningEndTime; }
            if (settings.AfternoonStartTime != default(DateTime)) { result.AfternoonStartTime = settings.AfternoonStartTime; }
            if (settings.AfternoonEndTime != default(DateTime)) { result.AfternoonEndTime = settings.AfternoonEndTime; }
            if (settings.EveningStartTime != default(DateTime)) { result.EveningStartTime = settings.EveningStartTime; }
            if (settings.EveningEndTime != default(DateTime)) { result.EveningEndTime = settings.EveningEndTime; }
            if (settings.NightStartTime != default(DateTime)) { result.NightStartTime = settings.NightStartTime; }
            if (settings.NightEndTime != default(DateTime)) { result.NightEndTime = settings.NightEndTime; }
            if (settings.StartOfDay != default(DateTime)) { result.StartOfDay = settings.StartOfDay; }
            if (settings.EndOfDay != default(DateTime)) { result.EndOfDay = settings.EndOfDay; }

            result.EndOfDayIsNextDay = settings.EndOfDayIsNextDay;
            result.AfternoonEndTimeIsNextDay = settings.AfternoonEndTimeIsNextDay;
            result.EveningEndTimeIsNextDay = settings.EveningEndTimeIsNextDay;
            result.NightEndTimeIsNextDay = settings.NightEndTimeIsNextDay;

            if (settings.MorningStartTime.TimeOfDay > settings.MorningEndTime.TimeOfDay) { throw new ArgumentException("MorningStartTime must be before MorningEndTime"); }
            if (!settings.AfternoonEndTimeIsNextDay && settings.AfternoonStartTime.TimeOfDay > settings.AfternoonEndTime.TimeOfDay) { throw new ArgumentException("AfternoonStartTime must be before AfternoonEndTime"); }
            if (!settings.EveningEndTimeIsNextDay && settings.EveningStartTime.TimeOfDay > settings.EveningEndTime.TimeOfDay) { throw new ArgumentException("EveningStartTime must be before EveningEndTime"); }
            if (!settings.NightEndTimeIsNextDay && settings.NightStartTime.TimeOfDay > settings.NightEndTime.TimeOfDay) { throw new ArgumentException("NightStartTime must be before NightEndTime"); }
            if (!settings.EndOfDayIsNextDay && settings.StartOfDay.TimeOfDay > settings.EndOfDay.TimeOfDay) { throw new ArgumentException("StartOfDay must be before EndOfDay"); }

            result.PresumeTimeIsPmIfNotClear = settings.PresumeTimeIsPmIfNotClear;
            result.IgnoreThePast = settings.IgnoreThePast;

            if (settings.Time != null)
            {
                result.Time = settings.Time;
            }

            return result;
        }
#pragma warning restore SA1501 // StatementMustNotBeOnSingleLine

        private struct TimeShorthand
        {
            public const string Afternoon = "AF";
            public const string Evening = "EV";
            public const string Midday = "MI";
            public const string Morning = "MO";
            public const string Night = "NI";
        }
    }
}
