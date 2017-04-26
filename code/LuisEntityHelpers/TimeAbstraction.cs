// <copyright file="TimeAbstraction.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;

namespace LuisEntityHelpers
{
    public class TimeAbstraction : ITimeAbstraction
    {
        private GetNowDelegate getNowImplementation;

        private TimeAbstraction()
        {
        }

        public delegate DateTime GetNowDelegate();

        public static ITimeAbstraction Create(GetNowDelegate getNowAction)
        {
            var result = new TimeAbstraction
            {
                getNowImplementation = getNowAction,
            };

            return result;
        }

        public DateTime GetNow()
        {
            return this.getNowImplementation.Invoke();
        }
    }
}
