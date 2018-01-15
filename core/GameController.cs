using UnityEngine;
using System.Collections;

public class GameController : MonoBehavious {

  private Board m_gameBoard;
  private Spawner m_spawner;

  Shapes m_activeShape;

  float m_dropInterval = 0.25f, m_timeToDrop;

  [Range(0.02f, 1f)]
  public float m_keyRepeatRate = 0.25f;

  void Start() {
    m_gameBoard = FindObjectOfType<Board>();
    m_spawner = FindObjectOfType<Spawner>();

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

  }
}
