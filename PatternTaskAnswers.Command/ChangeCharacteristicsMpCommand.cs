using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
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