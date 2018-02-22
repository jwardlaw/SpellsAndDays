using UnityEngine;
using System.Collections;

public class SpawnPointFree : MonoBehaviour {

	public GameObject box;
	public GameObject fakeObject;
	public bool readynow = true;
	public float timestep = 0.01f;
	public int count = 0;
	public int numberOfObjects = 10000;
	public float size = 1.0f;

	public int assignDiplomacy = 1;

	public bool addToBS = true;
// 	public bool createFakeObject = false;

	BattleSystemFree bs;
	Terrain ter;


	void Awake(){
		bs = (BattleSystemFree)FindObjectOfType(typeof(BattleSystemFree));
		ter = (Terrain)FindObjectOfType(typeof(Terrain));
	}

	void Start () {
		StartCoroutine(MakeBox());
	}
 
	public IEnumerator MakeBox(){
 
// 		if(createFakeObject == true){
// 			for(int i=0;i<2;i=i+1){
// 				GameObject cubeSpawn = (GameObject)Instantiate(fakeObject, new Vector3(-9999999999999.99f-9999.99f*Random.Range(-1.0f,1.0f),-9999999999999.99f-9999.99f*Random.Range(-1.0f,1.0f),-9999999999999.99f-9999.99f*Random.Range(-1.0f,1.0f)), transform.rotation);
// 
// 				cubeSpawn.GetComponent<UnitParsFree>().isReady = true;
// 				bs.unitsBuffer.Add(cubeSpawn);
// 			}
// 		}
//  
//  
		for(int i=0;i<numberOfObjects;i=i+1){
			readynow=false;
			yield return new WaitForSeconds(timestep);

			Vector3 pos = new Vector3(transform.position.x+Random.Range(-size,size)+5,transform.position.y,transform.position.z+Random.Range(-size,size));
			pos = TerrainVector(pos, ter);

			GameObject cubeSpawn = (GameObject)Instantiate(box, pos, transform.rotation);

			UnitParsFree up = cubeSpawn.GetComponent<UnitParsFree>();
			if(up != null){
				up.isReady = true;
			}
			

			bs.unitsBuffer.Add(cubeSpawn);


			readynow=true;
			count = count+1;



		}
	}



	Vector3 TerrainVector(Vector3 origin, Terrain ter1){
		if(ter1 == null){
			return origin;
		}
		Vector3 planeVect = new Vector3(origin.x, 0f, origin.z);
		float y1 = ter1.SampleHeight(planeVect);
	
		y1 = y1+ter1.transform.position.y;
	
		Vector3 tv = new Vector3(origin.x, y1, origin.z);
		return tv;
	}



}