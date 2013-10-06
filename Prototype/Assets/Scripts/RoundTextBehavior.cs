using UnityEngine;
using System.Collections;

public class RoundTextBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void setText(string Text){
		
		TextMesh tm = (TextMesh)GetComponent("TextMesh");
		tm.text = Text;
		
	}
}
