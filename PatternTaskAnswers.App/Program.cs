using System;
using System.Collections.Generic;
using System.Linq;
using PatternTaskAnswers.Adapter;
using PatternTaskAnswers.Builder;
using PatternTaskAnswers.Command;
using PatternTaskAnswers.Singleton;

namespace PatternTaskAnswers.App
{
    public class MoveEntityActionSystemAdapter : IActionSystem
    {
        private readonly MoveEntityActionSystem _moveEntityActionSystem;

        public MoveEntityActionSystemAdapter()
        {
            var cache = EntityCacheSingleton.Instance;
            var pl = EntityCacheSingleton.Instance.GetFirstOfType<PlayerEntity>();
            var movableCreatureComponent = new EntityComponentQuery<MovableCreatureComponent>(
                pl, cache.GetFirstOfType<ConsoleLogger>()).Execute();
            _moveEntityActionSystem = new MoveEntityActionSystem(movableCreatureComponent);
        }

        public void Execute()
        {
            _moveEntityActionSystem.Execute();
        }
    }
    
    public class ConsoleLogger : ILogger
    {
        public void Write(string message)
        {
           Console.WriteLine($"[INFO]: {message}"); 
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var cache = EntityCacheSingleton.Instance;
            var configuration = 
                new DungeonConfigurationBuilder<EmptyDungeonConfiguration>()
                    .WithSize(40, 20) 
                    .WithRoomMinSize(5, 5)
                    .WithRoomMaxSize(7,7)
                    .CountOfRoomsAre(8)
                    .DifficultIs(DungeonDifficult.Hard)
                    .WallSymbolIs(new DungeonSymbol('#', ConsoleColor.White))
                    .FloorSymbolIs(new DungeonSymbol('.', ConsoleColor.White))
                    .Build();
            
            var factory = new DefaultDungeonFactory(configuration);
            
            cache.Registry<EmptyDungeonConfiguration>().GetOrAdd(configuration);
            cache.Registry<DefaultDungeonFactory>().GetOrAdd(factory);
            cache.Registry<ConsoleLogger>().GetOrAdd(new ConsoleLogger()); 
            
            var logger = cache.GetFirstOfType<ConsoleLogger>();
            var player =
                new EntityBuilder<PlayerEntity>(cache)
                    .Registry()
                    .Called("Player")
                    .AddComponent<CreatureCharacteristicsCompotent>()
                    .AddComponent<MovableCreatureComponent>()
                    .AddSystem<MoveEntityActionSystemAdapter>()
                    .Construct();

            /*
            var dungeon = new DungeonBuilder(
                cache.GetFirstOfType<DefaultDungeonFactory>(), 
                cache.GetFirstOfType<EmptyDungeonConfiguration>())
                .GenerateRooms().ConnectAllRooms().Construct();
                */
            
            
            var movableCreatureComponent = new EntityComponentQuery<MovableCreatureComponent>(player, logger).Execute();
            var characteristicsComponent = new EntityComponentQuery<CreatureCharacteristicsCompotent>(player, logger).Execute();
            
            var playerMoveSystem = new EntitySystemQuery<MoveEntityActionSystemAdapter>(player, logger).Execute();
            
            var cmds = new List<IEntityCommand<CreatureCharacteristicsCompotent>>
            {
                new ChangeCharacteristicsAttackCommand(c => 5, logger),
                new ChangeCharacteristicsDefenseCommand(c => 1, logger),
                new ChangeCharacteristicsHpCommand(c => 15, logger), 
                new ChangeCharacteristicsMaxHpCommand(c => 15, logger), 
                new ChangeCharacteristicsMpCommand(c => 5, logger),
                new ChangeCharacteristicsMaxMpCommand(c => 7, logger)
            };

            var moveCmd = new MoveCreatureCommand(playerMoveSystem, movableCreatureComponent, logger);

            foreach (var entityCommand in cmds)
                entityCommand.Execute(characteristicsComponent);

            moveCmd.Execute(playerMoveSystem);
        }
    }
}