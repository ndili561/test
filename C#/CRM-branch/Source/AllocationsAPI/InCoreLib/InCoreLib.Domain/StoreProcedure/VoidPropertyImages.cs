using System;
using System.Collections.Generic;

namespace InCoreLib.Domain.StoreProcedure
{
    public class VoidPropertyImages
    {
        public string PropertyCode { get; set; }
        public string ImageType { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
