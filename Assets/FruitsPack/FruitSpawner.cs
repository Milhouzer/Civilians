using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public int forcedIndex = -1;
    public List<GameObject> fruits = new();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            if(forcedIndex < 0)
                Spawn(Random.Range(0, fruits.Count - 1));
            else
                Spawn(forcedIndex);
        }
    }

    void Spawn(int index)
    {
        GameObject prefab = fruits[index];
        GameObject spawnedFruit = Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
