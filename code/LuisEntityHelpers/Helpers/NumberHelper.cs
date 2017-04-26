// <copyright file="NumberHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace LuisEntityHelpers
{
    public class NumberHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Name == Builtin.Number)
            {
                if (!entityRecommendation.Resolution.ContainsKey("value"))
                {
                    throw new ArgumentException("Resolution was missing expected 'value' key");
                }

                var luisValue = double.Parse(entityRecommendation.Resolution["value"]);

                return new NumberParseResponse(entityRecommendation, luisValue);
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is a number
        public NumberParseResponse ParseNumber(EntityRecommendation entityRecommendation)
        {
            return (NumberParseResponse)this.Parse(entityRecommendation);
        }
    }
}
