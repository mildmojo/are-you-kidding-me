using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Google Analytics integration. Web page must be configured for GA with Google's javascript snippet.
 *
 * Based on a comment from 2010 found here:
 * http://blog.mostlytigerproof.com/2009/10/06/gathering-statistics-using-google-analytics-and-unity-3d/
 *
 * Analytics category/action/label/value descriptions:
 * https://developers.google.com/analytics/devguides/collection/gajs/eventTrackerGuide#Anatomy
 *
 * Examples:
 *   // During app startup
 *   GA.init();
 *
 *   // Elsewhere...
 *   GA.instance.track("game_start");
 *   GA.instance.track("ball_went_too_high", "level_6");
 *   GA.instance.track("game_complete", "seconds_elapsed", (int) Time.time - gameStartedAt);
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
		List<string> args = new List<string>(new string[] {action});
		callGoogleAnalytics(args);
	}

	public void track(string action, string label) {
		List<string> args = new List<string>(new string[] {action, label});
		callGoogleAnalytics(args);
	}

	public void track(string action, string label, int val) {
		List<string> args = new List<string>(new string[] {action, label});
		callGoogleAnalytics(args, val);
	}

	private void callGoogleAnalytics(List<string> args, int? val = null) {
    #if UNITY_WEBPLAYER
		ArrayList all_args = new ArrayList(new string[] {"_trackEvent", ANALYTICS_CATEGORY});
		foreach (string arg in args) {
			all_args.Add(arg);
		}
		if (val.HasValue) {
			all_args.Add(val);
		}
		Application.ExternalCall("_gaq.push", all_args);
//	    Application.ExternalCall("console.log", all_args);
	#endif
		Debug.Log("Analytics: " 
			    + string.Join(", ", args.ToArray())
			    + (val.HasValue ? ", " + val.ToString() : ""));
	}

}
