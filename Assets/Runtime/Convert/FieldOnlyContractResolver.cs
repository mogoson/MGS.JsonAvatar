/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FieldOnlyContractResolver.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MGS.JsonAvatar
{
    /// <summary>
    /// Contract resolver for field only.
    /// </summary>
    public class FieldOnlyContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Create json Property only for field.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (member.MemberType != MemberTypes.Field)
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}