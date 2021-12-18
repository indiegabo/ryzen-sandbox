using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectiles/ProjectileScriptableObject", order = 1)]
public class ProjectileScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] [Range(5f, 50f)] private float _power = 10f;
    [SerializeField] [Range(5f, 50f)] private float _speed = 10f;

}
