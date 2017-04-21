// <copyright file="MoneyParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public class MoneyParseResponse : BaseParseResponse
    {
        public MoneyParseResponse(EntityRecommendation entityRecommendation, decimal numericValue, string currency)
        {
            this.OriginalInput = entityRecommendation;
            this.NumericValue = numericValue;
            this.Currency = currency;
        }

        public decimal NumericValue { get; }

        public string Currency { get; }
    }
}
