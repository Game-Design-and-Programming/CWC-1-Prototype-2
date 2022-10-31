using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  // Singleton.
  public static GameManager instance { get; private set; }

  [SerializeField]
  private int _lives;
  public int lives 
  {
    get { return _lives; }
    
    set {
      _lives = value;
      if (_lives <= 0)
      {
        // XXX <0 ?
        baseSpeed = 0;
        Debug.Log($"Game over!");
      }
      else
      {
        Debug.Log($"Lives: {_lives}");
      }
    }
  }
  [SerializeField]
  private int _score;
  public int score
  {
    get { return _score; }
    set { _score = value; }
  }

  // The base speed for all moving game objects. Set to 0 to freeze game.
  [SerializeField]
  public float _baseSpeed; // XXX - make private after tuning.
  public float baseSpeed
  {
    get { return _baseSpeed; }
    set { _baseSpeed = value; }
  }

  [SerializeField]
  public float _xBound;   // XXX - make private after tuning.
  public float xBound
  {
    get { return _xBound; }
    set { _xBound = value; }
  }

  // Start is called before the first frame update
  void Awake()
  {
    if (instance != null && instance != this)
    {
      // We're a singleton, don't allow new instances.
      Destroy(this);
    }
    else
    {
      // Set instance on first call.
      instance = this;
      ResetGame();
    }
  }

  // Update is called once per frame
  void ResetGame()
  {
    lives = 3;
    score = 0;
    baseSpeed = 10;
    xBound = 18;
  }
}
