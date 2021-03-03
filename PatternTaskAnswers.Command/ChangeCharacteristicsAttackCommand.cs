using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    public class ChangeCharacteristicsAttackCommand : ChangeCharacteristicsCommnad
    {
        private readonly Func<int, int> _value;
        public ChangeCharacteristicsAttackCommand(Func<int, int> value, ILogger logger) 
            : base(c => value(c.Attack), logger)
        {
            _value = value;
        }

        public override void Execute(CreatureCharacteristicsCompotent parametric)
        {
            _logger.Write($"Attack was changed to {_value(parametric.Attack)}");
            base.Execute(parametric);
        }
    }
}