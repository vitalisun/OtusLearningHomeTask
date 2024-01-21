using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class LifeTimeMechanics
{
    private AtomicVariable<float> _lifeTime;
    private AtomicEvent _death;
    private readonly GameObject _obj;

    public LifeTimeMechanics(AtomicVariable<float> lifeTime, AtomicEvent death, GameObject obj)
    {
        _lifeTime = lifeTime;
        _death = death;
        _obj = obj;
    }

    public void Update()
    {
        _lifeTime.Value -= Time.deltaTime;

        if (_lifeTime.Value <= 0)
        {
            Debug.Log("Bullet is dead");
            _death.Invoke();
            Object.Destroy(_obj);
        }
    }
}