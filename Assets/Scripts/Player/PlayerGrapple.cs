using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Grapple Point"))
        {
            Debug.Log("grap time");
            transform.parent.GetComponent<PlayerControlls>().bGrappleReady = true;
            transform.parent.GetComponentInChildren<GrappleRope>().connectedTo = collision.GetComponent<Rigidbody2D>();
            transform.parent.GetComponent<SpringJoint2D>().connectedBody = collision.GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grapple Point"))
        {
            Debug.Log("grap no");
            transform.parent.GetComponent<PlayerControlls>().bGrappleReady = false;
            transform.parent.GetComponentInChildren<GrappleRope>().connectedTo = null;
            transform.parent.GetComponent<SpringJoint2D>().connectedBody = null;
        }
    }
}
