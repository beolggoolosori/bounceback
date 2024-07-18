public class ResourceHolder<T> : IDisposable where T : class
{
    private T resource;

    public ResourceHolder(T resource)
    {
        this.resource = resource;
    }

    public void Dispose()
    {
        // 타입 매개변수의 인스턴스가 IDisposable을 구현하는지 확인
        if (resource is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
