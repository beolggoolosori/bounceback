using System;

class Program
{
    public static event EventHandler MultipleEvent;

    public static void Main()
    {
        // 여러 개의 이벤트 핸들러 등록
        MultipleEvent += FirstHandler;
        MultipleEvent += SecondHandler;

        // 이벤트 호출
        OnMultipleEvent();

        // 첫 번째 핸들러만 제거
        MultipleEvent -= FirstHandler;

        // 이벤트 재호출
        OnMultipleEvent();
    }

    private static void FirstHandler(object sender, EventArgs e)
    {
        Console.WriteLine("첫 번째 핸들러 호출됨.");
    }

    private static void SecondHandler(object sender, EventArgs e)
    {
        Console.WriteLine("두 번째 핸들러 호출됨.");
    }

    protected static void OnMultipleEvent()
    {
        // null 조건 연산자를 사용한 이벤트 호출
        MultipleEvent?.Invoke(null, EventArgs.Empty);
    }
}
