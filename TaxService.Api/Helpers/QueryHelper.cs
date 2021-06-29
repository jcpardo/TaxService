using System.Collections;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.WebUtilities;
using TaxService.Api.Interfaces;

namespace TaxService.Api.Helpers
{
    public class QueryHelper : IQueryHelper
    {
        public string AppendObjectToQueryString(string uri, object requestObject)
        {
            var type = requestObject.GetType();
            var data = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary
                (
                    p => p.Name,
                    p => p.GetValue(requestObject)
                );

            foreach (var d in data)
            {
                if (d.Value == null)
                {
                    continue;
                }

                if ((d.Value as string == null) && d.Value is IEnumerable enumerable)
                {
                    foreach (var value in enumerable)
                    {
                        uri = QueryHelpers.AddQueryString(uri, d.Key, value.ToString());
                    }
                }
                else
                {
                    uri = QueryHelpers.AddQueryString(uri, d.Key, d.Value.ToString());
                }
            }

            return uri;
        }
    }
}