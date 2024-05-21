using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Diamond : MonoBehaviour, IInteractable, ILootable
{
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.AddDiamonds(1);
            Destroy(gameObject);
            Debug.Log("Diamond claimed");
        }
    }

    public void GivePlayer()
    {
        _player.AddDiamonds(1);
        Debug.Log("Diamond from chest claimed");
    }
}
