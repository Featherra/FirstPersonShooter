using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int enemyMax;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyMax; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }

}
