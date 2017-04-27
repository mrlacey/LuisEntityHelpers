// <copyright file="DimensionHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using System.Text.RegularExpressions;

namespace LuisEntityHelpers
{
    public class DimensionHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Type == Builtin.Dimension)
            {
                var entityParts = entityRecommendation.Entity.Split(' ');

                double value = 1;
                string scale = string.Empty;
                string stringValue = string.Empty;

                foreach (string part in entityParts)
                {
                    if (new Regex(@"^[a-zA-Z]{1,}$").IsMatch(part))
                    {
                        if (!part.Equals("a"))
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

                return new DimensionParseResponse(entityRecommendation, value, scale.TrimEnd());
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is a dimension
        public DimensionParseResponse ParseDimension(EntityRecommendation entityRecommendation)
        {
            return (DimensionParseResponse)this.Parse(entityRecommendation);
        }
    }
}
