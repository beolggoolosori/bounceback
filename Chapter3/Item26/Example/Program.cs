using System;
using System.Collections.Generic;

// 제네릭 인터페이스 정의
public interface IMyGenericInterface<T>
{
    void Add(T item);
    T Get(int index);
}

// 논제네릭 인터페이스 정의
public interface IMyInterface
{
    void Add(object item);
    object Get(int index);
}

// 제네릭 및 논제네릭 인터페이스를 함께 구현한 클래스
public class MyCollection<T> : IMyGenericInterface<T>, IMyInterface
{
    private List<T> _items = new List<T>();

    // 제네릭 인터페이스 메서드 구현
    public void Add(T item)
    {
        _items.Add(item);
    }

    public T Get(int index)
    {
        return _items[index];
    }

    // 논제네릭 인터페이스 메서드 구현
    void IMyInterface.Add(object item)
    {
        if (item is T typedItem)
        {
            Add(typedItem);
        }
        else
        {
            throw new ArgumentException("Invalid item type");
        }
    }

    object IMyInterface.Get(int index)
    {
        return Get(index);
    }
}

// 레거시 Name 클래스
public class Name : IComparable<Name>, IEquatable<Name>, IComparable
{
    public string First { get; set; }
    public string Last { get; set; }
    public string Middle { get; set; }

    public int CompareTo(Name other)
    {
        if (Object.ReferenceEquals(this, other)) return 0;
        if (Object.ReferenceEquals(other, null)) return 1;

        int rVal = Comparer<string>.Default.Compare(Last, other.Last);
        if (rVal != 0) return rVal;

        rVal = Comparer<string>.Default.Compare(First, other.First);
        if (rVal != 0) return rVal;

        return Comparer<string>.Default.Compare(Middle, other.Middle);
    }

    public bool Equals(Name other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (ReferenceEquals(other, null)) return false;

        return Last == other.Last && First == other.First && Middle == other.Middle;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == typeof(Name))
            return this.Equals(obj as Name);
        else
            return false;
    }

    public override int GetHashCode()
    {
        int hashCode = 0;
        if (Last != null) hashCode ^= Last.GetHashCode();
        if (First != null) hashCode ^= First.GetHashCode();
        if (Middle != null) hashCode ^= Middle.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(Name left, Name right)
    {
        if (left == null) return right == null;
        return left.Equals(right);
    }

    public static bool operator !=(Name left, Name right)
    {
        if (left == null) return right != null;
        return !left.Equals(right);
    }

    int IComparable.CompareTo(object obj)
    {
        if (obj.GetType() != typeof(Name))
            throw new ArgumentException("Argument is not a Name object");
        return this.CompareTo(obj as Name);
    }

    public static bool operator <(Name left, Name right)
    {
        if (left == null) return right != null;
        return left.CompareTo(right) < 0;
    }

    public static bool operator >(Name left, Name right)
    {
        if (left == null) return false;
        return left.CompareTo(right) > 0;
    }

    public static bool operator <=(Name left, Name right)
    {
        if (left == null) return true;
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >=(Name left, Name right)
    {
        if (left == null) return right == null;
        return left.CompareTo(right) >= 0;
    }
}

// 제네릭 메서드 정의
public static bool CheckEquality<T>(T left, T right) where T : IEquatable<T>
{
    if (left == null) return right == null;
    return left.Equals(right);
}

// 테스트 프로그램
class Program
{
    static void Main()
    {
        // 제네릭 인터페이스 사용
        IMyGenericInterface<string> genericCollection = new MyCollection<string>();
        genericCollection.Add("Hello");
        genericCollection.Add("World");
        Console.WriteLine(genericCollection.Get(0)); // 출력: Hello
        Console.WriteLine(genericCollection.Get(1)); // 출력: World

        // 논제네릭 인터페이스 사용
        IMyInterface nonGenericCollection = new MyCollection<string>();
        nonGenericCollection.Add("Hello");
        nonGenericCollection.Add("World");
        Console.WriteLine(nonGenericCollection.Get(0)); // 출력: Hello
        Console.WriteLine(nonGenericCollection.Get(1)); // 출력: World

        // 레거시 Name 클래스 테스트
        Name name1 = new Name { First = "John", Last = "Doe", Middle = "A" };
        Name name2 = new Name { First = "Jane", Last = "Doe", Middle = "B" };

        Console.WriteLine(name1.CompareTo(name2)); // 출력: -1 (Doe, A < Doe, B)
        Console.WriteLine(name1.Equals(name2)); // 출력: False

        // 제네릭 메서드 테스트
        Console.WriteLine(CheckEquality(name1, name2)); // 출력: False
        Console.WriteLine(CheckEquality("test", "test")); // 출력: True

        // 연산자 테스트
        Console.WriteLine(name1 == name2); // 출력: False
        Console.WriteLine(name1 != name2); // 출력: True
        Console.WriteLine(name1 < name2); // 출력: True
        Console.WriteLine(name1 > name2); // 출력: False
        Console.WriteLine(name1 <= name2); // 출력: True
        Console.WriteLine(name1 >= name2); // 출력: False
    }
}
