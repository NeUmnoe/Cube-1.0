using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _splitChanceDecay = 0.5f;
    [SerializeField] private float _positionOffset = 0.5f;

    private float _chanceToSplit = 1f;

    public void SetChanceToSplit(float chance)
    {
        _chanceToSplit = chance;
    }

    public void SplitCube()
    {
        if (Random.value < _chanceToSplit)
        {
            int numCubes = Random.Range(_minCubes, _maxCubes + 1);
            Vector3 explosionPoint = transform.position;
            float newChanceToSplit = _chanceToSplit * _splitChanceDecay;

            for (int i = 0; i < numCubes; i++)
            {
                Vector3 position = explosionPoint + Random.insideUnitSphere * _positionOffset;
                Cube newCube = _cubeFactory.CreateCube(position, Random.rotation, transform.localScale.x * _scaleFactor, newChanceToSplit);
                Rigidbody newCubeRigidbody = newCube.GetComponent<Rigidbody>();
                newCubeRigidbody.AddExplosionForce(_explosionForce, explosionPoint, _explosionRadius);
            }
        }

        Destroy(gameObject);  
    }
}