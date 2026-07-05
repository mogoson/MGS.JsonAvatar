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

namespace MGS.JsonAvatar
{
    public class JsonAvatar<T> : IJsonAvatar<T>
    {
        public T Data
        {
            set { data = value; }
            get
            {
                if (!pulled)
                {
                    Pull(out _);
                    pulled = true;
                }
                return data;
            }
        }

        protected T data;
        protected bool pulled;
        protected string filePath;

        public JsonAvatar(string filePath)
        {
            this.filePath = filePath;
        }

        public JsonAvatar(string filePath, T data)
        {
            this.filePath = filePath;
            this.data = data;
        }

        public virtual T Pull(out Exception error)
        {
            data = JsonFile.Read<T>(filePath, out error);
            return data;
        }

        public virtual Exception Push()
        {
            return JsonFile.Write(filePath, data);
        }
    }
}