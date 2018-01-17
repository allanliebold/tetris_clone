using UnityEngine;
using System.Collections;

public class GameController : MonoBehavious {

  private Board m_gameBoard;
  private Spawner m_spawner;

  Shapes m_activeShape;

  float m_dropInterval = 0.25f, m_timeToDrop, m_timeToNextKey;

  [Range(0.02f, 1f)]
  public float m_keyRepeatRate = 0.25f;

  void Start() {
    m_gameBoard = FindObjectOfType<Board>();
    m_spawner = FindObjectOfType<Spawner>();
    m_timeToNextKey = Time.time;

    if(m_spawner) {
      m_spawner.transform.position = Vectorf.Round(m_spawner.transform.position);

      if(m_activeShape == null) {
        m_activeShape = m_spawner.SpawnShape();
      }
    } else {
      Debug.LogWarning("Warning! No spawner defined");
    }
  }

  void Update() {
    if(!m_gameBoard || !m_spawner || !m_activeShape) {
      return;
    }

    PlayerInput();
  }

  void PlayerInput() {
    if(Input.GetButton("MoveRight") && Time.time > m_timeToNextKey || Input.GetButtonDown("MoveRight")) {
        m_activeShape.MoveRight();
        m_timeToNextKey = Time.time + m_keyRepeatRate;

        if(!m_gameBoard.IsValidPosition(m_activeShape)) {
          m_activeShape.MoveLeft();
        }
    }

    if(Input.GetButton("MoveLeft") && Time.time > m_timeToNextKey || Input.GetButtonDown("MoveLeft")) {
        m_activeShape.MoveLeft();
        m_timeToNextKey = Time.time + m_keyRepeatRate;

        if(!m_gameBoard.IsValidPosition(m_activeShape)) {
          m_activeShape.MoveRight();
        }
    }

    if(Input.GetButton("Rotate") && Time.time > m_timeToNextKey) {
      m_activeShape.RotateRight();
      m_timeToNextKey = Time.time + m_keyRepeatRate;

      if(!m_gameBoard.IsValidPosition(m_activeShape)) {
        m_activeShape.RotateLeft();
      }
    }

    if(Input.GetButtonDown("MoveDown")) {
      m_dropInterval = m_dropInterval / 4;
    }


    if(Input.GetButtonUp("MoveDown")) {
      m_dropInterval = m_dropInterval * 4;
    }

    if(Time.time > m_timeToDrop) {
      m_timeToDrop = Time.time + m_dropInterval;
      if(m_activeShape) {
        m_activeShape.MoveDown();

        if(!m_gameBoard.IsValidPosition(m_activeShape)) {
          if( m_gameBoard.OverLimit(m_activeShape)) {
            GameOver();
          } else {
            LandShape();
        }
      }
    }
  }

  void LandShape() {
    m_timeToNextKey = Time.time;
    m_activeShape.MoveUp();
    m_gameBoard.StoreShapeInGrid(m_activeShape);
    m_activeShape = m_spawner.SpawnShape();
    m_gameBoard.ClearAllRows();
  }

  void GameOver() {
    m_activeShape.MoveUp();
    m_gameOver = true;
    if(m_gameOverPanel) {
      m_gameOverPanel.SetActive(true);
    }
  }
}
