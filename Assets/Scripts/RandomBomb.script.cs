using TheAdventure.Scripting;
using System;
using TheAdventure;

public class RandomBomb : IScript
{
    DateTimeOffset _nextBombTimestamp;

    public void Initialize()
    {
        _nextBombTimestamp = DateTimeOffset.UtcNow.AddSeconds(Random.Shared.Next(2, 3));
    }

    public void Execute(Engine engine)
    {
        if (_nextBombTimestamp < DateTimeOffset.UtcNow)
        {
            _nextBombTimestamp = DateTimeOffset.UtcNow.AddSeconds(Random.Shared.Next(2, 3));
            var playerPos = engine.GetPlayerPosition();
            var bombPosX = playerPos.X + Random.Shared.Next(-75, 75);
            var bombPosY = playerPos.Y + Random.Shared.Next(-75, 75);
            engine.AddBomb(bombPosX, bombPosY, false);
        }
    }
}