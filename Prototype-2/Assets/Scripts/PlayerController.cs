using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private float xBound;
  public GameObject foodPrefab;


  // Start is called before the first frame update
  void Start()
  {
    xBound = GameManager.xBound;
  }

  // Update is called once per frame
  void Update()
  {
    // Move player.
    var xInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * xInput * speed * Time.deltaTime);

    // Ensure that we stay in bounds.
    var t = transform.position;
    if (t.x < -xBound)
    {
      // Too far to the left, clamp x at -xBound while maintaning y, and z.
      t.x = -xBound;
      transform.position = t;
    }
    else if (t.x > xBound)
    {
      // Too far to the right...
      t.x = xBound;
      transform.position = t;
    }

    // Launch food when spacebar is pressed.
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
    }
  }
}
