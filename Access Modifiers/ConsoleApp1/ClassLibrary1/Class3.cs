using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class3 : Class1
    {
        public Class3()
        {
            var x = this.publicVar;
            x = this.internalVar;
            x = this.protectedVar;
            x = this.protectedInternalVar;
            x = this.privateProtectedVar;
        }
    }
}
