// <copyright file="EntityRecommendation.cs" company="Matt Lacey">
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
    public class EntityRecommendation
    {
#pragma warning disable SA1309 // Field names must not begin with underscore
        [DataMember(Name = "role")]
        private string _role = null;

        [DataMember(Name = "entity")]
        private string _entity = null;

        [DataMember(Name = "type")]
        private string _type = null;

        [DataMember(Name = "startIndex")]
        private int? _startIndex = null;

        [DataMember(Name = "endIndex")]
        private int? _endIndex = null;

        [DataMember(Name = "score")]
        private double? _score = null;

        [DataMember(Name = "resolution")]
        private IDictionary<string, string> _resolution = null;
#pragma warning restore SA1309 // Field names must not begin with underscore

        [IgnoreDataMember]
        public string Role => this._role;

        [IgnoreDataMember]
        public string Value => this._entity;

        [IgnoreDataMember]
        public string Name => this._type;

        [IgnoreDataMember]
        public int? StartIndex => this._startIndex;

        [IgnoreDataMember]
        public int? EndIndex => this._endIndex;

        [IgnoreDataMember]
        public double? Score => this._score;

        [IgnoreDataMember]
        public IDictionary<string, string> Resolution => this._resolution;
    }
}
