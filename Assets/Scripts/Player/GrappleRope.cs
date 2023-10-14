using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleRope : MonoBehaviour
{
    public Rigidbody2D connectedTo;
    public Vector3 scaleChange;
    private void Update()
    {
        GetComponent<Transform>().LookAt(connectedTo.position);
        GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, Vector3.Distance(connectedTo.position, transform.position), GetComponent<Transform>().localScale.z);
        transform.up = connectedTo.position - new Vector2 (transform.position.x,transform.position.y);
        if (connectedTo == null)
        GetComponent<Transform>().localScale = scaleChange;
    }
}
