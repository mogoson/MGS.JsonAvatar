/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  JsonFile.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  07/01/2026
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.IOUtility;

namespace MGS.JsonAvatar
{
    public static class JsonFile
    {
        public static T Read<T>(string filePath, out Exception error)
        {
            var json = FileUtility.ReadAllText(filePath, out error);
            if (error != null)
            {
                return default;
            }
            return JsonConvert.FromJson<T>(json, out error);
        }

        public static Exception Write(string filePath, object obj)
        {
            var json = JsonConvert.ToJson(obj, out Exception error);
            if (error != null)
            {
                return error;
            }
            return FileUtility.WriteAllText(filePath, json);
        }
    }
}