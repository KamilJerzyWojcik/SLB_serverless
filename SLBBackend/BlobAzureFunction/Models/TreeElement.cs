using System;
using System.Collections.Generic;

namespace BlobAzureFunction.Models
{
    public class TreeElement
    {
        
        public string Name { get; set; }

        public string AbsolutePath { get; set; }

        public ICollection<TreeElement> Children { get; set; }
    }
}