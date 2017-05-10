// <copyright file="ResultV2.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using System.Collections.Generic;

namespace LuisEntityHelpers
{
    public class ResultV2
    {
        public string Query { get; set; }

        public LuisIntent TopScoringIntent { get; set; }

        public IList<LuisIntent> Intents { get; set; }

        public IList<LuisEntity> Entities { get; set; }
    }
}
