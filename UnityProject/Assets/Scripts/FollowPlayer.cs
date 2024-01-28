using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public Vector3 offset;
   

    private void Awake()
    {
        offset = new Vector3(0, 8, -8);
        transform.rotation = Quaternion.Euler(40, 0, 0);
    }

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
