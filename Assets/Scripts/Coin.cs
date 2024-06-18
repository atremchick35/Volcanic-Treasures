using Interfaces;
using Player_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour, ILootable
{
    [SerializeField] private AudioSource audioSource;
    private int _amount;
    private Player _player;

    private void Awake() => _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            audioSource.Play();
            _player.AddCoins(Fields.Coins.Min);
            Invoke(nameof(LetsDestroy), Fields.Coins.DestroyTime);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void LetsDestroy() => Destroy(gameObject);

    public void GivePlayer()
    {
        _amount = Random.Range(Fields.Coins.Min, Fields.Coins.Max);
        _player.AddCoins(_amount);
    }

    public void AnimateDrop(TMP_Text giveItemText, Image giveItemImage)
    {
        giveItemText.text = $"+{_amount}";
        giveItemImage.sprite = Resources.Load<Sprite>("BuffsSprites/coin_0");
    }
}