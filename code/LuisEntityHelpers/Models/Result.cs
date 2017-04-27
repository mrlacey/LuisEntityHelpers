// <copyright file="Result.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LuisEntityHelpers
{
    public class Result
    {
        public string Query { get; set; }

        [JsonProperty("topScoringIntent")]
        public IntentRecommendation PrimaryIntent { get; set; }

        public IList<IntentRecommendation> Intents { get; set; }

        public IList<EntityRecommendation> Entities { get; set; }
    }
}
