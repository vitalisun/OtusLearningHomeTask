using Assets.Scripts.Shared;
using UnityEngine;

public class RotateMechanics
{
    private readonly AtomicVariable<Vector3> _rotationTargetPoint;
    private readonly AtomicVariable<int> _rotationSpeed;
    private readonly Transform _transform;

    public RotateMechanics(AtomicVariable<Vector3> rotationTargetPoint, Transform transform, AtomicVariable<int> rotationSpeed)
    {
        _rotationTargetPoint = rotationTargetPoint;
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public void Update(float deltaTime)
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = _rotationTargetPoint.Value - _transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = _rotationSpeed.Value * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(_transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(_transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        _transform.rotation = Quaternion.LookRotation(newDirection);
    }
}