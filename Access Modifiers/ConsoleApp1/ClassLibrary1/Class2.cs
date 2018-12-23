using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class2
    {
        public Class2()
        {
            Class1 cls1 = new Class1();
            var x = cls1.publicVar;
            //x = cls1.privateVar;
            //x = cls1.protectedVar;
            x = cls1.internalVar;
            x = cls1.protectedInternalVar;
            //x = cls1.privateProtectedVar;
        }
    }
}
