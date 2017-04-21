// <copyright file="TemperatureParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public class TemperatureParseResponse : BaseParseResponse
    {
        public TemperatureParseResponse(EntityRecommendation entityRecommendation, double value, TemperatureScale scale)
        {
            this.OriginalInput = entityRecommendation;
            this.NumericValue = value;
            this.Scale = scale;
        }

        public double NumericValue { get; }

        public TemperatureScale Scale { get; }
    }
}
