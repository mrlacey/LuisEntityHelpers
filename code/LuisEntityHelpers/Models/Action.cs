// <copyright file="Action.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;

namespace LuisEntityHelpers
{
    public class Action
    {
        public bool? Triggered { get; set; }

        public string Name { get; set; }

        public IList<ActionParameter> Parameters { get; set; }
    }
}
