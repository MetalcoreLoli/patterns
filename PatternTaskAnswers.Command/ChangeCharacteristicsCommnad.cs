using System;
using System.Collections.Generic;
using PatternTaskAnswers.Adapter;
using PatternTaskAnswers.Singleton;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Абстракный класс, который описывает команды работающее с характеристиками
    /// компонента CreatureCharacteristicsCompotent. В конструкторе принимает делегат,
    /// Action, который принимает компонент и изменяет его. У класса есть два virutal метода,
    /// которые реализую методы родительского интерфейса IEntityCommand c обощенным типом CreatureCharacteristicsCompotent.
    /// Так же данная команда зависит от ILogger.  
    /// </summary>
    public abstract class ChangeCharacteristicsCommnad : IEntityCommand<CreatureCharacteristicsCompotent>
    {
        protected readonly Action<CreatureCharacteristicsCompotent> _execute;
        protected readonly ILogger _logger;

        public ChangeCharacteristicsCommnad(Action<CreatureCharacteristicsCompotent> execute, ILogger logger)
        {
            _execute = execute;
            _logger = logger;
        }

        public virtual void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _execute(parametric);
        }

        public virtual bool CanExecute(CreatureCharacteristicsCompotent parametr)
        {
            return parametr != null;
        }
    }
}