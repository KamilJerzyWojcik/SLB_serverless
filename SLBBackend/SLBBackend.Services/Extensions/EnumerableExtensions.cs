using System;
using System.Collections.Generic;
using SLBBackend.Services.Models;

namespace SLBBackend.Services.Extensions
{
    public static class EnumerableExtensions
    {
        public static TreeElement GetHierarchy(this IEnumerable<string> paths, string userId)
        {
            var root = new TreeElement()
            {
                Name = userId,
                Children = new List<TreeElement>()
            };

            foreach(var path in paths)
            {
                var splitBetweenBaseAndDirectory = path.IndexOf(userId, StringComparison.Ordinal) + userId.Length;
                var pathWithoutUser = path.Remove(0, splitBetweenBaseAndDirectory).TrimStart('/');

                if(!string.IsNullOrWhiteSpace(pathWithoutUser))
                {
                    var parts = pathWithoutUser.Split('/');
                    var baseAbsolutePath = path.Substring(0, splitBetweenBaseAndDirectory);
                    root.BuildTree(parts, baseAbsolutePath);
                }
            }

            return root;
        }
    }
}
