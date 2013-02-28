using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerTimeline : MonoBehaviour {

  public GameObject FireTrigger;
  public List<TriggerEvent> events = new List<TriggerEvent>(){new TriggerEvent()};

  private int eventCounter;
  private float timerStart;
  private GameObject ball;

  void Start () {
    timerStart = Time.time;
    eventCounter = 0;
  }

  // Update is called once per frame
  void Update () {
    if (eventCounter < events.Count) {
      if (Time.time - timerStart > events[eventCounter].afterSeconds) {
        GameObject pillar = events[eventCounter].target;
        GameObject newFire = (GameObject) GameObject.Instantiate(FireTrigger, new Vector3(pillar.transform.position.x, -7, pillar.transform.position.z), pillar.transform.rotation);
        newFire.transform.Rotate(-90,0,0);
        eventCounter++;
        timerStart = Time.time;
      }
    }
  }

  [System.Serializable]
  public class TriggerEvent {
    public GameObject target;
    public float afterSeconds;
  }
}
