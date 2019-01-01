public interface IA
{    void MethodA();
}

public class A : IA {
    public void MethodA() {
        Console.WriteLine("method in class A");
    }
}

public interface IB
{    void MethodB();
}

public class B : IB {
    public void MethodB() {
        Console.WriteLine("method in class B");
    }
}

public class AB: IA, IB {
    A a = new A();
    B a = new B();
    public void MethodA() {
        a.MethodA();
    }

    public void MethodB() {
        b.MethodB();
    }
}