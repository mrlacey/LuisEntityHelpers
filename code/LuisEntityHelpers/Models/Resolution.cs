// <copyright file="Resolution.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>

using System.Collections.Generic;
using System.Linq;

namespace LuisEntityHelpers
{
    public class Resolution
    {
        public IList<ResolutionValue> Values { get; set; }

        public string Value { get; set; }
        public string Unit { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }
        public string Duration { get; set; }

        public ResolutionValue FirstValue => Enumerable.FirstOrDefault<ResolutionValue>(this.Values);
    }
}