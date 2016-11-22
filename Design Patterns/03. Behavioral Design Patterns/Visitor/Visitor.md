# Visitor Design Pattern

### Motivation

Колекциите са широко използвани в ООП-то. Често колекциите съдържат обекти от различни типове. Понякога искаме дадена операция да бъдат приложени върху всеки от тези обекти без да знаем типа му.

Един от възможните подходи да се справим с този проблем е да проверяваме типа на всеки от обектите(instanceof) и да прилагаме тогава операцията върху него. Както знаем обаче този начин не е нито гъвкав, нито добър, нито обектно-ориентиран. Затова прилагаме Visitor шаблона.

### Intent
*   представлява операция, която да бъде извършена върху елементите от дадена обектна структура.
*   позволява ни да дефинираме нова операция, без да променяме класовете на обектите върху които я прилагаме.

### Implementation & Structure
*   Visitor - интерфейс или абстрактен клас, които дефинира visit операция за всеки от типовете "посещаеми" класове(Element). Обикновено всички методи имат едно и също име(visit) и се различават по параметъра(конкретен Element), който приемат.
*   Concrete Visitor - всеки конкретен visitor трябва да имплементира всички visit методи дефинирани в абстрактния клас. Всеки viitor отговаря за различна операция.
*   Element - абстракция, което дефинира метод за приемането на visitor(accept). Това е входната точка, която позволява на елемент да бъде "посетен" от visitor. Всеки елемент от колекцията, която искаме да бъде "посещавана" трябва да имплементира тази абстракция.
* 	Concrete Element - тези класове имплементират Element интерфейса, който им позволява да бъдат "посетени". Това се случва като конкретния visitor бъде предаден на обекта чрез accept() метода.

![Visitor structure](http://i65.tinypic.com/35ajgir.png)

### Applicability & Examples

Както вече беше споменато по-горе Visitor се прилага, когато искаме да приложим операция на обекти от различни типове, без да променяме типа им. Пример:
* 	прилагането на подобни операции върху структура(колекция или по-сложна структура) от обекти от различни класове.
* 	налага ни се да прилагаме различни операции върху дадени обекти. Чрез Visitor изнасяме логиката на операциите в отделни класове.
* 	позволява ни се да променяме поведението на дадени обекти, като добавяме нови visitor-и, докато структурата им си остава същата.

Пример за Visitor от реалния живот е една таксиметрова компания. Когато клиент(Element) се обади на дадена компания за да си поръча такси, тя изпраща кола(Visitor). Когато човекът влиза в колата(accept), той вече не контролира процеса по транспортирането си, за разлика от шофьора на таксито.

![Visitor example](http://i68.tinypic.com/w5jk3.png)

### Problems

Въпреки, че този шаблон е доста мощен и ни позволява гъвкаво добавяне на функционалности към елементи, чрез създаването на нови visitor-и, той има един голям проблем. Ако искаме да добавим нов обект, който да може да приема visitor-и, то всички конкретни visitor-и ще трябва да бъдат преработени(да им бъде добавен visit метод за новия елемент).

### Code example
```cs
using System;
using System.Collections;

  class MainApp
  {
    static void Main()
    {
      // Setup structure
      ObjectStructure o = new ObjectStructure();
      o.Attach(new ConcreteElementA());
      o.Attach(new ConcreteElementB());

      // Create visitor objects
      ConcreteVisitor1 v1 = new ConcreteVisitor1();
      ConcreteVisitor2 v2 = new ConcreteVisitor2();

      // Structure accepting visitors
      o.Accept(v1);
      o.Accept(v2);

      // Wait for user
      Console.Read();
    }
  }

  // "Visitor"
  abstract class Visitor
  {
    public abstract void VisitConcreteElementA(
      ConcreteElementA concreteElementA);
    public abstract void VisitConcreteElementB(
      ConcreteElementB concreteElementB);
  }

  // "ConcreteVisitor1"
  class ConcreteVisitor1 : Visitor
  {
    public override void VisitConcreteElementA(
      ConcreteElementA concreteElementA)
    {
      Console.WriteLine("{0} visited by {1}",
        concreteElementA.GetType().Name, this.GetType().Name);
    }

    public override void VisitConcreteElementB(
      ConcreteElementB concreteElementB)
    {
      Console.WriteLine("{0} visited by {1}",
        concreteElementB.GetType().Name, this.GetType().Name);
    }
  }

  // "ConcreteVisitor2"
  class ConcreteVisitor2 : Visitor
  {
    public override void VisitConcreteElementA(
      ConcreteElementA concreteElementA)
    {
      Console.WriteLine("{0} visited by {1}",
        concreteElementA.GetType().Name, this.GetType().Name);
    }

    public override void VisitConcreteElementB(
      ConcreteElementB concreteElementB)
    {
      Console.WriteLine("{0} visited by {1}",
        concreteElementB.GetType().Name, this.GetType().Name);
    }
  }

  // "Element"
  abstract class Element
  {
    public abstract void Accept(Visitor visitor);
  }

  // "ConcreteElementA"
  class ConcreteElementA : Element
  {
    public override void Accept(Visitor visitor)
    {
      visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
    }
  }

  // "ConcreteElementB"
  class ConcreteElementB : Element
  {
    public override void Accept(Visitor visitor)
    {
      visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
    }
  }

  // "ObjectStructure"
  class ObjectStructure
  {
    private ArrayList elements = new ArrayList();

    public void Attach(Element element)
    {
      elements.Add(element);
    }

    public void Detach(Element element)
    {
      elements.Remove(element);
    }

    public void Accept(Visitor visitor)
    {
      foreach (Element e in elements)
      {
        e.Accept(visitor);
      }
    }
  }
```

### Output

```c
ConcreteElementA visited by ConcreteVisitor1
ConcreteElementB visited by ConcreteVisitor1
ConcreteElementA visited by ConcreteVisitor2
ConcreteElementB visited by ConcreteVisitor2
```
