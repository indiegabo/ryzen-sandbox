using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Needed Objects")]
    [SerializeField] protected List<Transform> _layers;
    [SerializeField] protected float smoothing = 1f;
    protected List<float> _scales;
    protected Transform _cameraTransform;
    protected Vector3 _previousCamPos;

    private void Awake()
    {
        this._cameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        this._previousCamPos = this._cameraTransform.position;
        Debug.Log(this._layers);
        Debug.Log(this._layers[0]);
    }
}
