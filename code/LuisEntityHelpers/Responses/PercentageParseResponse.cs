// <copyright file="PercentageParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public class PercentageParseResponse : BaseParseResponse
    {
        public PercentageParseResponse(EntityRecommendation originalInput, string value)
        {
            this.OriginalInput = originalInput;
            this.Value = value;
            this.NumericValue = double.Parse(value.Substring(0, value.Length - 1));
        }

        public string Value { get; }

        public double NumericValue { get; }
    }
}
