using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [Header("Loading Shoot Slider")]
    [SerializeField] private Slider _loadingShootSlider;
    [SerializeField] private float _startingValue = 0f;
    private void Awake()
    {
        this.ActivateLoadingShootSlider(false);
    }
    public void ActivateLoadingShootSlider(bool active)
    {
        this._loadingShootSlider.gameObject.SetActive(active);
        this._loadingShootSlider.value = this._startingValue;
    }

    public void SetLoadingShootSlider(float value)
    {
        if (!this._loadingShootSlider.IsActive())
            return;
        this._loadingShootSlider.value = value;
    }
}
