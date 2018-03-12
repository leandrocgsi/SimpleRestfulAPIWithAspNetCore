﻿using System;
using System.Runtime.Serialization;

namespace SimpleRestfulAPIWithAspNetCore.Data.Converter
{
    public class Error
    {
        [IgnoreDataMember]
        public bool Localized { get; private set; }

        [IgnoreDataMember]
        public Enum SourceEnum { get; private set; }

        public string StackTrace { get; private set; }
    }
}
