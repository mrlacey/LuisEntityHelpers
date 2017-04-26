// <copyright file="OrdinalParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace LuisEntityHelpers
{
    public class OrdinalParseResponse : BaseParseResponse
    {
        public OrdinalParseResponse(EntityRecommendation originalInput, int value)
        {
            this.OriginalInput = originalInput;
            this.Value = value;
        }

        public int Value { get; private set; }
    }
}
