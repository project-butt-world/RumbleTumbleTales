using UnityEngine;
using System.Collections;

public class PlayerTouch : MonoBehaviour {
	public Animator anim;
	public float speed = 0.1F;
	public GameObject arse; 
	public bool facingRight = true;	
	public Transform objToPickUp;

	void Start(){

		arse = GameObject.Find("FizzFlip");
		objToPickUp = this.transform;


		}


	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
						Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
						transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
						anim.SetBool ("walk_dammit", true);
			        //    arse = GameObject.Find("FizzFlip");
			 //           transform.localScale=(-1,1,0);
			flip ();
			OnAnimatorIK();

				} 

		else {
						anim.SetBool ("walk_dammit", false);
				}
	}

	void flip(){
				// Switch the way the player is labelled as facing.
				facingRight = !facingRight;
	
				// Multiply the player's x local scale by -1.
				Vector3 theScale = arse.transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		     //   anim.SetIKRotation = -1;
		}
	//number should be int layerindex
	void OnAnimatorIK() {
		float reach = anim.GetFloat("RightHandReach");
		anim.SetIKPositionWeight(AvatarIKGoal.RightHand, reach);
		anim.SetIKPosition(AvatarIKGoal.RightHand, objToPickUp.position);
	}


}