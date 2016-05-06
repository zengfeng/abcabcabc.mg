using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Runtime
{
    public class CsvFieldAttribute : Attribute
    {
        public CsvFieldAttribute(params int[] col)
        {
            columns = col;
        }

        public int[] columns;
    }
}
