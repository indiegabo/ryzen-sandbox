using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenEmpoweredAffordance : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] [Range(0.5f, 2f)] private float _empoweredAnimationTime = 1f;
    [SerializeField] [Range(2f, 10f)] private float _empowerenmentScale = 5f;
    [Header("Sound")]
    [SerializeField] private AudioClip _eagleSound;
    [SerializeField] [Range(0f, 1f)] private float _soundVolume = 0.3f;

    // Needed Components
    SpriteRenderer _spriteRenderer;

    // Logic Stuff
    private Color _initialColor;
    private Color _targetColor;
    private Vector3 _initialScale;
    private Vector3 _targetScale;
    private float _startedAt;
    private float _targetTimeElapse;


    private void Awake()
    {
        this._spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this._initialScale = new Vector2(1f, 1f);
        this._targetScale = new Vector2(this._empowerenmentScale, this._empowerenmentScale);
        this._initialColor = this._spriteRenderer.color;
        this._targetColor = new Color(this._initialColor.r, this._initialColor.g, this._initialColor.b, 0f);
        this._startedAt = Time.time;
        if (this._eagleSound != null)
            AudioSource.PlayClipAtPoint(this._eagleSound, Camera.main.transform.position, this._soundVolume);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float elapsedTime = Time.time - this._startedAt;
        Color currentColor = Color.Lerp(this._initialColor, this._targetColor, elapsedTime / this._empoweredAnimationTime);
        Vector3 currentScale = Vector3.Lerp(this._initialScale, this._targetScale, elapsedTime / this._empoweredAnimationTime);
        this._spriteRenderer.color = currentColor;
        this.transform.localScale = currentScale;

        // Check if animation complete
        if (Time.time >= this._startedAt + this._empoweredAnimationTime)
        {
            Destroy(this.gameObject);
        }

    }
}
