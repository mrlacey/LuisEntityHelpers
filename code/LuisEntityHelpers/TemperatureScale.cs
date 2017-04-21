// <copyright file="TemperatureScale.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

namespace Mrlacey.LuisEntityHelpers
{
    public enum TemperatureScale
    {
        Celsius,

        Fahrenheit,

        // LUIS currently (March 2017) thinks Kelvin is a dimension and isn't mentioned in temperature samples
        // Kelvin
    }
}
