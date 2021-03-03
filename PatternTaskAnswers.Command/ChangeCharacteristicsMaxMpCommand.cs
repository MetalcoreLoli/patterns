using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Команда, которая изменяет значение характеристики MaxMp компонента CreatureCharacteristicsCompotent.
    /// Так же данная команда зависит от интерфейса ILogger. Для работы с характеристикой используется
    /// делегат тип Func принимающий значение типа - int и возвращающее новое значение типа int.
    /// Аргумент лямбды это значение свойства.  
    /// </summary>
    public class ChangeCharacteristicsMaxMpCommand : ChangeCharacteristicsCommnad
    {
        private readonly Func<int, int> _value;
        public ChangeCharacteristicsMaxMpCommand(Func<int, int> value, ILogger logger) 
            : base(c => value(c.MaxMp), logger)
        {
            _value = value;
        }

        public override void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _logger.Write($"MaxMp was changed to {_value(parametric.MaxMp)}");
            base.Execute(parametric);
        }
    }
}