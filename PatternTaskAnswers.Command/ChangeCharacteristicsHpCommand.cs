using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    public class ChangeCharacteristicsHpCommand: ChangeCharacteristicsCommnad
    {
        private readonly Func<int, int> _value;
        public ChangeCharacteristicsHpCommand(Func<int, int> value, ILogger logger) 
            : base(c => value(c.Hp), logger)
        {
            _value = value;
        }

        public override void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _logger.Write($"Hp was changed to {_value(parametric.Hp)}");
            base.Execute(parametric);
        }
    }
}