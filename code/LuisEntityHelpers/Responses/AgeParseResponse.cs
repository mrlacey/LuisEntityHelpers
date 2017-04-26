// <copyright file="AgeParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace LuisEntityHelpers
{
    public class AgeParseResponse : BaseParseResponse
    {
        public AgeParseResponse(EntityRecommendation entityRecommendation, double value, string scale)
        {
            this.OriginalInput = entityRecommendation;
            this.NumericValue = value;
            this.Scale = scale;
        }

        public double NumericValue { get; set; }

        public string Scale { get; set; }
    }
}
