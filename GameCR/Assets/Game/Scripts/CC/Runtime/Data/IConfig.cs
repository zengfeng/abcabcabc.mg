using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime
{
    public interface IConfig
    {
        void Load( AssetManager am );
        void ReLoad( AssetManager am );
    }
}
