using System;

namespace EffectiveCSharpExamples
{
    public interface IResource
    {
        void PerformAction();
    }

    public class Resource : IResource
    {
        public void PerformAction()
        {
            Console.WriteLine("Resource performing action");
        }
    }

    public class Application
    {
        private readonly IResource _resource;

        public Application(IResource resource)
        {
            _resource = resource;
        }

        public void Run()
        {
            Console.WriteLine("Application running");
            _resource.PerformAction();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DI 컨테이너 설정 (간단한 예로 Microsoft.Extensions.DependencyInjection 대신 수동 설정)
            IResource resource = new Resource();
            Application app = new Application(resource);

            app.Run();

            // 문자열 보간 사용
            string userName = "User";
            Console.WriteLine($"Hello, {userName}! Welcome to the effective C# example.");
        }
    }
}
