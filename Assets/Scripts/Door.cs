using Player_Scripts;
using UnityEngine;

//ПОЧТИ ГОТОВЫЙ СКРИПТ!!! (осталось только анимация)
public class Door : MonoBehaviour
{
    private Collider2D _collider2D;
    
    // Start is called before the first frame update
    void Start() => _collider2D = GetComponent<Collider2D>();

    public void OnCollisionEnter2D(Collision2D other)
    {
        //Проверка на то, что игрок контактирует с дверью
        if (other.collider.CompareTag("Player"))
        {
            var key = other.gameObject.GetComponent<Player>().Key;
            //Проверка на то, что у игрока есть подходящий ключ
            if (key && key.CompareTag("DoorKey"))
            {
                _collider2D.isTrigger = true;
                key.Rigidbody.velocity = new Vector2(0, 0);
                Destroy(key.gameObject);
            }
        }
    }
}
