// <copyright file="AgeHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LuisEntityHelpers
{
    public class AgeHelper : HelperCore
    {
        // LUIS currently (March 2107) doesn't convert numbers as part of ages to their numeric part
        // These should be enough to handle most cases relating to age restrictions
        private readonly Dictionary<string, string> knownTextNumbers = new Dictionary<string, string>
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
            { "ten", "10" },
            { "eleven", "11" },
            { "twelve", "12" },
            { "thirteen", "13" },
            { "fourteen", "14" },
            { "fifteen", "15" },
            { "sixteen", "16" },
            { "seventeen", "17" },
            { "eighteen", "18" },
            { "nineteen", "19" },
            { "twenty", "20" },
            { "twentyone", "21" },
            { "twenty-one", "21" },
            { "twentytwo", "22" },
            { "twenty-two", "22" },
            { "twentythree", "23" },
            { "twenty-three", "23" },
            { "twentyfour", "24" },
            { "twenty-four", "24" },
            { "twentyfive", "25" },
            { "twenty-five", "25" },
        };

        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Name == Builtin.Age)
            {
                var entityParts = entityRecommendation.Value.Split(' ');

                double value = 0;
                var scale = string.Empty;
                var stringValue = string.Empty;

                foreach (string part in entityParts)
                {
                    if (new Regex(@"^[a-zA-Z\-]{1,}$").IsMatch(part))
                    {
                        if (this.knownTextNumbers.ContainsKey(part))
                        {
                            stringValue = this.knownTextNumbers[part];
                        }
                        else if (!part.Equals("-") && !part.Equals("old"))
                        {
                            scale += part + " ";
                        }
                    }
                    else
                    {
                        stringValue += part;
                    }
                }

                if (!string.IsNullOrWhiteSpace(stringValue))
                {
                    value = double.Parse(stringValue);
                }

                return new AgeParseResponse(entityRecommendation, value, scale.TrimEnd());
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is an age
        public AgeParseResponse ParseAge(EntityRecommendation entityRecommendation)
        {
            return (AgeParseResponse)this.Parse(entityRecommendation);
        }
    }
}
