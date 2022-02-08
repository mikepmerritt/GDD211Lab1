using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float SpeedModifier;
    [SerializeField] private Animator Ani;

    private void Update()
    {
        Ani.SetBool("Moving", true);
        
        if (transform.position.z > 8.75)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90f, transform.eulerAngles.z);
            SpeedModifier = -1;
        }
        else if (transform.position.z < -8.75)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90f, transform.eulerAngles.z);
            SpeedModifier = 1;
        }

        transform.position += new Vector3(0, 0, Speed * SpeedModifier * Time.deltaTime);
    }
}
