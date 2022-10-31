using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
  public float upperBound;
  public float lowerBound;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.z > upperBound)
    {
      Destroy(gameObject);
    }
    else if (transform.position.z < lowerBound)
    {
      Destroy(gameObject);
      if (--GameManager.lives <= 0)
      {
        Debug.Log("Game over!");
      }
      else
      {
        Debug.Log($"Lives: {GameManager.lives}");
      }
    }
  }
}
