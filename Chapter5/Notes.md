# Chapter [5]: 예외처리

## item[45]: 메서드가 실패했음을 알리기 위해서 예외를 사용하라

- 오류가 발생했을 때는 항상 예외를 발생시키도록 코드를 작성하는 것이 좋다.
- 다만, 예외는 일반적인 흐름 제어 메커니즘으로 생각해서도 안되고 사용해서도 안된다.
- 요청된 작업이 성공적으로 수행될 수 있을지를 사전에 검사할 수 있는 메서드를 같이 제공하는 것이 좋다.

## item[46]: 리소스 정리를 위해 using과 try/finally를 활용하라

- using
  - IDisposable 인터페이스를 구현한 객체에서 리소스를 사용한 후 자동으로 해제할 수 있는 구조.
  - 블록을 벗어나면 Dispose() 메서드가 자동으로 호출됨.

- using 문을 사용할 수 없는 경우
  - try/finally 블록에서 리소스를 수동으로 해제.
  - finally 블록은 예외가 발생하더라도 항상 실행되므로, 리소스 해제가 보장됨.

## item[47]: 사용자 지정 예외 클래스를 완벽하게 작성하라

- 기존 .NET 예외클래스들을 확장해 도메인에 맞는 예외클래스를 작성하면 더 구체적이고 의미 있는 예외 처리를 구현할 수 있다.
- 기본 클래스 선택: 사용자 지정 예외 클래스는 일반적으로 System.Exception 또는 System.ApplicationException에서 상속.
- 예외 이름은 Exception으로 끝나야 한다.
- 직렬화 지원: 예외 클래스는 직렬화 가능하도록 구현해야 한다. 이를 위해 Serializable 특성을 사용하고, 필요한 경우 SerializationInfo와 StreamingContext를 다룰 수 있어야 함.
- 세 가지 생성자 제공: 기본 생성자, 메시지를 인수로 받는 생성자, 메시지와 내부 예외를 받는 생성자를 제공하는 것이 권장됨.

## item[48]: 강력한 예외 보증을 준수하는 것이 좋다

- 기본 예외 보증 (Basic Exception Guarantee): 예외가 발생하더라도 프로그램의 상태가 일관성을 유지하고, 자원이 누수되지 않도록 보장하는 것.
- 강력한 예외 보증 (Strong Exception Guarantee): 예외가 발생해도 프로그램의 상태가 변하지 않으며, 성공적인 연산이 완료되지 않으면 프로그램의 상태는 원래 상태로 되돌아간다. 이는 "트랜잭션"과 유사한 원칙을 따른다.
- 불변 보증 (No-throw Guarantee): 예외가 발생하지 않도록 보장하는 수준이다. 이 보증은 주로 객체 소멸자나 자원을 해제하는 코드에서 사용된다.

## item[49]: catch 예외를 다시발생시키는 것보다 예외필터가 낫다

- catch 블록에서 예외를 다시 던지면 스택 추적(stack trace) 정보가 사라질 수 있기 때문.
- 예외 필터(Exception Filters) : C#에서 catch 블록과 함께 사용할 수 있는 기능으로, 특정 조건에서만 예외를 처리할 수 있게 해준다. 이를 통해 예외를 처리하기 전에 조건을 검사하고, 필요한 경우에만 예외를 처리할 수 있다. 또한 스택 추적 정보를 유지하기 때문에 디버깅에 용이.

## item[50]: 예의 필터의 다른 활용 예를 살펴보라

- 디버깅 용도: 디버깅 시 특정 예외에 대해서만 로그를 남기고, 실제 예외는 무시하거나 재처리하지 않도록 할 수 있다.
- 환경별 처리: 개발 환경, 테스트 환경, 운영 환경 등 다양한 환경에 따라 예외 처리 방식을 다르게 할 수 있다.
- 사용자 권한에 따른 예외 처리: 사용자의 권한에 따라 예외 처리를 달리할 수 있다. 관리자에게는 더 자세한 예외 메시지를 제공하고, 일반 사용자에게는 단순한 메시지만 보여줄 수 있다.
- 특정 조건 하에서만 예외 처리: 예외 필터는 특정 조건이 맞을 때만 예외를 처리하고, 그렇지 않으면 예외를 무시하거나 다른 방식으로 처리할 수 있다.
