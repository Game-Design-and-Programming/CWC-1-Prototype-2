using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public float xBound;


  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
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
  }
}
