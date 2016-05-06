using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime
{
    public interface IParseJson
    {
        void ParseJson(JToken item);
    }
}
