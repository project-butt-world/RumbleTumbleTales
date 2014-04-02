using UnityEngine;
using System.Collections;



public class Test3Dtouchable : MonoBehaviour,ITouchable3D {

	public int touch2Watch = 64;
	public float maxDist=1f;
	public float speed = 1f;
	private Vector3 finger;
	private Transform myTrans, camTrans;

	void Start () 
	{
		myTrans = this.transform;
		camTrans = Camera.main.transform;
	}

	#region ITouchable3D implementation
	public void OnTouchBegan ()
	{
		Debug.Log ("began,yo");
	}
	public void OnTouchEnded ()
	{
//		Debug.Log("nice touch, ending");
	}
	public void OnTouchMoved ()
	{
		//z of ScreenToWorldPoint is distance from camera into the world, so we need to find this object's distance from the camera to make it stay on the same plane
		Vector3 tempTouch = new Vector3(Input.GetTouch(touch2Watch).position.x, Input.GetTouch(touch2Watch).position.y,camTrans.position.y - myTrans.position.y);
		//Convert screen to world space
		finger = Camera.main.ScreenToWorldPoint(tempTouch);
		
		//look at finger position
		myTrans.LookAt(finger);
		
		//move towards finger if not too close
		if(Vector3.Distance(finger, myTrans.position) > maxDist)
			myTrans.Translate (Vector3.forward * speed * Time.deltaTime);
	}
	public void OnTouchStayed ()
	{
//		Debug.Log("nice touch, stayed");
	}
	public void OnTouchBeganAnywhere ()
	{
//		Debug.Log("nice touch, begananywhere");
	}
	public void OnTouchEndedAnywhere ()
	{
//		Debug.Log("nice touch, endedanywhere");
	}
	public void OnTouchMovedAnywhere ()
	{
		Debug.Log("nice touch, movedanywhere");
	}
	public void OnTouchStayedAnywhere ()
	{
//		Debug.Log("nice touch, stayedanywhere");
	}
	#endregion


}
