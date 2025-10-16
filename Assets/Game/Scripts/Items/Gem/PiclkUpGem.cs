using UnityEngine;
using System.Collections;

public class PickUpGem : MonoBehaviour, IPickUpItem
{
    [SerializeField] private AudioClip _pickUpSound;
    [SerializeField] private int _prizeCount;
    [SerializeField] private float _respawnTime = 5f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PickUp()
    {
         if (_spriteRenderer.color.a == 0f) return;
        AudioManager.Instance.PlaySound(_pickUpSound);

        SetAlpha(0f);
        GameUI.changeGameCount?.Invoke(_prizeCount);
        StartCoroutine(RespawnGem());
    }

    private void SetAlpha(float alpha)
    {
        if (_spriteRenderer != null)
        {
            Color color = _spriteRenderer.color;
            color.a = alpha;
            _spriteRenderer.color = color;
        }
    }

    private IEnumerator RespawnGem()
    {
        yield return new WaitForSeconds(_respawnTime);
        SetAlpha(1f);
    }
}