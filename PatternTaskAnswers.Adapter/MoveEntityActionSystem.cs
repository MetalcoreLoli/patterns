using System;

namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Система, которая описывает движение сущности.
    /// Так же данная система является простой реализацией паттерна команда
    /// </summary>
    public class MoveEntityActionSystem : IActionSystem
    {
        private MovableCreatureComponent _movable;

        public MoveEntityActionSystem(MovableCreatureComponent movable)
        {
            _movable = movable;
        }
            
        public void Execute()
        {
            _movable.Location = (_movable.Location.X + 1, _movable.Location.Y + 0);
        }
    }
}