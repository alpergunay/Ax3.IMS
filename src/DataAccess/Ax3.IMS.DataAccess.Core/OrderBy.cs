using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ax3.IMS.DataAccess.Core
{
    public class OrderBy
    {
        public string Property { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ListSortDirection Direction { get; set; }
    }
}
