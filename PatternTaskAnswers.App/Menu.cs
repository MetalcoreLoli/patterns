using System;
using System.Collections.Generic;

namespace PatternTaskAnswers.App
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Метод, который описывает действие, что совершается
        /// над объектом переданным в качестве аргумента
        /// </summary>
        /// <param name="paramert"></param>
        void Execute(object paramert);
        
        /// <summary>
        /// Метод проверяет может ли сработать
        /// команда на объекте, что был передан в качестве аргумента
        /// </summary>
        /// <param name="paramert"></param>
        /// <returns></returns>
        bool CanExecute(object paramert);
    }

    /// <summary>
    ///  Описание элемента меню
    /// </summary>
    public abstract class MenuItem
    {
        /// <summary>
        /// Действие, которое вызывается при вызове метода Click()
        /// </summary>
        protected ICommand _action;
        public string Name;

        /// <summary>
        /// Конструктор, который создает пункт меню
        /// </summary>
        /// <param name="name">имя пункта</param>
        /// <param name="action">действие, которое выполняется при клике на пункт</param>
        public MenuItem(string name, ICommand action)
        {
            _action = action;
            Name = name;
        }
        
        /// <summary>
        /// Вызов действия, которое происходит при клике 
        /// </summary>
        public void Click()
        {
            if (_action.CanExecute(this))
                _action.Execute(this);
        }
    }
    
    /// <summary>
    /// Реализация паттерна команды, данная реализация использует два делегата
    /// Action и Func. Данные делегаты используются для вынесения реализации логики
    /// в функции. Что позволит не описывать, каждую новую команду в новом классе, а передавать
    /// метод или использовать лямбда-выражения
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Делегат отвечающий за основную логику команды
        /// </summary>
        private readonly Action<object> _execute;
        
        /// <summary>
        /// Делегат необходимый для индикации может ли вызваться функция, на
        /// которую ссылается делегат _execute
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Метод, который вызывает метод, на который ссылается делегат Action, и передает ему свой аргумент
        /// </summary>
        /// <param name="paramert"></param>
        public void Execute(object paramert)
        {
            _execute(paramert);
        }

        /// <summary>
        /// Метод, который взывает проверку на своем аргументе, или же
        /// проверяет есть ли значение у делегата ссылающегося на метод проверки
        /// значения 
        /// </summary>
        /// <param name="paramert"></param>
        /// <returns></returns>
        public bool CanExecute(object paramert)
        {
            return _canExecute == null || _canExecute(paramert);
        }
    }

    /// <summary>
    /// Кнопка меню
    /// </summary>
    public class ButtonMenuItem : MenuItem
    {
        public ButtonMenuItem(string name, ICommand action) : base($"{name}Button", action)
        {
        }
    }
    
    /// <summary>
    /// Меню
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Элементы меню
        /// </summary>
        public List<MenuItem> Items { get; }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

    }
}