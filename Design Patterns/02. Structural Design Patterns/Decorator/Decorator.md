# Decorator Design Pattern

### Motivation

Decorator шаблонът се използва когато искаме да разширим функционалността на един обект. Обикновено това става чрез създаването на нов клас, който има новата желана фунционалност и наследяване. Това обаче може да доведе до така нареченият class explosion или иначе казано необходимостта от добавянето на множество класове при всяко разширяване на фунцкионалността. Тук идва на помощ даденият шаблон. Той ни позволява да добавяме нова функционалност на обект динамично(at runtime), вместо статично(at compile time).

### Intent
*   да добавяме нова фунционалност(метод, пропърти или поле) на даден обект динамично.
*   предоставя алтернатива на стандартното наследяване
*   специфицирано от клиента разширяване на обект чрез рекурсивно "обвиване" в нови класове

### Implementation & Structure
*   Interface - интерфейс за обектите, които ще могат да бъдят разширявани динамично
*   CoreFunctionality - дефинира обект с основна фунционалност, който може да бъде разширяван
*   OptionalWrapper - Съдържа референция към CoreFunctionality обект и наследява Component интерфейса
*   Optionals - конкретни декоратори, които разширяват фунционалността на обект, добавяйки ново състояние или поведение

![Decorator structure](http://i64.tinypic.com/2euoaqq.png)

### Applicability & Examples

Както вече беше споменато по-горе Decorator се прилага, когато имаме нужда от динамичното добавяне(или премахване) на фунционалност към клас, и когато събкласифицирането е невъзможно поради големият брой от класове, които ще трябва да се създадат. Примери:
*   Всяко нещо което има основно състояние и може да бъде специфицирано и разширявано чрез добавянето на нови елементи и състояния
*   Почти всеки GUI toolkit

![Decorator structure example](http://i63.tinypic.com/slo2vb.png)

### Related Patterns

*   Adapter - декораторът много си прилича с адаптер шаблонът. Разликата е в това, че декораторът променя отговорностите(responsibilities) на обект, а адаптер - интерфейса.
*   Composite - декораторът може да бъде разглеждан като Composite, който има само 1 компонент. Декораторът обаче добавя допълнителни отговорности(responsibilities) на обект.

### Code example
```cs
    using System;

  class MainApp
  {
    static void Main()
    {
      // Create ConcreteComponent and two Decorators
      ConcreteComponent c = new ConcreteComponent();
      ConcreteDecoratorA d1 = new ConcreteDecoratorA();
      ConcreteDecoratorB d2 = new ConcreteDecoratorB();

      // Link decorators
      d1.SetComponent(c);
      d2.SetComponent(d1);

      d2.Operation();

      // Wait for user
      Console.Read();
    }
  }

  // "Component"
  abstract class Component
  {
    public abstract void Operation();
  }

  // "ConcreteComponent"
  class ConcreteComponent : Component
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteComponent.Operation()");
    }
  }

  // "Decorator"
  abstract class Decorator : Component
  {
    protected Component component;

    public void SetComponent(Component component)
    {
      this.component = component;
    }

    public override void Operation()
    {
      if (component != null)
      {
        component.Operation();
      }
    }
  }

  // "ConcreteDecoratorA"
  class ConcreteDecoratorA : Decorator
  {
    private string addedState;

    public override void Operation()
    {
      base.Operation();
      addedState = "New State";
      Console.WriteLine("ConcreteDecoratorA.Operation()");
    }
  }

  // "ConcreteDecoratorB"
  class ConcreteDecoratorB : Decorator
  {
    public override void Operation()
    {
      base.Operation();
      AddedBehavior();
      Console.WriteLine("ConcreteDecoratorB.Operation()");
    }

    void AddedBehavior()
    {
    }
  }
```

### Output

```c
  ConcreteComponent.Operation()
  ConcreteDecoratorA.Operation()
  ConcreteDecoratorB.Operation()
```
