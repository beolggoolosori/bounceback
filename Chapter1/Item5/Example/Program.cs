using System;

class Program
{
    static void Main(string[] args)
    {
        double price = 1234.56;
        DateTime date = DateTime.Now;

        // 기본 문자열 보간
        string message = $"The price is {price:C} and the date is {date:D}.";
        Console.WriteLine(message);

        // FormattableString을 사용하여 다양한 문화권 적용
        FormattableString message = $"The price is {price:C} and the date is {date:D}.";

        // 미국 문화권 형식
        string usMessage = message.ToString(CultureInfo.GetCultureInfo("en-US"));
        Console.WriteLine("US: " + usMessage);

        // 독일 문화권 형식
        string deMessage = message.ToString(CultureInfo.GetCultureInfo("de-DE"));
        Console.WriteLine("DE: " + deMessage);

        // 한국 문화권 형식
        string krMessage = message.ToString(CultureInfo.GetCultureInfo("ko-KR"));
        Console.WriteLine("KR: " + krMessage);
    }
}