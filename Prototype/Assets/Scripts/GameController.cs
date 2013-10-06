using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	private int round;
	GameObject RoundText;
	GameObject ParticlesDeath;
	
	//turn controller
	GameObject[] spartans;
	GameObject[] skeletons;
	List<GameObject> activePlayer;
	int totalActiveMembers;
	bool isActive;
	
	// Use this for initialization
	void Start () {
		round = 1;
		RoundText = GameObject.FindWithTag("RoundText");
		ParticlesDeath = GameObject.FindWithTag("ParticlesDeath");
		
		spartans = GameObject.FindGameObjectsWithTag("Spartan");
		foreach(GameObject go in spartans)
		{
			go.GetComponent<TurnBehavior>().turnPlayed += this.turnPlayedEvent;
		}
		skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
		foreach(GameObject go in skeletons)
		{
			go.GetComponent<TurnBehavior>().turnPlayed += this.turnPlayedEvent;
		}
		
		this.setActivePlayer(spartans);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void NPCKilled(GameObject NPC)
	{
		ParticlesDeath.transform.position = NPC.transform.position;
		RoundText.SendMessage("setText","Congratulations, you won!");
		ParticlesDeath.particleSystem.Play();
	}
	
	public void setActivePlayer(GameObject[] _turnReceiver)
	{
		activePlayer =  new List<GameObject>(_turnReceiver);
		totalActiveMembers = activePlayer.Count;
		foreach(GameObject go in activePlayer)
		{
			go.GetComponent<TurnBehavior>().setActive(true);
		}
		
	}
	public void turnPlayedEvent(object c, EventArgs args)
	{
		GameObject go = (GameObject) c;
		Debug.Log("Player Moved!! "+go.name);
		if(activePlayer.Contains(go))
		{
			totalActiveMembers --;
			if(totalActiveMembers == 0)
			{
				Debug.Log("TURN IS OVER");
			}
		}
	}
	
	
	
}
