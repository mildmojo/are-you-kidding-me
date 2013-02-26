using UnityEngine;
using System.Collections;

public class LinearRestrictor : MonoBehaviour {

    private Vector3    original_position;
    private Quaternion original_rotation;

	void Start () {
        original_position = transform.position;
        original_rotation = transform.rotation;
	}

	void Update () {
//        Debug.DrawRay(original_position, transform.position - original_position, Color.cyan);
        //Debug.Log (transform.InverseTransformDirection(transform.position - original_position));
        if (transform.InverseTransformDirection(transform.position - original_position).z < 0) {
            // Reset to original position.
            transform.position = original_position;
            transform.rotation = original_rotation;
            if (!rigidbody.isKinematic) {
                rigidbody.velocity = Vector3.zero;

                // Turn off physics until acted upon by something else.
                rigidbody.isKinematic = true;
            }
        }
	}
}
