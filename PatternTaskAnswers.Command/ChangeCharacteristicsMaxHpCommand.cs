using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
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