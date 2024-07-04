using System;

namespace MemberInitializationTest
{
    class InitializedAtDeclaration
    {
        private int _value = 10;
        private string _name = "default";

        public InitializedAtDeclaration() { }

        public InitializedAtDeclaration(int value)
        {
            _value = value;
        }

        public void DisplayValues()
        {
            Console.WriteLine($"InitializedAtDeclaration -> Value: {_value}, Name: {_name}");
        }
    }

    class InitializedInConstructor
    {
        private int _value;
        private string _name;

        public InitializedInConstructor()
        {
            _value = 10;
            _name = "default";
        }

        public InitializedInConstructor(int value)
        {
            _value = value;
            _name = "default";
        }

        public void DisplayValues()
        {
            Console.WriteLine($"InitializedInConstructor -> Value: {_value}, Name: {_name}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // InitializedAtDeclaration 클래스 테스트
            var initializedAtDeclarationDefault = new InitializedAtDeclaration();
            initializedAtDeclarationDefault.DisplayValues();

            var initializedAtDeclarationWithValue = new InitializedAtDeclaration(20);
            initializedAtDeclarationWithValue.DisplayValues();

            // InitializedInConstructor 클래스 테스트
            var initializedInConstructorDefault = new InitializedInConstructor();
            initializedInConstructorDefault.DisplayValues();

            var initializedInConstructorWithValue = new InitializedInConstructor(20);
            initializedInConstructorWithValue.DisplayValues();

            // 추가 테스트: 생성자에서 초기화 누락
            var problematicInstance = new ProblematicClass();
            problematicInstance.DisplayValues();
        }
    }

    class ProblematicClass
    {
        private int _value;
        private string _name;

        public ProblematicClass()
        {
            // 의도적으로 _name 초기화를 생략하여 오류 발생 가능성을 테스트
            _value = 10;
        }

        public void DisplayValues()
        {
            Console.WriteLine($"ProblematicClass -> Value: {_value}, Name: {_name ?? "null"}");
        }
    }
}
