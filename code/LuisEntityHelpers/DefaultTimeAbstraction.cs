// <copyright file="DefaultTimeAbstraction.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace Mrlacey.LuisEntityHelpers
{
    public class DefaultTimeAbstraction : ITimeAbstraction
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
