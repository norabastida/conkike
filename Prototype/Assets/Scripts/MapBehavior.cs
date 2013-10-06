using UnityEngine;
using System.Collections;

public class MapBehavior : MonoBehaviour {
	public int boardSizeX;
	public int boardSizeZ;
	public Transform cubePrefab;
	public GameObject[] cubePrefabs;
	public Transform[] boardCubes;
   	 private int b;
	// Use this for initialization
	void Start () {
		GameObject spartan;
		GameObject skeleton;
		GameObject cubeTarget;
	 	Transform[] boardCubes = new Transform[(boardSizeX * boardSizeZ)];
		//Creates and instantiates the board
		GameObject board = new GameObject();
		//Names the board World
		board.name = "World";
		//math to make X variable grow to board_size_x
		for (int x = 0; x < boardSizeX; x++)
		{
			//math to make Y variable grow to board_size_y
			for (int z = 0; z < boardSizeZ; z++)
			{
 
				Transform cube = (Instantiate(cubePrefab, new Vector3(x*cubePrefab.renderer.bounds.size.x, 0, z*cubePrefab.renderer.bounds.size.z), Quaternion.identity) as Transform);
				cube.name = "Cube" + x + "," + z;
				cube.parent = board.transform;
 
				//pushes tiles into boardCubes array
				boardCubes[b++] = cube;
 
				//iterates through each newCube and debugs its name
				foreach (Transform newCube in boardCubes)
				{
				Debug.Log("Added Cube: " + cube.name);
				}
            
			//iterates through each boardCubes and debugs its value
			//for (int i = 0; i < 10; i++)
			// Debug.Log(boardCubes[x]); 
			}
		}
			spartan = GameObject.Find("SpartanKing");
			cubeTarget = GameObject.Find("Cube"+Mathf.Floor(this.boardSizeX/2)+",0");
			spartan.transform.position = new Vector3 (cubeTarget.transform.position.x,0,cubeTarget.transform.position.z);
		    skeleton = GameObject.Find("skeletonDark");
			cubeTarget = GameObject.Find("Cube"+Mathf.Floor(this.boardSizeX/2)+","+Mathf.Floor(this.boardSizeZ-1));
			skeleton.transform.position = new Vector3 (cubeTarget.transform.position.x,0,cubeTarget.transform.position.z);		
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
