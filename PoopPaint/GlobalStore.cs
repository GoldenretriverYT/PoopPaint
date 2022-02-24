using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoopPaint
{
    /**
     * GlobalStore is used to store data across tools, for example a generic size value
     */
    public static class GlobalStore
    {
        private static Dictionary<string, object> store = new Dictionary<string, object>();

        public static object Get(string key, object defaultValue)
        {
            if (store.ContainsKey(key))
            {
                return store[key];
            }else
            {
                return defaultValue;
            }
        }
        
        public static void Set(string key, object value)
        {
            store[key] = value;
        }
    }
}
