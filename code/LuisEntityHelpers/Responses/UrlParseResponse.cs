﻿// <copyright file="UrlParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

namespace LuisEntityHelpers
{
    public class UrlParseResponse : BaseParseResponse
    {
        public UrlParseResponse(EntityRecommendation entityRecommendation)
        {
            this.OriginalInput = entityRecommendation;
        }
    }
}
