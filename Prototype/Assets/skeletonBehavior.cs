using UnityEngine;
using System.Collections;

public class skeletonBehavior : MonoBehaviour {
	enum States {idle,walk,rotate,run,attack,gethit};
	GameObject gameControl;
	private int life;
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.idle;
		life = 20;
		gameControl = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!animation.isPlaying){
			myState = States.idle;
		}
	}
	public void getHit(int hitValue){
		if(myState==States.idle)
		{
			myState = States.gethit;
			if(hitValue < life)
			{
				life = life - hitValue;
				transform.animation["gethit"].wrapMode = WrapMode.Once;
				transform.animation.CrossFade("gethit");
			}
			else
			{
				life = 0;				
				transform.animation["die"].wrapMode = WrapMode.Once;
				transform.animation.CrossFade("die");
				this.collider.enabled = false;
				gameControl.SendMessage("NPCKilled",this.gameObject);
				
			}
			
		}
	}

}
