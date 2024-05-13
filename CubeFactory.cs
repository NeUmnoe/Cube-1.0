using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public Cube CreateCube(Vector3 position, Quaternion rotation, float scale, float chanceToSplit)
    {
        Cube cube = Instantiate(_cubePrefab, position, rotation);
        cube.transform.localScale = new Vector3(scale, scale, scale);
        cube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        cube.GetComponent<Splitter>().SetChanceToSplit(chanceToSplit);
        return cube;
    }
}