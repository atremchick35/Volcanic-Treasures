using Interfaces;
using Player_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour, ILootable
{
    [SerializeField] private AudioSource audioSource;
    private Player _player;

    private void Awake() => _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag(Fields.Tags.Chest) && other.CompareTag(Fields.Tags.PlayerTag))
        {
            audioSource.Play();
            _player.AddDiamonds(Fields.Diamonds.DiamondsAmount);
            Invoke(nameof(LetsDestroy), Fields.Diamonds.DestroyTime);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    
    private void LetsDestroy() => Destroy(gameObject);

    public void GivePlayer() => _player.AddDiamonds(Fields.Diamonds.DiamondsAmount);
    
    public void AnimateDrop(TMP_Text giveItemText, Image giveItemImage)
    {
        giveItemText.text = $"+{Fields.Diamonds.DiamondsAmount}";
        giveItemImage.sprite = Resources.Load<Sprite>("BuffsSprites/gem-1");
    }
}
