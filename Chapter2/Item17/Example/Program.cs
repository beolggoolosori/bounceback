public class ResourceManager : IDisposable
{
    private bool disposed = false;
    private IntPtr unmanagedResource; // 예: 파일 핸들
    private SafeHandle managedResource; // 예: SafeHandle을 사용하는 파일 스트림

    public ResourceManager()
    {
        unmanagedResource = /* 할당 */;
        managedResource = new SafeFileHandle(IntPtr.Zero, true);
    }

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
                // 관리되는 자원 해제
                managedResource?.Dispose();
            }

            // 관리되지 않는 자원 해제
            if (unmanagedResource != IntPtr.Zero)
            {
                // Unmanaged resource release code
                unmanagedResource = IntPtr.Zero;
            }

            disposed = true;
        }
    }

    ~ResourceManager()
    {
        Dispose(false);
    }
}
