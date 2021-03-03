using System;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    public class MoveCreatureCommand : IEntityCommand<IActionSystem>
    {
        private readonly IActionSystem _system;
        private readonly MovableCreatureComponent _movable;
        private readonly ILogger _logger;

        public MoveCreatureCommand(IActionSystem system, MovableCreatureComponent movable, ILogger logger)
        {
            _system = system;
            _logger = logger;
            _movable = movable;
        }

        public void Execute(IActionSystem parametric)
        {
            _system.Execute(); 
            _logger.Write($"Creature was moved to {_movable.Location}");
        }

        public bool CanExecute(IActionSystem parametr)
        {
            throw new NotImplementedException();
        }

    }
}