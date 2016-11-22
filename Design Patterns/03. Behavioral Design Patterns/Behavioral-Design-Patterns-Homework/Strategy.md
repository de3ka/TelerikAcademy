# Strategy Design Pattern

### Motivation

Съществуват ситуации, вкоито дадени класове се различават единствено по своето поведение. При такъв случай е добре всеки различен алгоритъм(поведение) да бъде изолиран в отделен клас, с цел по време на изпълнение на програмата да може да бъде избран най-подходящия. Тогава прилагаме Strategy шаблона.

### Intent
*   да дефинираме семейство алгоритми, да енкапсулираме всеки от тях и да ги направим взаимозаменяеми. Така клиентът сам може да избира кой алгоритъм да използва.  
*   да отделим абстракцията в интерфейс, а отделните имплементации в класовете наследници.

### Implementation & Structure
*   Interface - дефиниран интерфейс, общ за всички алгоритми. Context използва този интерфейс за да извиква конкретния алгоритъм дефиниран от ConcreteStrategy
*   ConcreteStrategy - всеки от тези класове имплементира различен алгоритъм.
*   Context - съдържа референция към Interface обект. Когато се налага да бъде използван ConcreteStrategy, Context използва тази Interface обекта, без да знае неговата конкретна имплементация. Ако е необходимо може да бъде дефиниран допълнителен обект, който да предава данни от контекста към стратегията. Context обекта получава знаевки от клиента и ги делигира към strategy обекта. Обикновено конкретната стратегия е избрана от самия клиент и е подадена на контекста. От тук натам клиентът работи само с Context.

![Strategy structure](http://i63.tinypic.com/23vfbs5.png)

### Applicability & Examples

Както вече беше споменато по-горе Strategy се прилага, когато имаме няколко алгоритъма и искаме те да бъдат взаимозаменяеми. Пример за Strategy в реалния свят е транспортът до летището. Съществуват няколко опции - личен автомобил, метро, такси, автобус и т.н. Всеки от тях ще откара пътник до летището и те са взаимозаменяеми. Пътникът сам трябва да избере стратегия в зависимост от цената, времето с което разполага и т.н.

![Strategy example](http://i63.tinypic.com/r1zxj8.png)

### Related Patterns

*   Bridge - и двата шаблона имат една и съща диаграма. Разликата е, че Strategy е свързан с поведението, а Bridge със структурата. Също така coupling-а между Strategy и Context е по-силен от този между абстракцията и имплементацията при Bridge.

### Code example
```cs
using System;

  class MainApp
  {
    static void Main()
    {
      Context context;

      // Three contexts following different strategies
      context = new Context(new ConcreteStrategyA());
      context.ContextInterface();

      context = new Context(new ConcreteStrategyB());
      context.ContextInterface();

      context = new Context(new ConcreteStrategyC());
      context.ContextInterface();

      // Wait for user
      Console.Read();
    }
  }

  // "Strategy"
  abstract class Strategy
  {
    public abstract void AlgorithmInterface();
  }

  // "ConcreteStrategyA"
  class ConcreteStrategyA : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyA.AlgorithmInterface()");
    }
  }

  // "ConcreteStrategyB"
  class ConcreteStrategyB : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyB.AlgorithmInterface()");
    }
  }

  // "ConcreteStrategyC"
  class ConcreteStrategyC : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyC.AlgorithmInterface()");
    }
  }

  // "Context"
  class Context
  {
    Strategy strategy;

    // Constructor
    public Context(Strategy strategy)
    {
      this.strategy = strategy;
    }

    public void ContextInterface()
    {
      strategy.AlgorithmInterface();
    }
  }

```

### Output

```c
Called ConcreteStrategyA.AlgorithmInterface()
Called ConcreteStrategyB.AlgorithmInterface()
Called ConcreteStrategyC.AlgorithmInterface()
```
