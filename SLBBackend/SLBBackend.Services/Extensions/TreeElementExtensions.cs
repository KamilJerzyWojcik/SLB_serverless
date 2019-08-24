using System.Collections.Generic;
using System.Linq;
using SLBBackend.Services.Models;

namespace SLBBackend.Services.Extensions
{
    public static class TreeElementExtensions
    {
        public static void BuildTree(this TreeElement treeElement, IEnumerable<string> remainingElements, string baseAbsolutePath)
        {
            var elements = remainingElements as IList<string> ?? remainingElements.ToList();

            if(elements.Any())
            {
                var name = elements.First();
                var child = treeElement.Children.SingleOrDefault(c => c.Name == name);

                if(child == null)
                {
                    child = new TreeElement()
                    {
                        Name = name,
                        Children = new List<TreeElement>(),
                        AbsolutePath = baseAbsolutePath + "/" + name,
                    };

                    treeElement.Children.Add(child);
                }

                BuildTree(child, elements.Skip(1), child.AbsolutePath);
            }
        }
    }
}
