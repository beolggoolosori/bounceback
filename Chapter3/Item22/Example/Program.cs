// 공변성(out)
using System;

public class Animal { }
public class Dog : Animal { }

public interface ICovariant<out T>
{
    T GetItem();
}

public class CovariantExample<T> : ICovariant<T>
{
    private T _item;
    public CovariantExample(T item) => _item = item;
    public T GetItem() => _item;
}

public class Program
{
    public static void Main()
    {
        ICovariant<Animal> animalCovariant = new CovariantExample<Dog>(new Dog());
        Animal animal = animalCovariant.GetItem();
        Console.WriteLine(animal.GetType().Name); // "Dog" 출력
    }
}

// 반공변성(in)
using System;

public class Animal { }
public class Dog : Animal { }

public interface IContravariant<in T>
{
    void SetItem(T item);
}

public class ContravariantExample<T> : IContravariant<T>
{
    public void SetItem(T item)
    {
        Console.WriteLine(item.GetType().Name);
    }
}

public class Program
{
    public static void Main()
    {
        IContravariant<Dog> dogContravariant = new ContravariantExample<Animal>();
        dogContravariant.SetItem(new Dog()); // "Dog" 출력
    }
}
