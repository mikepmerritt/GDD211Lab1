using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;

    void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x, 6f, -15f);
    }
}
