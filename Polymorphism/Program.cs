using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        public class A
        {
            public void NormalFun() { Console.WriteLine("A NormalFun()"); }
            public virtual void VirtualFun() { Console.WriteLine("A VirtualFun()"); VirtualFun2(); }
            public virtual void VirtualFun2() { Console.WriteLine("A VirtualFun2()"); }
        }

        public class B : A
        {
            public void NormalFun() { Console.WriteLine("B NormalFun()"); }
            public virtual void VirtualFun() { Console.WriteLine("B VirtualFun()"); }
            public override void VirtualFun2() { Console.WriteLine("B VirtualFun2()"); }
        }

        public class C : B
        {
            public override void VirtualFun() { Console.WriteLine("C VirtualFun()"); }
        }

        public class D : C
        {
            public void NormalFun() { Console.WriteLine("D NormalFun()"); }
            public override void VirtualFun() { Console.WriteLine("D VirtualFun()"); }
            public override void VirtualFun2() { Console.WriteLine("D VirtualFun2()"); }
        }

        public abstract class E : D
        {
            public virtual void VirtualFun() { Console.WriteLine("E VirtualFun()"); }
            public abstract void VirtualFun2();
        }

        public class F : E
        {
            public override void VirtualFun() { Console.WriteLine("F VirtualFun()"); }
            public override void VirtualFun2() { Console.WriteLine("F VirtualFun2()"); }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("A x = new B();");
            A x = new B();
            x.VirtualFun();

            /* Return
            A VirtualFun()
            B VirtualFun2()
            */

            Console.WriteLine("A y = new D();");
            A y = new D();
            y.VirtualFun();

            /*
            A VirtualFun()
            D VirtualFun2() 
            */

            Console.WriteLine("C z = new F();");
            C z = new F();
            z.VirtualFun();
            z.NormalFun();

            /*
            D VirtualFun()
            B NormalFun()
            */

            Console.WriteLine("D a = new F();");
            D a = new F();
            a.VirtualFun();
            a.NormalFun();

            /*
            D VirtualFun()
            D NormalFun() 
            */

            Console.ReadKey();
        }
    }
}
