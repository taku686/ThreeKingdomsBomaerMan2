using UnityEngine;
using Zenject;

namespace AttributeAttack.Sample
{
    public class Initializer : IInitializable, ITickable
    {
        private readonly Player.Factory _playerFactory;
        private Player _player;

        public Initializer
        (
            Player.Factory playerFactory
        )
        {
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            _player ??= _playerFactory.Create();
        }


        public void Tick()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            _player.Attack();
        }
    }
}