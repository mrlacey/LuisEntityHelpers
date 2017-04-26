// <copyright file="CompositeEntity.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;

namespace LuisEntityHelpers
{
    // TODO: remove if not used/needed
    public class CompositeEntity
    {
        public string ParentType { get; set; }

        public string Value { get; set; }

        public IList<CompositeChild> Children { get; set; }
    }
}
