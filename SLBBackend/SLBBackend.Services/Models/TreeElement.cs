using System.Collections.Generic;

namespace SLBBackend.Services.Models
{
    public class TreeElement
    {
        
        public string Name { get; set; }

        public string AbsolutePath { get; set; }

        public ICollection<TreeElement> Children { get; set; }
    }
}