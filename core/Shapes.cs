using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour {

  public bool m_canRotate = true;

  void Move(Vector3 moveDirection) {
    transform.position += moveDirection;
  }

  public void MoveLeft() {
    Move(new Vector3(-1, 0, 0));
  }

  public void MoveRight() {
    Move(new Vector3(1, 0, 0));
  }

  public void MoveDown() {
    Move(new Vector3(0, -1, 0));
  }

  public void RotateRight() {
    if(m_canRotate) {
      transform.Rotate(0, 0, 90);
    }
  }

  public void RotateLeft() {
    if(m_canRotate) {
      transform.Rotate(0, 0, -90);
    }
  }
  
}
