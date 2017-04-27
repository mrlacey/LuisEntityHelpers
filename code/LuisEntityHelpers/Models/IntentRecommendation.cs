// <copyright file="IntentRecommendation.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LuisEntityHelpers
{
    public class IntentRecommendation
    {
        [JsonProperty("intent")]
        public string Name { get; set; }

        public double? Score { get; set; }

        public IList<Action> Actions { get; set; }
    }
}
