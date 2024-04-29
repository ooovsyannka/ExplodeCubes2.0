using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private Transform _cubeTransform;  

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}

