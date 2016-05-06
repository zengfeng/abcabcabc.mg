using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime
{
    public interface IToJson
    {
        Dictionary<string, object> JsonDictionary();
    }
}
