using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Cube _cube;

    private void OnEnable()
    {
        _cube.CubeDestroyed += InstantiatePrefab;
    }

    private void OnDisable()
    {
        _cube.CubeDestroyed -= InstantiatePrefab;
    }

    public void InstantiatePrefab()
    {
        Instantiate(_prefab, _cube.transform.position, Quaternion.identity);
    }
}
