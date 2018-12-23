using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    public class Class4 : Class1
    {

        public Class4()
        {
            var x = this.publicVar;
            //x = this.privateVar;
            x = this.protectedVar;
            //x = this.internalVar;
            x = this.protectedInternalVar;
            //x = this.privateProtectedVar;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Class1 cls1 = new Class1();
            var x = cls1.publicVar;
            //x = cls1.privateVar;
            //x = cls1.protectedVar;
            //x = cls1.internalVar;
            //x = cls1.protectedInternalVar;
            //x = cls1.privateProtectedVar;
            Class4 cl4 = new Class4();
            x = cl4.publicVar;

        }
    }
}
