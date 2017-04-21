// <copyright file="IntentRecommendation.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mrlacey.LuisEntityHelpers
{
    [DataContract]
    public class IntentRecommendation
    {
#pragma warning disable SA1309 // Field names must not begin with underscore
        [DataMember(Name = "intent")]
        private string _intent = null;

        [DataMember(Name = "score")]
        private double? _score = null;

        [DataMember(Name = "actions")]
        private IList<Action> _actions = null;
#pragma warning restore SA1309 // Field names must not begin with underscore

        [IgnoreDataMember]
        public string Name => this._intent?.ToLower();

        [IgnoreDataMember]
        public double? Score => this._score;

        [IgnoreDataMember]
        public IList<Action> Actions => this._actions;

        public void SetIntent(string intent)
        {
            this._intent = intent;
        }
    }
}
