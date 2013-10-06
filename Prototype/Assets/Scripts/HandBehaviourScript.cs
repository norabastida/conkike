using UnityEngine;
using System.Collections;

public class HandBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		
			if(col.gameObject.tag=="Skeleton")
			{
				
					col.gameObject.SendMessage("getHit",5);
			}
	}		 
}
