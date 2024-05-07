using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public class Boulder : MonoBehaviour, IInteractable
{
    [FormerlySerializedAs("GravityForce")] [SerializeField] private float gravityForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityForce;
            Destroy(gameObject, 20f);
        }
    }
}
