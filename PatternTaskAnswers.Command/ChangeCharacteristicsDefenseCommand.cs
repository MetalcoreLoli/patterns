using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    public class ChangeCharacteristicsDefenseCommand : ChangeCharacteristicsCommnad
    {
        private readonly Func<int, int> _value;
        public ChangeCharacteristicsDefenseCommand(Func<int, int> value, ILogger logger) 
            : base(c => value(c.Defense), logger)
        {
            _value = value;
        }

        public override void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _logger.Write($"Defense was changed to {_value(parametric.Defense)}");
            base.Execute(parametric);
        }
    }
}