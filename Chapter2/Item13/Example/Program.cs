using System;

public class DatabaseConnection
{
    // Lazy<T>를 사용하여 인스턴스 생성 지연
    private static readonly Lazy<DatabaseConnection> instance = new Lazy<DatabaseConnection>(() => new DatabaseConnection());

    // 외부에서 생성자 호출 방지
    private DatabaseConnection()
    {
        Console.WriteLine("DatabaseConnection 생성자 호출");
    }

    // 인스턴스 접근자
    public static DatabaseConnection Instance
    {
        get
        {
            Console.WriteLine("Instance 호출");
            return instance.Value;
        }
    }

    // 데이터베이스 연결 시뮬레이션
    public void Connect()
    {
        Console.WriteLine("Database 연결");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("메인 메서드 시작");

        // 첫 번째 인스턴스 요청 시에만 생성자가 호출됨
        DatabaseConnection db1 = DatabaseConnection.Instance;
        db1.Connect();

        // 추가 요청은 생성하지 않고 기존 인스턴스 사용
        DatabaseConnection db2 = DatabaseConnection.Instance;
        db2.Connect();

        Console.WriteLine("메인 메서드 종료");
    }
}
