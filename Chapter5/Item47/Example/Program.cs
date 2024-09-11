using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ProcessTransaction(-100);
        }
        catch (InvalidTransactionException ex)
        {
            Console.WriteLine($"Caught an exception: {ex.Message}");
        }
    }

    static void ProcessTransaction(int amount)
    {
        if (amount < 0)
        {
            throw new InvalidTransactionException("Transaction amount cannot be negative.");
        }

        Console.WriteLine("Transaction processed successfully.");
    }
}

[Serializable]
public class InvalidTransactionException : Exception
{
    public InvalidTransactionException()
        : base("Invalid transaction occurred.") { }

    public InvalidTransactionException(string message)
        : base(message) { }

    public InvalidTransactionException(string message, Exception innerException)
        : base(message, innerException) { }

    // 직렬화를 위한 생성자
    protected InvalidTransactionException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
