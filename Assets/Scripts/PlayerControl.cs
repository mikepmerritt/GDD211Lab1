using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Animator Ani;
    [SerializeField] private Transform Stickman;
    [SerializeField] private float Speed;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Ani.SetBool("Moving", true);
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 180f, 0), Time.deltaTime * 5f);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Ani.SetBool("Moving", true);
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0f, 0), Time.deltaTime * 5f);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Ani.SetBool("Moving", false);
        }

        if (Ani.GetBool("Holding") && !Input.GetKey(KeyCode.Space))
        {
            Ani.SetBool("Dropping", true);
            Ani.SetBool("Holding", false);
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pickup") && Input.GetKey(KeyCode.Space))
        {
            Ani.SetBool("Holding", true);
        }
        else if (other.CompareTag("Dropoff"))
        {
            Ani.SetBool("Holding", false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && Ani.GetBool("Holding"))
        {
            Ani.SetBool("Dropping", true);
            Ani.SetBool("Holding", false);
        }
    }

    public void DropSphere()
    {
        InterfaceController.CurrentScore -= 2;
        Ani.SetBool("Dropping", false);
    }

    public void ScoreSphere()
    {
        InterfaceController.CurrentScore += 1;
    }
}
