using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace Staffmeer.Server.Helpers
{
    public static class SmrSelectList
    {
        public static SelectList Build<T>(
            IEnumerable<T>? items,
            string valueField,
            string textField,
            object? defaultValue = null,
            string defaultText = "(не выбрано)")
        {
            items ??= Enumerable.Empty<T>();

            var result = new List<object>();

            var dynamicItem = new ExpandoObject() as IDictionary<string, object?>;
            dynamicItem[valueField] = defaultValue ?? 0;
            dynamicItem[textField] = defaultText;

            result.Add(dynamicItem);

            result.AddRange(items.Cast<object>());

            return new SelectList(result, valueField, textField);
        }
    }
}
