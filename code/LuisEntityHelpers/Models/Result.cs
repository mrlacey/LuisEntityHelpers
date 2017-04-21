// <copyright file="Result.cs" company="Matt Lacey">
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
    public class Result
    {
#pragma warning disable SA1309 // Field names must not begin with underscore
        [DataMember(Name = "query")]
        private string _query = null;

        [DataMember(Name = "topScoringIntent")]
        private IntentRecommendation _primaryIntent = null;

        [DataMember(Name = "intents")]
        private IList<IntentRecommendation> _intents = null;

        [DataMember(Name = "entities")]
        private IList<EntityRecommendation> _entities = null;
#pragma warning restore SA1309 // Field names must not begin with underscore

        [IgnoreDataMember]
        public string Query => this._query;

        [IgnoreDataMember]
        public IntentRecommendation PrimaryIntent => this._primaryIntent;

        [IgnoreDataMember]
        public IList<IntentRecommendation> Intents => this._intents;

        [IgnoreDataMember]
        public IList<EntityRecommendation> Entities => this._entities;
    }
}
