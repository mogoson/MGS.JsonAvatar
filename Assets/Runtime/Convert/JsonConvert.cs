/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  JsonConvert.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NtJsonConvert = Newtonsoft.Json.JsonConvert;

namespace MGS.JsonAvatar
{
    public static class JsonConvert
    {
        public static string ToJson(object obj, out Exception error)
        {
            error = null;
            try
            {
                return NtJsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                error = ex;
                return default;
            }
        }

        public static string ToJson(object obj, bool fieldOnly, out Exception error)
        {
            var contractResolver = fieldOnly ? new FieldOnlyContractResolver() : new DefaultContractResolver();
            return ToJson(obj, contractResolver, out error);
        }

        public static string ToJson(object obj, IContractResolver contractResolver, out Exception error)
        {
            var settings = new JsonSerializerSettings { ContractResolver = contractResolver };
            return ToJson(obj, settings, out error);
        }

        public static string ToJson(object obj, JsonSerializerSettings settings, out Exception error)
        {
            error = null;
            try
            {
                return NtJsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception ex)
            {
                error = ex;
                return default;
            }
        }

        public static T FromJson<T>(string json, out Exception error)
        {
            error = null;
            try
            {
                return NtJsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                error = ex;
                return default;
            }
        }

        public static T FromJson<T>(string json, IContractResolver contractResolver, out Exception error)
        {
            var settings = new JsonSerializerSettings { ContractResolver = contractResolver };
            return FromJson<T>(json, settings, out error);
        }

        public static T FromJson<T>(string json, JsonSerializerSettings settings, out Exception error)
        {
            error = null;
            try
            {
                return NtJsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                error = ex;
                return default;
            }
        }
    }
}