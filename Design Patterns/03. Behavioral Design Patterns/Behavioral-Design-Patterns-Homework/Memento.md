# Memento Design Pattern

### Motivation

Понякога се налага да запазим състоянието на обект в даден момент и да имамем въможността да върнем обекта към това състояние в по-късен момент, например при грешка в програмата. Това са добре познатите ни (undo/restore операции). При такъв сценарии използваме Memento шаблонът. Той може да има 2 реализации: при едната да пази копие на целия обект, който искаме да може да бъде възстановен, а при другата - да пазим само стъпките които сме направили, като те трябва да могат да бъдат обратими. При Memento логиката по връщане на обекта в предишно състояние и пазенето на тези състояние се възлага на клас различен от този на оригиналния обект. По този начин запазваме добрата енкапсулация.

### Intent
*   да запазваме състояние на обект с цел да може да се върнем към него в по-късен етап, без да разваляме енкапсулацията
*   въвеждане на undo/restore/roll back операции
*   създаване на опорни точки(checkpoints)

### Implementation & Structure
*   Memento - съхранява състоянието на Originator обект. Той трябва да има два интерфейса. Единият за Caretaker, който не трябва да позволява достъп до съхраненото състояние. Другият за Originator, който да позволява достъп така че originator обекта да може да се върне към предишен state.
*   Originator - обектът, чието състояние да може да бъде съхранявано и възстановявано. Има методи за създаване на мементо и за възстановяване на мементо.
*   Caretaker - грижи се за съхранение на различните състояния(Mementos). Caretaker извиква методът createMemento на Originator, той от своя страна връща обект, в който е съхранено състоянието му и който Caretaker да пази. При извикване на методът SetMemento, Caretaker подава на Originator обект от тип Memento и той си възстановява състоянието чрез него.

![Memento structure](http://i65.tinypic.com/2m5jbx4.png)

### Applicability & Examples

Както вече беше споменато по-горе Memento се прилага, когато имаме нужда съхраняването на дадено състояние на обект, с цел възможното връщане към това състояние в по-късен етап. Пример:
*   Undo и Restore операциите в почти всеки софтуер
*   Транзакциите в базите от данни

Пример за Memento в реалния свят е работата на автомобилен механик върху спирачен апарат. Механикът разглобява автоматът първо от едната страна, като другата страна служи като Memento - механикът гледа от нея, за да види как да сглоби разглобеният апарат. След като той е сглобен, се повтаря процедурата от другата страна на колата.

![Memento example](http://i67.tinypic.com/2rcapw2.png)

### Related Patterns

*   Command - този шаблон може да използва Memento, за да възстановява състоянието на обекти при операции, които не са обратими.

### Code example
```cs
using System;

namespace DoFactory.GangOfFour.Memento.Structural
{
  // MainApp startup class for Structural
  // Memento Design Pattern.
  class MainApp
  {
     // Entry point into console application.
    static void Main()
    {
      Originator o = new Originator();
      o.State = "On";

      // Store internal state
      Caretaker c = new Caretaker();
      c.Memento = o.CreateMemento();

      // Continue changing originator
      o.State = "Off";

      // Restore saved state
      o.SetMemento(c.Memento);

      // Wait for user
      Console.ReadKey();
    }
  }

  // The 'Originator' class
  class Originator
  {
    private string _state;

    // Property
    public string State
    {
      get { return _state; }
      set
      {
        _state = value;
        Console.WriteLine("State = " + _state);
      }
    }

    // Creates memento
    public Memento CreateMemento()
    {
      return (new Memento(_state));
    }

    // Restores original state
    public void SetMemento(Memento memento)
    {
      Console.WriteLine("Restoring state...");
      State = memento.State;
    }
  }

  // The 'Memento' class
  class Memento
  {
    private string _state;

    // Constructor
    public Memento(string state) {
      this._state = state;
    }

    // Gets or sets state
    public string State
    {
      get { return _state; }
    }
  }

  // The 'Caretaker' class
  class Caretaker
  {
    private Memento _memento;

    // Gets or sets memento
    public Memento Memento
    {
      set { _memento = value; }
      get { return _memento; }
    }
  }
}
```

### Output

```c
State = On
State = Off
Restoring state:
State = On)
```
