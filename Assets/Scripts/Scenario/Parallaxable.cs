using UnityEngine;

public class Parallaxable : MonoBehaviour
{
    [Header("Needed Objects")]
    [SerializeField] private Transform _subject;
    private float _smoothing = 0.3f;
    private Camera _camera;
    private Vector2 _startPos;
    private float _startingZ;
    private float _travel => this._camera.transform.position.x - this._startPos.x;
    private float _distanceFromSubject => this.transform.position.z - this._subject.transform.position.z;
    private float _clippingPlane => this._camera.transform.position.z + this._camera.farClipPlane;
    // private float _clippingPlane => (this._camera.transform.position.z + (this._distanceFromSubject > 0 ? this._camera.farClipPlane : this._camera.nearClipPlane));
    private float _parallaxFactor => Mathf.Abs(this._distanceFromSubject) / this._clippingPlane;

    private void Awake()
    {
        this._camera = Camera.main;
    }

    private void Start()
    {
        this._startPos = this.transform.position;
        this._startingZ = this.transform.position.z;
    }

    private void Update()
    {
        float newX = this._startPos.x + this._travel * this._parallaxFactor * this._smoothing;
        this.transform.position = new Vector3(newX, this._startPos.y, this._startingZ);
    }

}
