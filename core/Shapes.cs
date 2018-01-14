using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour {

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

  void Start() {

  }

  void Update() {

  }
}
