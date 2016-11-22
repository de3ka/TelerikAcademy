# Singleton Design Pattern
___

### Motivation

Singleton шаблонът се използва когато искаме да имаме само една инстанция на даден клас. Най-често се прилага, когато искаме да имаме централизирано управление на вътрешни или външни ресурси, като ни дава глобална точка на достъп до тях. Той е един от най-лесните за прилагане шаблони, защото представлява само един клас, който има за цел да се самоинстанциализира, да не допуска повече от една инстанция и да осигурява глобален достъп до нея.

### Intent
*	Осигурява създаването на единствена инстанция
*	Осигурява глобален достъп до обекта

### Implementation & Structure

Имплементацията включва статично поле в Singleton класа, private конструктор и статичен публичен метод, който да връща референция към статичното поле.

![Singleton inplementation](http://4.bp.blogspot.com/-mmHtXLirrEY/U1jpDIr_jiI/AAAAAAAACL4/eW_nMjihd5Q/s320/singleton.png)

### Applicability & Examples

Както вече беше споменато по-горе Singleton се прилага, когато искаме да имаме една инстанция от клас и тя да е достъпна глобално. Примери:
*	Logger - често са singleton-и, за да се избегне извикването на нов обект при всяко логване
*	Достъп до споделени ресурси
*	Factory-та - ако имаме приложение, което използва factory pattern, то обикновено factory-то е singleton

### Problems & Solutions

*	Имплементация в многонишково приложение - възможно е две или повече различни нишки по едно и също време да достъпват singleton обекта или да се инициализират повече от една инстанции(при lazy loading), ако няколко нишки едновременно в началото поискат обекта. Тези проблеми се решават по два начина:
	*	lazy loading със двоен lock механизъм
	*	ранна инициализация още при създаването на класа(може да се инициализира обект, който да не бъде използван никога)
*	Сериализация - когато Singleton имплементира Serializable интерфейс, трябва да имплементира readResolve метода(Java). В противен случай при сериализация и десериализация ще има няколко инстанции на Singleton класа.
*	Наследяване(protected конструктор) - наследяването на Singleton не е добра идея. Така обектът може да бъде инстанциран от клас наследник. Също така методът Singleton.getInstance() трябва да бъде променен в кода на  newSingleton.getInstance(), където newSingleton е наследникът. Както знаем това е в противоречие с един от основните принципи на ООП.

### Code example

```cs
namespace MineFieldApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// A class using singleton pattern, which gives access to game highscores
    /// Example usage:
    ///     Highscore scorer = Highscore.Instance;
    ///     scorer.AddHighscore("John", 100);
    ///     foreach (var score in scorer.Highscores)
    ///     {
    ///         System.Console.WriteLine(score.PlayerName + " " + score.Points);
    ///     }
    /// .
    /// </summary>
    public sealed class Highscore
    {
        /// <summary>
        /// A constant for the name of the file containing the highscores
        /// </summary>
        private const string HighscoresFileName = "highscores.xml";

        /// <summary>
        /// The instance of the Highscore class
        /// </summary>
        private static readonly Lazy<Highscore> Lazy = new Lazy<Highscore>(() => new Highscore());

        /// <summary>
        /// Holds the game highscores
        /// </summary>
        private List<Score> highscores;

        /// <summary>
        /// Initializes a new instance of the Highscore class and loads highscores
        /// </summary>
        private Highscore()
        {
            this.LoadHighscores();
        }

        /// <summary>
        /// Gets the Highscore class instance
        /// </summary>
        public static Highscore Instance
        {
            get
            {
                return Lazy.Value;
            }
        }

        /// <summary>
        /// Gets or sets the highscores. It implements lazy loading pattern:
        /// if the list with highscores is null it is created.
        /// </summary>
        public List<Score> Highscores
        {
            get
            {
                if (this.highscores == null)
                {
                    this.highscores = new List<Score>();
                }

                return this.highscores;
            }

            private set
            {
                this.highscores = value;
            }
        }

        /// <summary>
        /// Adds a highscore to the file and a the list with highscores
        /// </summary>
        /// <param name="playerName">Name of the player setting high score</param>
        /// <param name="points">His result</param>
        public void AddHighscore(string playerName, double points)
        {
            this.Highscores.Add(new Score(playerName, points));
            this.Highscores.Sort((x, y) => y.Points.CompareTo(x.Points));

            XmlSerializer writer = new XmlSerializer(typeof(List<Score>));

            StreamWriter file = new StreamWriter(Path.GetFullPath(HighscoresFileName), false);

            writer.Serialize(file, this.Highscores);

            file.Close();
        }

        /// <summary>
        /// Clears all highscores
        /// </summary>
        public void ClearHighscores()
        {
            this.Highscores.Clear();
            File.WriteAllText(Path.GetFullPath(HighscoresFileName), string.Empty);
        }

        /// <summary>
        /// Reads highscores from the file and writes them to the list with highscores
        /// </summary>
        private void LoadHighscores()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Score>));
            StreamReader file = new StreamReader(Path.GetFullPath(HighscoresFileName));

            try
            {
                this.Highscores = (List<Score>)reader.Deserialize(file);
            }
            catch (InvalidOperationException)
            {
            }

            file.Close();
        }
    }
}
```
