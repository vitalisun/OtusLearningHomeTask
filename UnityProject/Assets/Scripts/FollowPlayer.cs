using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public Vector3 offset = new Vector3(0, 6, -5);


    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
