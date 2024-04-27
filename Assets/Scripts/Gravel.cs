using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public class Gravel : MonoBehaviour, IInteractable
{
    private Collider2D _collider2D;
    [FormerlySerializedAs("Delay")] [SerializeField] private float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gravel crumbling");
            _collider2D.isTrigger = false;
            Destroy(gameObject, delay);
            // StartCoroutine(Timer(delay));
        }
    }

    // private IEnumerator Timer(float duration)  {
    //     // Eventual code to execute right as the function is called
    //     yield return new WaitForSeconds(duration);
    //     // The code from here will be executed after **duration** seconds
    //     Destroy(gameObject);
    //     Debug.Log("Gravel crumbled");
    // }
}
