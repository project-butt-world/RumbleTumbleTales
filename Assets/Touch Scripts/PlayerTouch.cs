using UnityEngine;
using System.Collections;

public class PlayerTouch : MonoBehaviour {
	public Animator anim;
	public float speed = 0.1F;
	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
						Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
						transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
						anim.SetBool ("walk_dammit", true);

				} 

		else {
						anim.SetBool ("walk_dammit", false);
				}
	}
}