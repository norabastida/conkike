using UnityEngine;
using System;
using System.Collections;

public class SpartanBehavior : MonoBehaviour {
	enum States {idle,walk,rotate,run,attack,end};
	private States myState;
	private Vector3 destiny;
	private Quaternion direction;
	private float walkVelocity = 4f;
	private float rotationVelocity = 10f;
	
	bool isActive;
	public event EventHandler turnPlayed;
	

	// Use this for initialization
	void Start () {
			myState = States.idle;
			transform.animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		if(myState==States.rotate)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation,direction,Time.deltaTime*rotationVelocity);
		
		if((transform.rotation.eulerAngles-direction.eulerAngles).magnitude < 10)
		{
			myState = States.walk;
		}
		}
	if (myState == States.walk)
		{
		
		Debug.Log(myState);
		transform.position = Vector3.MoveTowards (
        transform.position, destiny,
        Time.deltaTime * walkVelocity);
			if((transform.position - destiny).magnitude < 0.1)
			{
				this.changeToIdle();				
			}
		}
	if (myState == States.attack)
		{
			if (!animation.isPlaying)
			{
				myState = States.idle;
				this.turnEnded();
			}

		}
	}
	public void moveTo(Vector3 newPos)
	{
		
		direction = Quaternion.LookRotation(newPos-transform.position);
		myState = States.rotate;
		transform.animation.CrossFade("walk");
		walkVelocity = 4f;
		this.destiny = newPos;
	}
	public void runTo(Vector3 newPos)
	{
		direction = Quaternion.LookRotation(newPos-transform.position);
		myState = States.rotate;
		transform.animation.CrossFade("run");
		walkVelocity = 9f;
		this.destiny = newPos;
	}
	private void changeToIdle()
	{
		myState = States.idle;
		transform.animation.CrossFade("idle");
	}
	public bool getMoving(){
		return !(myState==States.idle);
		
	} 
	public void attackEnemy()
	{
		if (myState == States.idle)
		{
			myState = States.attack;
		    transform.animation["attack"].wrapMode = WrapMode.Once;
			transform.animation.CrossFade("attack");
		}
	}
	void OnTriggerEnter(Collider col){
		if ( myState == States.attack)
		{
			if(col.gameObject.tag=="Skeleton")
			{
				
				col.gameObject.GetComponent<skeletonBehavior>().getHit(5);
			}
		}
	}
	
	public void setActive(bool _isActive)
	{
		this.isActive = _isActive;
	}
	
	public void turnEnded()
	{
		turnPlayed(this.gameObject,EventArgs.Empty);
		isActive = false;
	}
}

	