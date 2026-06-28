using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _tagertPrefab;

    private float[] rangeX = { -2.5f, 2.5f };
    private float[] rangeY = { -0.2f, 2.8f };

    private void Start()
    {
        StartCoroutine(TargetSpawn());
    }

    private void Update()
    {
        
    }

    private IEnumerator TargetSpawn()
    {
        Instantiate(_tagertPrefab, new Vector3(Random.Range(rangeX[0], rangeX[1]), Random.Range(rangeY[0], rangeY[1]), 0f), Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(TargetSpawn());
    }
}
