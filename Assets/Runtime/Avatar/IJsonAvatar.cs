/*************************************************************************
 *  Copyright © 2026 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IJsonAvatar.cs
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
    public interface IJsonAvatar<T>
    {
        T Data { set; get; }

        T Pull(out Exception error);

        Exception Push();
    }
}