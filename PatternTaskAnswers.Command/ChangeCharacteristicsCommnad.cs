using System;
using System.Collections.Generic;
using PatternTaskAnswers.Adapter;
using PatternTaskAnswers.Singleton;

namespace PatternTaskAnswers.Command
{
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