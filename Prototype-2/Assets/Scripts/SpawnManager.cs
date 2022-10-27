using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] animalPrefabs;

  private float spawnRangeX = 20; // XXX get xBound from PlayerController.
  private float spawnPosZ = 20;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.S))
    {
      // Generate spawn position with random location on X-axis.
      var spawnPos = new Vector3(
        Random.Range(-spawnRangeX, spawnRangeX),
        0, 
        spawnPosZ
      );
      // Select a random animal. Have to declare as 'int' otherwise we
      // might get the wrong Random.Range().
      int animalIndex = Random.Range(0, animalPrefabs.Length);
      // Spawn the animal.
      Instantiate(
        animalPrefabs[animalIndex],
        spawnPos,
        animalPrefabs[animalIndex].transform.rotation
      );
    }
  }
}
