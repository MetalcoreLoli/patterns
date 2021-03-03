using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Команда, которая изменяет значение характеристики MaxHp компонента CreatureCharacteristicsCompotent.
    /// Так же данная команда зависит от интерфейса ILogger. Для работы с характеристикой используется
    /// делегат тип Func принимающий значение типа - int и возвращающее новое значение типа int.
    /// Аргумент лямбды это значение свойства.  
    /// </summary>
    public class ChangeCharacteristicsMaxHpCommand : ChangeCharacteristicsCommnad
    {
        private readonly Func<int, int> _value;
        public ChangeCharacteristicsMaxHpCommand(Func<int, int> value, ILogger logger) 
            : base(c => value(c.MaxHp), logger)
        {
            _value = value;
        }

        public override void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _logger.Write($"MaxHp was changed to {_value(parametric.MaxHp)}");
            base.Execute(parametric);
        }
    }
}