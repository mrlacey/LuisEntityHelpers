// <copyright file="PhoneNumberHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using System;

namespace LuisEntityHelpers
{
    // TODO: add tests
    public class PhoneNumberHelper : HelperCore
    {
        public override IParseResponse Parse(EntityRecommendation entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            if (entityRecommendation.Type == Builtin.PhoneNumber)
            {
                return new PhoneNumberParseResponse(entityRecommendation);
            }
            else
            {
                throw new ArgumentException("Invalid Entity for this parser");
            }
        }
    }
}
