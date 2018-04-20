﻿using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
