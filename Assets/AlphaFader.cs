using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlphaFader : MonoBehaviour {

  public float initialAlpha;

  public List<TriggerEvent> events = new List<TriggerEvent>(){new TriggerEvent()};

  private int eventCounter;
  private float timerStart;

	// Use this for initialization
	void Start () {
    eventCounter = 0;
    timerStart = Time.time;
    iTween.ColorTo(gameObject, iTween.Hash("a", initialAlpha, "time", 0f));
    // iTween.FadeTo(gameObject, 0.25f, 0.5f);
  }

  // Update is called once per frame
  void Update () {
    if (eventCounter < events.Count) {
      if (Time.time - timerStart > events[eventCounter].delay) {
        iTween.FadeTo(gameObject, events[eventCounter].newAlpha, 1.0f);
        eventCounter++;
        timerStart = Time.time;
      }
    }
	}

  [System.Serializable]
  public class TriggerEvent {
    public float delay = 1f;
    public float newAlpha = 1f;
  }
}
