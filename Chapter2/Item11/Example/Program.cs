using System;
using System.Diagnostics;

class ResourceWithFinalizer
{
    private byte[] data = new byte[1024];  // 예제 데이터

    ~ResourceWithFinalizer()
    {
        // 파이널라이즈 프로세스
    }
}

class ResourceWithIDisposable : IDisposable
{
    private byte[] data = new byte[1024];  // 예제 데이터
    private bool disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // 관리 리소스 해제
            }
            // 비관리 리소스 해제
            disposed = true;
        }
    }

    ~ResourceWithIDisposable()
    {
        Dispose(false);
    }
}

class Program
{
    static void Main()
    {
        const int numIterations = 1000000;

        Stopwatch sw = new Stopwatch();

        // IDisposable 인터페이스 사용
        sw.Start();
        for (int i = 0; i < numIterations; i++)
        {
            using (var resource = new ResourceWithIDisposable())
            {
                // 리소스 사용
            }
        }
        sw.Stop();
        Console.WriteLine($"IDisposable: {sw.ElapsedMilliseconds} ms");

        // 파이널라이저 사용
        sw.Restart();
        for (int i = 0; i < numIterations; i++)
        {
            var resource = new ResourceWithFinalizer();
        }
        sw.Stop();
        Console.WriteLine($"Finalizer: {sw.ElapsedMilliseconds} ms");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}
