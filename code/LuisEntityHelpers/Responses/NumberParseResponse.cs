// <copyright file="NumberParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace LuisEntityHelpers
{
    public class NumberParseResponse : BaseParseResponse
    {
        public NumberParseResponse(EntityRecommendation originalInput, double value)
        {
            this.OriginalInput = originalInput;
            this.Value = value;
        }

        public double Value { get; private set; }
    }
}
