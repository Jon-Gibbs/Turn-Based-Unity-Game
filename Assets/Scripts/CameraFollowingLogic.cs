using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingLogic : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (player != null)
        {
           
            transform.position = player.position + offset;
        
        }
    }
}
