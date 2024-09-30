using System;

public class Account
{
    public decimal Balance { get; private set; }

    public Account(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    // 예외가 발생할 경우에도 계좌 잔액이 변경되지 않도록 강력한 예외 보증을 제공
    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("입금액은 0보다 커야 합니다.");

        decimal originalBalance = Balance;

        try
        {
            // 입금 처리 중 문제가 발생할 수 있음 (예: 외부 의존성)
            Balance += amount;

            // 여기서 예외가 발생할 수 있다고 가정 (네트워크 오류 등)
            SimulateExternalDependency();
        }
        catch
        {
            // 예외가 발생한 경우 원래 상태로 되돌림
            Balance = originalBalance;
            throw;
        }
    }

    // 외부 종속성을 시뮬레이션하는 메서드 (여기서 예외를 발생시킴)
    private void SimulateExternalDependency()
    {
        // 랜덤하게 예외를 발생시킴
        Random random = new Random();
        if (random.Next(2) == 0)
            throw new InvalidOperationException("외부 의존성 오류");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Account myAccount = new Account(1000m);

        try
        {
            myAccount.Deposit(500m);
            Console.WriteLine($"입금 후 잔액: {myAccount.Balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"예외 발생: {ex.Message}");
            Console.WriteLine($"예외 발생 후 잔액: {myAccount.Balance}");
        }

        try
        {
            myAccount.Deposit(-100m); // 이 경우 예외가 발생
        }
        catch (Exception ex)
        {
            Console.WriteLine($"예외 발생: {ex.Message}");
            Console.WriteLine($"예외 발생 후 잔액: {myAccount.Balance}");
        }
    }
}
