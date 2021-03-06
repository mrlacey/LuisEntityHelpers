// <copyright file="EncyclopediaParseResponse.cs" company="Matt Lacey">
// Copyright � Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

namespace LuisEntityHelpers
{
    public class EncyclopediaParseResponse : BaseParseResponse
    {
        public EncyclopediaParseResponse(EntityRecommendation entityRecommendation)
        {
            this.OriginalInput = entityRecommendation;
        }
    }
}
