using UnityEngine;

public class StoneFX : MonoBehaviour
{
    [SerializeField] private Stone _stone;

    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        _stone.Dig.Subscribe(OnDig);
    }
    private void OnDisable()
    {
        _stone.Dig.Unsubscribe(OnDig);
    }

    private void OnDig(int obj)
    {
        if (_stone.IsDead.Value)
        {
            return;
        }

        _particleSystem.Play();
    }
}