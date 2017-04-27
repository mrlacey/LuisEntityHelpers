// <copyright file="EntityRecommendation.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;

namespace LuisEntityHelpers
{
    public class EntityRecommendation
    {
        public string Role { get; set; }

        public string Entity { get; set; }

        public string Type { get; set; }

        public int? StartIndex { get; set; }

        public int? EndIndex { get; set; }

        public double? Score { get; set; }

        public IDictionary<string, string> Resolution { get; set; }
    }
}
