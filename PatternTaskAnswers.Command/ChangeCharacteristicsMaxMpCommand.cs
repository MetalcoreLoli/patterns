using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
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