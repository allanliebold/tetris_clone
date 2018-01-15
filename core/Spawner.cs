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
}
