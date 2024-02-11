using Assets.Game.Scripts.Shared;
using Assets.Game.Scripts.Zombi.Mechanics;
using UnityEngine;
using static Assets.Game.Scripts.GameManager.Listeners;
using NotImplementedException = System.NotImplementedException;

namespace Assets.Game.Scripts.Zombi
{
    public class Zombi : MonoBehaviour
    {
        //data
        public AtomicVariable<float> Speed = new();
        public AtomicVariable<Transform> Target = new();

        public AtomicVariable<ZombiStates> State = new();
        public AtomicEvent<int> TakeDamageEvent = new();
        public AtomicEvent<Zombi> DeathEvent = new();

        public AtomicEvent AttackRequest = new();

        //logic
        private FollowTargetMechanics _followTargetMechanics;
        private RotateToTargetMechanics _rotateToTargetMechanics;
        private ZombiTakeDamageMechanics _zombiTakeDamageMechanics;
        private AttackMechanics _attackMechanics;

        private void Awake()
        {
            Speed.Value = 4;
            State.Value = ZombiStates.Follow;

            _followTargetMechanics = new FollowTargetMechanics(Speed, Target, transform, State);
            _rotateToTargetMechanics = new RotateToTargetMechanics(Target, transform, State);
            _zombiTakeDamageMechanics = new ZombiTakeDamageMechanics(State, TakeDamageEvent, DeathEvent, Target, this);
            _attackMechanics = new AttackMechanics(State, Target, AttackRequest);
        }

        private void Update()
        {
            _followTargetMechanics.Update();
            _rotateToTargetMechanics.Update();
        }

        private void OnEnable()
        {
            _zombiTakeDamageMechanics.OnEnable();
            _attackMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _zombiTakeDamageMechanics.OnDisable();
            _attackMechanics.OnDisable();
        }
    }
}