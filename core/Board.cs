using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

  public Transform m_emptySprite;
  public int m_height = 30, m_width = 10;

  void Start() {

  }

  void DrawEmptyCells() {
    for(int y = 0; y < m_height; y++) {
      for(int x = 0; x < m_width; x++) {
        Transform clone;
        clone = Instantiate(m_emptySprite, new Vector3(x, y, 0), Quaternion.identity) as Transform;
        clone.name = "Board Space(x: " + x.ToString() + ", y: " + y.ToString() + ")";
        clone.transform.parent = transform;
      }
    }
  }
}
