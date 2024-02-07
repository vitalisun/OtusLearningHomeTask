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
        public AtomicEvent TakeDamageEvent = new();
        public AtomicEvent<Zombi> DeathEvent = new();

        //logic
        private FollowTargetMechanics _followTargetMechanics;
        private RotateToTargetMechanics _rotateToTargetMechanics;
        private TakeDamageMechanics _takeDamageMechanics;

        private void Awake()
        {
            Speed.Value = 2;
            State.Value = ZombiStates.Follow;

            _followTargetMechanics = new FollowTargetMechanics(Speed, Target, transform, State);
            _rotateToTargetMechanics = new RotateToTargetMechanics(Target, transform, State);
            _takeDamageMechanics = new TakeDamageMechanics(State, TakeDamageEvent, DeathEvent, this);
        }

        private void Update()
        {
            _followTargetMechanics.Update();
            _rotateToTargetMechanics.Update();
        }

        private void OnEnable()
        {
            _takeDamageMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _takeDamageMechanics.OnDisable();
        }
    }
}