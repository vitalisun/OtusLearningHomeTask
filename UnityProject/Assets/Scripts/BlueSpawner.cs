using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] _spawnPoints = {
        new(-2.02f, 0, 5.24f),
        new(-0.2f, 0, 0.73f),
        new(-3.18f, 0, -4.42f)
    };

}
