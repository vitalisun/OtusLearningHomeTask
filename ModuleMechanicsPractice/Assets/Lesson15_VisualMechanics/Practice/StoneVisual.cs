using System.Collections;
using System.Collections.Generic;
using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class StoneVisual : MonoBehaviour
{
    [SerializeField] private Stone _stone;

    private GameObject _stoneChild;

    private void Awake()
    {
        _stoneChild = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        _stone.Death.Subscribe(OnDeath);
        _stone.Respawn.Subscribe(OnRespawn);
    }

    private void OnDisable()
    {
        _stone.Death.Unsubscribe(OnDeath);
        _stone.Respawn.Unsubscribe(OnRespawn);
    }

    private void OnDeath()
    {
        Debug.Log("Stone is dead");
        _stoneChild.SetActive(false);
    }

    private void OnRespawn()
    {
        Debug.Log("Stone is respawn");
        _stoneChild.SetActive(true);
    }
}