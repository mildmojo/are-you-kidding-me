using UnityEngine;
using System.Collections;

/* Based on a comment from 2010 found here:
 * http://blog.mostlytigerproof.com/2009/10/06/gathering-statistics-using-google-analytics-and-unity-3d/
 *
 * Analytics category/action/label/value descriptions:
 * https://developers.google.com/analytics/devguides/collection/gajs/eventTrackerGuide#Anatomy
 *
 * Usage: GA.instance.track("game_start");
 *        GA.instance.track("ball_went_too_high", "level_6");
 *        GA.instance.track("game_complete", "seconds_elapsed", (int) Time.time - gameStartedAt);
  */
public class GA {
	
	public static GA instance = null;
	
	private const string ANALYTICS_CATEGORY = "MeatWebplayer";
	
	public static void init() {
		if (instance == null) {
			instance = new GA();
		}
	}
	
	public void track(string action) {
		string args = "'" + action + "'";
		callGoogleAnalytics(args);
	}
	
	public void track(string action, string label) {
		string args = "'" + action + "'"
			        + ", '" + label + "'";
		callGoogleAnalytics(args);
	}
	
	public void track(string action, string label, int val) {
		string args = "'" + action + "'"
			        + ", '" + label + "'"
			        + ", " + val.ToString();
		callGoogleAnalytics(args);
	}
	
	private void callGoogleAnalytics(string args) {
    #if UNITY_WEBPLAYER
		Application.ExternalCall("_gaq.push", 
		                         "['_trackEvent','" + ANALYTICS_CATEGORY + "', " + args + "]");
    #endif
	Debug.Log("Analytics: " + args);
	}
	
}
