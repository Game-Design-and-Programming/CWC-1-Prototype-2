using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
      livesText.text = $"Lives: {_lives}";

      if (_lives <= 0)
      {
        // XXX <0 ?
        StopGame();
        instructionsText.text = $"Game over!";
        instructionsText.enabled = true;
        startButton.gameObject.SetActive(true);
      }
    }
  }
  [SerializeField]
  private int _score;
  public int score
  {
    get { return _score; }
    set {
          _score = value;
          scoreText.text = $"Score: {_score}";
        }
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

  // Awake is called when the object becomes active in the game
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
      StopGame();
    }
  }

  // UI
  public Button startButton;
  public TMP_Text instructionsText;
  public TMP_Text livesText;
  public TMP_Text scoreText;

  public void StartButtonOnClick()
  {
    //Debug.Log($"Start button clicked");
    instructionsText.enabled = false;
    startButton.gameObject.SetActive(false);
    StartGame();
  }

  // Game management helpers
  void StartGame()
  {
    ResetGame();
  }

  void StopGame()
  {
    baseSpeed = 0;
  }
  void ResetGame()
  {
    lives = 3;
    score = 0;
    baseSpeed = 10;
    xBound = 18;
  }
}
