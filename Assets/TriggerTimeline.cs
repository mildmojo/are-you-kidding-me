using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerTimeline : MonoBehaviour {

  public GameObject FireTrigger;
  public List<TriggerEvent> events = new List<TriggerEvent>(){new TriggerEvent()};

  private int eventCounter;
  private float timerStart;
  private GameObject ball;
  private GUIText guiText;

  void Start () {
    timerStart = Time.time;
    eventCounter = 0;
    guiText = GameObject.Find("GUI Text").GetComponent<GUIText>();
  }

  // Update is called once per frame
  void Update () {
    if (eventCounter < events.Count) {
      if (Time.time - timerStart > events[eventCounter].afterSeconds) {
        // guiText.text = "event " + eventCounter.ToString();
        GameObject pillar = events[eventCounter].target;
        GameObject newFire = (GameObject) GameObject.Instantiate(FireTrigger, pillar.transform.TransformPoint(Vector3.zero), Quaternion.identity);
        newFire.transform.localScale -= new Vector3(0.9f,0.9f,0.9f);
        //guiText.text = Vector3.Distance(newFire.transform.position, pillar.transform.position).ToString();
        //newFire.transform.Rotate(-90,0,0);
        newFire.GetComponent<ScaleEvent>().dieAtSize = events[eventCounter].eventScale;
        Debug.Log("Event " + eventCounter.ToString());
        eventCounter++;
        timerStart = Time.time;
      }
    }
  }

  [System.Serializable]
  public class TriggerEvent {
    public GameObject target;
    public float afterSeconds;
    public float eventScale = 1000f;
  }
}
