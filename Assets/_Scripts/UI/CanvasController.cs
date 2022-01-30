using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [Header("Loading Shoot Slider")]
    [SerializeField] private Slider _loadingShootSlider;
    [SerializeField] private float _startingValue = 0f;

    public static CanvasController Instance;

    private void Awake()
    {
        Instance = this;

        this.EnableLoadingShootSlider();
    }
    public void EnableLoadingShootSlider()
    {
        this._loadingShootSlider.gameObject.SetActive(true);
        this._loadingShootSlider.value = this._startingValue;
    }

    public void DisableLoadingShootSlider()
    {
        this._loadingShootSlider.gameObject.SetActive(false);
        this._loadingShootSlider.value = this._startingValue;
    }

    public void SetLoadingShootSlider(float value)
    {
        if (!this._loadingShootSlider.IsActive())
            return;
        this._loadingShootSlider.value = value;
    }
}
