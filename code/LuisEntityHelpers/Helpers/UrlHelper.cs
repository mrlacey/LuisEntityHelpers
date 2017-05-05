// <copyright file="UrlHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using System;

namespace LuisEntityHelpers
{
    // TODO: add tests
    public class UrlHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Type == Builtin.Url)
            {
                return new UrlParseResponse(entityRecommendation);
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }
    }
}
