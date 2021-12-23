using UnityEngine;

public class Parallaxable : MonoBehaviour
{
    [Header("Needed Objects")]
    [SerializeField] private Transform _subject;
    private float _smoothing = 0.8f;
    private Camera _camera;
    private Vector2 _startPos;
    private float _startingZ;
    private float travel => this._camera.transform.position.x - this._startPos.x;
    private float distanceFromSubject => this.transform.position.z - this._subject.transform.position.z;
    private float clippingPlane => (this._camera.transform.position.z + (this.distanceFromSubject > 0 ? this._camera.farClipPlane : this._camera.nearClipPlane));
    private float parallaxFactor => Mathf.Abs(this.distanceFromSubject) / this.clippingPlane;

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
        float newX = this._startPos.x + this.travel * this.parallaxFactor * this._smoothing;
        this.transform.position = new Vector3(newX, this._startPos.y, this._startingZ);
    }

}
