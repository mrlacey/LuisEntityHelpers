﻿// <copyright file="IParseResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace LuisEntityHelpers
{
    public interface IParseResponse
    {
        EntityRecommendation OriginalInput { get; }
    }
}
