using UnityEngine;

public class Parallaxable
{
    private Transform _layerTransform;
    private float _scale;

    public Parallaxable(Transform layerTransform, float scale)
    {
        this._layerTransform = layerTransform;
        this._scale = scale;
    }

    public Transform layerTransform
    {
        get { return this._layerTransform; }
        set { this._layerTransform = value; }
    }
    public float scale
    {
        get { return this._scale; }
        set { this._scale = value; }
    }
}
