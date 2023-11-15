using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrivateSchool.API.JsonOptions
{
    public static class JsonOptionEndLoop
    {
        public static JsonSerializerOptions Option()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return options;
        }
        
    }
}