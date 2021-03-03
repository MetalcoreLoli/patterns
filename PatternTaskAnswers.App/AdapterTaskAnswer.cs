using System;

namespace PatternTaskAnswers.App
{
    /// <summary>
    /// Интерфейс предоставляет необходимый API для печати сообщений 
    /// </summary>
    internal interface IMessageWriter
    {
        /// <summary>
        /// Метод только печает сообщение
        /// </summary>
        /// <param name="msg">Сообщение</param>
        void Write(string msg);
    }

    /// <summary>
    /// Класс, который реализует механизм приветствия. Он зависит от интерфейса
    /// IMessageWriter. Данный интерфейс необходим для печати сообщения, так как
    /// последнее может быть выведено, как в консоль, так и в форме WinForms, окне WPF.
    /// Поэтому данный класс зависит от интерфейса IMessageWriter, так как он предоставляет
    /// механизм печати сообщения
    /// </summary>
    internal class Salutation
    {
        private readonly IMessageWriter _writer;

        public Salutation(IMessageWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// Метод, который выводит приветствие
        /// </summary>
        public void Exclaim() => _writer.Write("Hello !");
    }

    /// <summary>
    /// Реализации консольно вывода
    /// </summary>
    internal class ConsoleMessageWriter : IMessageWriter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    /// <summary>
    /// Данный класс является примером паттрена Декоратор, который инкапсулирует в себя
    /// логику проверки компонента, который явлется наследником интерфейса IMessageWriter.
    /// Так же данный класс тоже реализует интерфейс IMessageWriter, что позволяете использовать
    /// его, точно так же как и других наследников IMessageWriter, и при этом не менять их 
    /// реализацию. Данный класс принимает наследника IMessageWriter в качестве параметра конструктора,
    /// после чего выполняет проверки сообщения на то, что объект сообщение не null и
    /// само сообщение не содержит, только пробелы. После всех проверок класс
    /// выполнит вызов метода Write() компонента, что был передан в конструктор класса.
    /// </summary>
    internal class SecureMessageWriter : IMessageWriter
    {
        /// <summary>
        /// Компонент, который содержит реализацию печати сообщения
        /// </summary>
        private readonly IMessageWriter _writer;

        public SecureMessageWriter(IMessageWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// Данная реализация метода Write () не содержит реализации способа печати,
        /// она лишь вызывает, тот компонент, который действительно печатает сообщение.
        /// Переназначение данного метода - это проверка сообщения на конкретность.
        /// </summary>
        /// <param name="msg">Сообщение, которое не должно состоять только из пробелов или быть null</param>
        /// <exception cref="ArgumentException"></exception>
        public void Write(string msg)
        {
            if (!string.IsNullOrEmpty(msg) && !string.IsNullOrWhiteSpace(msg))
                _writer.Write(msg); // вызов метода печать сообщения
            else
                throw new ArgumentException("Message cannot be null or whitespace");
        }
    }
}