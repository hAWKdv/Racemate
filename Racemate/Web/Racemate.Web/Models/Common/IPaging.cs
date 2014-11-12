﻿namespace Racemate.Web.Models.Common
{
    using System.Collections.Generic;

    public interface IPaging<T>
        where T : class
    {
        IEnumerable<T> Collection { get; }

        int PageCount { get; }

        int CurrentPage { get; }
    }
}
