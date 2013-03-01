using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetCameraRenderMode : MonoBehaviour {

  // Use this for initialization
  void Awake () {
    camera.transparencySortMode = TransparencySortMode.Orthographic;
  }

  // Update is called once per frame
  void Update () {

  }
}
