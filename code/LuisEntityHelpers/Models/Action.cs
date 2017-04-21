// <copyright file="Action.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;

namespace Mrlacey.LuisEntityHelpers
{
    // TODO: migrate all models from https://github.com/Microsoft/Cognitive-LUIS-Windows/blob/master/ClientLibrary/Structures/
    public class Action
    {
        public bool? Triggered { get; set; }

        public string Name { get; set; }

        public IList<ActionParameter> Parameters { get; set; }
    }
}
