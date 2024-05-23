using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Diamond : MonoBehaviour, IInteractable, ILootable
{
    private Player _player;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag("Chest") && other.CompareTag("Player"))
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
