using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Needed Objects")]
    [SerializeField] protected List<Transform> _layers;
    [SerializeField] protected float smoothing = 1f;
    protected List<Parallaxable> _parallaxables = new List<Parallaxable>();
    protected Transform _cameraTransform;
    protected Vector3 _previousCamPos;

    private void Awake()
    {
        this._cameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        this._previousCamPos = this._cameraTransform.position;
        this._layers.ForEach(CreateParallaxable);
    }

    private void Update()
    {
        this._parallaxables.ForEach(UpdateParalaxForLayer);
        this._previousCamPos = this._cameraTransform.position;
    }

    private void CreateParallaxable(Transform layerTransform)
    {
        float scale = layerTransform.position.z * -1;
        Parallaxable parallaxable = new Parallaxable(layerTransform, scale);
        this._parallaxables.Add(parallaxable);
    }

    private void UpdateParalaxForLayer(Parallaxable parallaxable)
    {
        float parallax = (this._previousCamPos.x - this._cameraTransform.position.x) * parallaxable.scale;
        float parallaxableTargetPosX = parallaxable.layerTransform.position.x + parallax;
        Vector3 parallaxableTargetPos = new Vector3(parallaxableTargetPosX, parallaxable.layerTransform.position.y, parallaxable.layerTransform.position.z);
        parallaxable.layerTransform.position = Vector3.Lerp(parallaxable.layerTransform.position, parallaxableTargetPos, this.smoothing * Time.deltaTime);
    }
}
