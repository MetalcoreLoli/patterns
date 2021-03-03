using System;
using PatternTaskAnswers.Builder;

namespace PatternTaskAnswers.App
{
    public class DefaultDungeonFactory : IDungeonFactory
    {
        private readonly IDungeonConfiguration _configuration;

        public DefaultDungeonFactory(IDungeonConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IRoom MakeRoom(int width, int height, int x, int y)
        {
            throw new NotImplementedException("TODO: Implementation of MakeRoom");
        }

        public IPath MakePathFromTo(IRoom a, IRoom b, PathType dir)
        {
            throw new NotImplementedException("TODO: Implementation of MakePathFromTo()");
        }
    }
}