// <copyright file="TemperatureHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using System.Text.RegularExpressions;

namespace LuisEntityHelpers
{
    public class TemperatureHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Name == Builtin.Temperature)
            {
                double value = 0;
                var scale = default(TemperatureScale);

                var entityParts = entityRecommendation.Value.Split(' ');

                string stringValue = string.Empty;

                foreach (string part in entityParts)
                {
                    if (new Regex(@"^[a-zA-Z]{1,}$").IsMatch(part))
                    {
                        // Only interested in variations of scale name.
                        // Ignore variations of "degree"
                        if (part.ToLowerInvariant().StartsWith("c"))
                        {
                            scale = TemperatureScale.Celsius;
                        }
                        else if (part.ToLowerInvariant().StartsWith("f"))
                        {
                            scale = TemperatureScale.Fahrenheit;
                        }
                    }
                    else
                    {
                        stringValue += part;
                    }
                }

                value = double.Parse(stringValue);

                return new TemperatureParseResponse(entityRecommendation, value, scale);
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is a temperature
        public TemperatureParseResponse ParseTemperature(EntityRecommendation entityRecommendation)
        {
            return (TemperatureParseResponse)this.Parse(entityRecommendation);
        }
    }
}
