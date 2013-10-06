using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private int round;
	GameObject RoundText;
	GameObject ParticlesDeath;
	// Use this for initialization
	void Start () {
		round = 1;
		RoundText = GameObject.FindWithTag("RoundText");
		ParticlesDeath = GameObject.FindWithTag("ParticlesDeath");
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
	
}
