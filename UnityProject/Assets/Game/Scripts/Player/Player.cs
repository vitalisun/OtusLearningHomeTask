using Assets.Game.Scripts.Player.Mechanics;
using Assets.Game.Scripts.Shared;
using UnityEngine;

namespace Assets.Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        // data
        public AtomicVariable<float> Speed = new();
        public AtomicVariable<Vector3> MoveDirection;
        public AtomicVariable<Vector3> LocalMovementDirection;

        public AtomicVariable<Vector3> RotationTargetPoint = new();
        public AtomicVariable<int> RotationSpeed = new();

        public AtomicVariable<int> BulletAmount = new();
        public AtomicEvent FireRequest = new();
        public AtomicEvent FireEvent = new();

        // logic
        private CharacterMovementMechanics _movementMechanics;
        private GetLocalMovementDirectionMechanics _getLocalMovementDirectionMechanics;
        private RotateMechanics _rotateMechanics;
        private RestoreBulletsOverTimeMechanics _restoreBulletsOverTimeMechanics;
        private FireMechanics _fireMechanics;

        private void Awake()
        {
            Speed.Value = 5;
            RotationSpeed.Value = 5;
            _movementMechanics = new CharacterMovementMechanics(Speed, MoveDirection, transform);
            _rotateMechanics = new RotateMechanics(RotationTargetPoint, transform, RotationSpeed);
            _restoreBulletsOverTimeMechanics = new RestoreBulletsOverTimeMechanics(BulletAmount);
            _fireMechanics = new FireMechanics(BulletAmount, FireRequest, FireEvent);
            _getLocalMovementDirectionMechanics = 
                new GetLocalMovementDirectionMechanics(MoveDirection, LocalMovementDirection, transform);
        }

        private void Update()
        {
            _movementMechanics.Update(Time.deltaTime);
            _rotateMechanics.Update(Time.deltaTime);
            _restoreBulletsOverTimeMechanics.Update(Time.deltaTime);
            _getLocalMovementDirectionMechanics.Update();
        }

        private void OnEnable()
        {
            _fireMechanics.OnEnable();
        }

        private void OnDisable()
        {
            _fireMechanics.OnDisable();
        }
    }
}