using UnityEngine;
using System.Collections;
using Mirror;

public class FighterAnimationDemoFREE : NetworkBehaviour {
	
	public Animator animator;

	private Transform defaultCamTransform;
	private Vector3 resetPos;
	private Quaternion resetRot;
	private GameObject cam;
	private GameObject fighter;
	public GameObject spawn;

	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera");
		defaultCamTransform = cam.transform;
		resetPos = transform.position;
		resetRot = transform.rotation;
	}

	void OnGUI () 
	{
		if (!isLocalPlayer) return;
		if (GUI.RepeatButton (new Rect (815, 535, 100, 150), "Reset Scene")) 
		{
			transform.position = resetPos;
			transform.rotation = resetRot;
			animator.Play("Idle");
		}

		if (GUI.RepeatButton (new Rect (500, 20, 100, 30), "Walk Forward")) 
		{
			animator.SetBool("Walk Forward", true);
		}
		else
		{
			animator.SetBool("Walk Forward", false);
		}

		if (GUI.RepeatButton (new Rect (500, 50, 100, 30), "Walk Backward"))
		{
			animator.SetBool("Walk Backward", true);
		}
		else
		{
			animator.SetBool("Walk Backward", false);
		}

		if (GUI.Button (new Rect (500, 90, 100, 30), "Punch")) 
		{
			animator.SetTrigger("PunchTrigger");
		}
	}
}