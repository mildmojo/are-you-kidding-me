using UnityEngine;
using System.Collections;
using System.Linq;

public class CameraMover : MonoBehaviour {

  public float unitsPerSecond;

  void Start () {
    Vector3[] path = iTweenPath.GetPath("CameraDolly");
    //Camera.current.transform.position = path.First();
    Debug.Log(path.First());
    Debug.Log(path.Last());
    //Debug.Log(path.Count);
    iTween.MoveTo(gameObject,
                  iTween.Hash("path", path,
                              "time", (path.First() - path.Last()).magnitude / unitsPerSecond,
                              "easetype", iTween.EaseType.linear));
  }

}
