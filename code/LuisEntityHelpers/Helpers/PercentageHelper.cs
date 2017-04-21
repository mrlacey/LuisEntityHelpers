// <copyright file="PercentageHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace Mrlacey.LuisEntityHelpers
{
    public class PercentageHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Name == Builtin.Percentage)
            {
                if (!entityRecommendation.Resolution.ContainsKey("value"))
                {
                    throw new ArgumentException("Resolution was missing expected 'value' key");
                }

                var luisValue = entityRecommendation.Resolution["value"];

                return new PercentageParseResponse(entityRecommendation, luisValue);
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is a percentage
        public PercentageParseResponse ParsePercentage(EntityRecommendation entityRecommendation)
        {
            return (PercentageParseResponse)this.Parse(entityRecommendation);
        }
    }
}
