using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

  public Shapes[] m_allShapes;

  Shapes GetRandomShape() {
    int i = RandomRange(0, m_allShapes.Length);
    if(m_allShapes[i]) {
      return m_allShapes[i];
    } else {
      Debug.log("Warning! Invalid shape");
      return null;
    }
  }

  public Shapes SpawnShape() {
    Shapes shape = null;
    shape = Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shapes;
    if(shape) {
      return shape;
    } else {
      Debig.LogWarning("Warning! Invalid shape in spawner");
      return null;
    }
  }
}
