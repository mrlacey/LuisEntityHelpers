// <copyright file="DimensionParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public class DimensionParseResponse : BaseParseResponse
    {
        public DimensionParseResponse(EntityRecommendation entityRecommendation, double numericValue, string scale)
        {
            this.OriginalInput = entityRecommendation;
            this.NumericValue = numericValue;
            this.Scale = scale;
        }

        public double NumericValue { get; }

        public string Scale { get; }
    }
}
