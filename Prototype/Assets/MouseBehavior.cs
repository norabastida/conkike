using UnityEngine;
using System.Collections;

public class MouseBehavior : MonoBehaviour {
	
	private Ray mouseRay;
	private RaycastHit hit;
	private GameObject spartan;
	private GameObject halo;
	private GameObject camera;
	private bool isDoubleClick = false;
	private GameObject hitCube;
	// Use this for initialization
	void Start () {
		spartan = GameObject.FindGameObjectWithTag("Spartan");
		halo = GameObject.FindGameObjectWithTag("TileHalo");
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		halo.renderer.enabled = false;
	}
	void OnGUI() {
    Event e = Event.current;
    if (e.isMouse) {
 		if (e.clickCount == 1)
		{
			isDoubleClick = false;
			}
		else
			{
			isDoubleClick = true;
				
		}
    }
}
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0))
		{
		
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(mouseRay,out hit))
			{
				hitCube = hit.collider.gameObject;

				if(hit.collider.gameObject.CompareTag("Plano"))
				{
					halo.transform.position = hitCube.transform.position;
					halo.renderer.enabled = true;
		/*			if (isDoubleClick)
					{
					    
						spartan.GetComponent<SpartanBehavior>().runTo(hitCube.renderer.bounds.center);
						
					}
					else
					{
					spartan.GetComponent<SpartanBehavior>().moveTo(hitCube.renderer.bounds.center);
						
					}
					*/
				} else if (hit.collider.gameObject.CompareTag("TileHalo"))
				{
					spartan.GetComponent<SpartanBehavior>().runTo(hitCube.renderer.bounds.center);
					halo.renderer.enabled = false;

				}
			}
	
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			spartan.GetComponent<SpartanBehavior>().attackEnemy();
		}
		
			
		if( spartan.GetComponent<SpartanBehavior>().getMoving())
		{
			camera.transform.position = new Vector3(spartan.transform.position.x,spartan.transform.position.y+spartan.transform.lossyScale.y/2,spartan.transform.position.z-spartan.transform.lossyScale.z/2);
			camera.transform.rotation = Quaternion.Euler(10,0,0);	
		} else 
		{
			camera.transform.position = new Vector3(10,20,-10);
			camera.transform.rotation = Quaternion.Euler(45,0,0);
		}
		
		
		
	}
}
