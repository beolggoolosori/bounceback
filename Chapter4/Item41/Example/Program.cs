using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        StreamReader reader = new StreamReader("example.txt");

        // 람다 표현식에서 외부 변수 'reader'를 캡처
        Func<string> readLine = () => reader.ReadLine();

        // 다른 작업 수행
        Console.WriteLine("Doing other work...");

        // 파일을 닫지 않은 상태에서 람다 실행
        string line = readLine();
        Console.WriteLine(line);

        // reader.Dispose()를 호출하지 않으면 파일 핸들이 해제되지 않음
        reader.Dispose();
    }
}

public class Program
{
    public static void Main()
    {
        string firstLine;

        // 값비싼 리소스를 람다 밖에서 처리
        using (StreamReader reader = new StreamReader("example.txt"))
        {
            firstLine = reader.ReadLine();
        }

        // 람다 표현식은 값비싼 리소스를 캡처하지 않음
        Func<string> getFirstLine = () => firstLine;

        // 다른 작업 수행
        Console.WriteLine("Doing other work...");

        // 안전하게 첫 번째 줄을 사용
        string line = getFirstLine();
        Console.WriteLine(line);
    }
}
