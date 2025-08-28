using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZK.Domain.Utilities
{
    public class UrlSlugger
    {
        public static string GenerateSlug(string phrase)
        {
            if(string.IsNullOrEmpty(phrase))
                return string.Empty;

            string str = phrase.ToLower();
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove invalid chars
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim(); // Convert multiple spaces into one space
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // Cut and trim it
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // Replace spaces with hyphens
            str = System.Text.RegularExpressions.Regex.Replace(str, @"-+", "-"); // Replace multiple hyphens with a single hyphen
            return str;
        }
    }
}
