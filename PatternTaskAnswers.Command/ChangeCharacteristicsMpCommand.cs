using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Команда, которая изменяет значение характеристики Mp компонента CreatureCharacteristicsCompotent.
    /// Так же данная команда зависит от интерфейса ILogger. Для работы с характеристикой используется
    /// делегат тип Func принимающий значение типа - int и возвращающее новое значение типа int.
    /// Аргумент лямбды это значение свойства.  
    /// </summary>
    public class ChangeCharacteristicsMpCommand: ChangeCharacteristicsCommnad
    {
        private readonly Func<int, int> _value;
        public ChangeCharacteristicsMpCommand(Func<int, int> value, ILogger logger) 
            : base(c => value(c.Mp), logger)
        {
            _value = value;
        }

        public override void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _logger.Write($"Mp was changed to {_value(parametric.Mp)}");
            base.Execute(parametric);
        }
    }
}