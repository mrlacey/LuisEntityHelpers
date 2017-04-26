// <copyright file="MoneyHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using System.Text.RegularExpressions;

namespace LuisEntityHelpers
{
    public class MoneyHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Name == Builtin.Money)
            {
                var entityParts = entityRecommendation.Value.Split(' ');

                decimal value = 1;
                string currency = string.Empty;
                string stringValue = string.Empty;

                foreach (string part in entityParts)
                {
                    if (new Regex(@"^[0-9,.]{1,}$").IsMatch(part))
                    {
                        stringValue += part;
                    }
                    else
                    {
                        if (!part.Equals("a"))
                        {
                            currency += part + " ";
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(stringValue))
                {
                    value = decimal.Parse(stringValue);
                }

                return new MoneyParseResponse(entityRecommendation, value, currency.TrimEnd());
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }

        // Convenience method to avoid the need to cast from IParseResponse if already know entity is money
        public MoneyParseResponse ParseMoney(EntityRecommendation entityRecommendation)
        {
            return (MoneyParseResponse)this.Parse(entityRecommendation);
        }
    }
}
