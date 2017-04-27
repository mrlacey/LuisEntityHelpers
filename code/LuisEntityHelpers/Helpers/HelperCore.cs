// <copyright file="HelperCore.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>
// <author>Matt Lacey</author>
// <author>D.A.M. Good Media Ltd.</author>

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace LuisEntityHelpers
{
    public abstract class HelperCore : IEntityHelper
    {
        public virtual IParseResponse Parse(string entityRecommendation)
        {
            if (entityRecommendation == null)
            {
                throw new ArgumentNullException(nameof(entityRecommendation));
            }

            EntityRecommendation resp;
            try
            {
                //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(entityRecommendation)))
                //{
                //    var ser = new DataContractJsonSerializer(typeof(EntityRecommendation), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
                //    resp = ser.ReadObject(ms) as EntityRecommendation;
                //}

                resp = JsonConvert.DeserializeObject<EntityRecommendation>(entityRecommendation);

                if (resp?.Type == null || resp.Entity == null)
                {
                    throw new ArgumentException(nameof(entityRecommendation));
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(entityRecommendation), e);
            }

            return this.Parse(resp);
        }

        public abstract IParseResponse Parse(EntityRecommendation entityRecommendation);
    }
}
