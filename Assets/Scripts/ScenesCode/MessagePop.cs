using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePop : MonoBehaviour
{
        public GameObject Message;

        private void Start()
        {
            Message.GetComponent<SpriteRenderer>().enabled = false;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
             Message.GetComponent<SpriteRenderer>().enabled = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            Message.GetComponent<SpriteRenderer>().enabled = false;
        }
}
