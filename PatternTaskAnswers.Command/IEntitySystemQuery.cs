using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    public interface IEntitySystemQuery<T> : IEntityQuery<T> where T : IActionSystem { }
}