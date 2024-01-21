using UnityEngine;

public class StoneAudio : MonoBehaviour
{
    [SerializeField] private Stone _stone;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _stone.Dig.Subscribe(OnDig);
    }

    private void OnDisable()
    {
        _stone.Dig.Unsubscribe(OnDig);
    }

    private void OnDig(int digAmount)
    {
        if (_stone.IsDead.Value)
        {
            return;
        }

        _audioSource.Play();
    }
}