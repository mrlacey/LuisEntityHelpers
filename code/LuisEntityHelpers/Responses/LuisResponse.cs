// <copyright file="LuisResponse.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;

namespace LuisEntityHelpers
{
    public class LuisResponse
    {
        public string Type { get; set; }

        public string Entity { get; set; }

        public Dictionary<string, string> Resolution { get; set; }
    }
}
