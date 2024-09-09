using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApi.Infrastructure.Services.Extensions
{
    public static class StringExtensions
    {
        public static string AppendUriPath(this string input, string pathToAppend)
        {
            var trimmedInput = input.TrimEnd('/');
            var trimmedSecondString = pathToAppend.TrimStart('/');
            return $"{trimmedInput}/{trimmedSecondString}";
        }
    }
}
