/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  JsonAvatar.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  06/28/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.IOUtility;

namespace MGS.JsonAvatar
{
    public class JsonAvatar<T> : IJsonAvatar<T>
    {
        public T Data { protected set; get; }
        protected string filePath;

        public JsonAvatar(string filePath)
        {
            this.filePath = filePath;
            Pull(out _);
        }

        public JsonAvatar(string filePath, T data)
        {
            this.filePath = filePath;
            Data = data;
        }

        public virtual T Pull(out Exception error)
        {
            var json = FileUtility.ReadAllText(filePath, out error);
            if (error != null)
            {
                return default;
            }
            Data = JsonConvert.FromJson<T>(json, out error);
            return Data;
        }

        public virtual Exception Push()
        {
            var json = JsonConvert.ToJson(Data, out Exception error);
            if (error != null)
            {
                return error;
            }
            return FileUtility.WriteAllText(filePath, json);
        }
    }
}