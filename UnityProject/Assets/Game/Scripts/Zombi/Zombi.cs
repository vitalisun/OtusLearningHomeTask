using Assets.Game.Scripts.Shared;
using Assets.Game.Scripts.Zombi.Mechanics;
using UnityEngine;

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

        //logic
        private FollowTargetMechanics _followTargetMechanics;
        private RotateToTargetMechanics _rotateToTargetMechanics;
        private ZombiTakeDamageMechanics _zombiTakeDamageMechanics;
        private AttackMechanics _attackMechanics;

        private void Awake()
        {
            Speed.Value = 2;
            State.Value = ZombiStates.Follow;

            _followTargetMechanics = new FollowTargetMechanics(Speed, Target, transform, State);
            _rotateToTargetMechanics = new RotateToTargetMechanics(Target, transform, State);
            _zombiTakeDamageMechanics = new ZombiTakeDamageMechanics(State, TakeDamageEvent, DeathEvent, this);
            _attackMechanics = new AttackMechanics(State, Target);
        }

        private void Update()
        {
            _followTargetMechanics.Update();
            _rotateToTargetMechanics.Update();
            _attackMechanics.Update(Time.deltaTime);
        }

        private void OnEnable()
        {
            _zombiTakeDamageMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _zombiTakeDamageMechanics.OnDisable();
        }
    }
}