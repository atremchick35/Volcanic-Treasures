using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public Key Key { get; set; }
    public IEffectable[] Effects { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Door") && Key && Key.CompareTag("DoorKey"))
        {
            other.collider.isTrigger = true;
            Key.rb.velocity = new Vector2(0, 0);
            Destroy(Key.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chest") && Key && Key.CompareTag("ChestKey"))
        {
            Key.rb.velocity = new Vector2(0, 0);
            Destroy(Key.gameObject);
        }
    }
}