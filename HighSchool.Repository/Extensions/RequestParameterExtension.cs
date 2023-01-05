using System;
using HighSchool.Entities.Models;
using System.Reflection;

namespace HighSchool.Repository.Extensions
{
    public static class RequestParameterExtension
    {
        public static List<T> LikeSearch<T>(this List<T> data, string key, string searchTerm)
        {
            var property = typeof(T).GetProperty(key, BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
            //if (property == null)
            if (string.IsNullOrWhiteSpace(searchTerm))
                return data;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return data.Where(d => ((string)property.GetValue(d)).Contains(lowerCaseTerm)).ToList();
        }

        public static IQueryable<Post> FilterPostsByAuthor(this IQueryable<Post>
           post, string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                return post;

            return post.Where(
               p => (p.AuthorId == author));
        }

      

    }
}

