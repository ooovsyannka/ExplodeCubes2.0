using System;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explodeForce;
    [SerializeField] private float _explodeRadius;
    [SerializeField] private Particle _effect;

    public event Action CubeDestroyed;

    private void OnMouseUpAsButton()
    {
        CubeDestroyed?.Invoke();
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject())
        {
            explodableObject.AddExplosionForce(GetExplodeForce(explodableObject.transform), transform.position, _explodeRadius);
        }
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explodeRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }

    private float GetExplodeForce(Transform objectPosition)
    {
        int divisionDistance = 10;
        float distance = Vector3.Distance(transform.position, objectPosition.position) / divisionDistance;

        return _explodeForce / distance;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, _explodeRadius);
    }
}
