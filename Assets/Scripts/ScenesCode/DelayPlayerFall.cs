using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DelayPlayerFall : MonoBehaviour
{
    private Rigidbody2D rigidbody2;

    private void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(delayFall());
        }
    }
    IEnumerator delayFall()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        rigidbody2.isKinematic = true;
        yield return new WaitForSeconds(7);
        rigidbody2.isKinematic = false;
    }
}
