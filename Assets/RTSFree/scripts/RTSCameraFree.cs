using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraFree : MonoBehaviour {
	
	public int fov = 60;
	public int fovmax = 90;

	public int min = 30;
 

	public float ScrollSpeed = 15;

	public float ScrollEdge = 0.01f;

 

// 	private int HorizontalScroll = 1;

// 	private int VerticalScroll = 1;

// 	private int DiagonalScroll = 1;

 

	public float PanSpeed = 10;

 

	public Vector2 ZoomRange = new Vector2(-5,5);

	public float CurrentZoom = 0;

	public float ZoomZpeed = 1;

	public float ZoomRotation = 1;

	public float rotationSpeed = 1;

// 	private Vector3 InitPos;

// 	private Vector3 InitRotation;
	
	public float minCamHeight = 65;

	public float maxCamHeight = 75;
	
	
	void Start(){
// 		InitPos = transform.position;

// 		InitRotation = transform.eulerAngles;
	
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Terrain.activeTerrain.SampleHeight(GetComponent<Camera>().transform.position)+70, Camera.main.transform.position.z);
	}
	
	void Update(){
	
// PAN	
		if(Input.GetKey("mouse 2")){
			//(Input.mousePosition.x - Screen.width * 0.5)/(Screen.width * 0.5)		
	   //     transform.Translate(Vector3.right * Time.deltaTime * PanSpeed * (Input.mousePosition.x - Screen.width * 0.5)/(Screen.width * 0.5), Space.World);
	   //     transform.Translate(Vector3.forward * Time.deltaTime * PanSpeed * (Input.mousePosition.y - Screen.height * 0.5)/(Screen.height * 0.5), Space.World);
		}
		else{
			if ( Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge) ){
				transform.Translate(Time.deltaTime * ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),0, Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);
			//    transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);

			}

			else if ( Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge ){
				transform.Translate(Time.deltaTime * -ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),0, Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);
		   //     transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);

			}

		

			if ( Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge) ){

				transform.Translate(Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),0, Time.deltaTime * ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);
			 //   transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed *System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);

			}

			else if ( Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge ){
				transform.Translate(Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),0, Time.deltaTime * -ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);
	 //           transform.Translate(Vector3.forward * Time.deltaTime * -ScrollSpeed*System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);
			 //   transform.Translate(Vector3.forward * Time.deltaTime * -ScrollSpeed*System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), Space.World);

			}
			
		}
		
		
		
//ZOOM IN/OUT
		var fwd = transform.TransformDirection (Vector3.forward);
		if (Input.GetAxis("Mouse ScrollWheel")> 0){
		
			transform.Translate(
				2*Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
				2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*(float)System.Math.Pow(2.0,0.5),
				2*Time.deltaTime * ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
				Space.World
			);
		//	if((Terrain.activeTerrain.SampleHeight(camera.transform.position)+70)<40){
		//		transform.Translate(
		//		2*Time.deltaTime * -ScrollSpeed *System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
		//		2*Time.deltaTime * ScrollSpeed *System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*System.Math.Pow(2.0,0.5),
		//		2*Time.deltaTime * -ScrollSpeed *System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
		//		Space.World
		//	);
		//	}
		
			if(Camera.main.transform.rotation.eulerAngles.x <= 180){
				if (Physics.Raycast (transform.position, fwd, 50)) {
					transform.Translate(
						2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						2*Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*(float)System.Math.Pow(2.0,0.5),
						2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						Space.World
					);
				}
			}
			if(Camera.main.transform.rotation.eulerAngles.x >= 180){
				if (!(Physics.Raycast (transform.position, -fwd, 150))) {
					transform.Translate(
						2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						2*Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*(float)System.Math.Pow(2.0,0.5),
						2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						Space.World
					);
				}
			}
	//		Camera.main.fieldOfView = fov--;

		}








		if (Input.GetAxis("Mouse ScrollWheel")< 0){
	
		
			transform.Translate(
				2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
				2*Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*(float)System.Math.Pow(2.0,0.5),
				2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180), 
				Space.World
			
				//0.2*System.Math.Pow((Terrain.activeTerrain.SampleHeight(camera.transform.position))/(System.Math.Cos((90-Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)),2)
			);
		
	//		var fwd = transform.TransformDirection (Vector3.forward);
		
			if(Camera.main.transform.rotation.eulerAngles.x >= 180){
				if (Physics.Raycast (transform.position, -fwd, 50)) {
		
					transform.Translate(
						2*Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*(float)System.Math.Pow(2.0,0.5),
						2*Time.deltaTime * ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						Space.World
					);
				}
			}
		
			if(Camera.main.transform.rotation.eulerAngles.x <= 180){
				if (!(Physics.Raycast (transform.position, fwd, 150))) {
		
					transform.Translate(
						2*Time.deltaTime * ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						2*Time.deltaTime * -ScrollSpeed *(float)System.Math.Sin((Camera.main.transform.rotation.eulerAngles.x)*System.Math.PI/180)*(float)System.Math.Pow(2.0,0.5),
						2*Time.deltaTime * ScrollSpeed *(float)System.Math.Cos((Camera.main.transform.rotation.eulerAngles.y)*System.Math.PI/180),
						Space.World
					);
				}
			}
		
	//		Camera.main.fieldOfView = fov++;

		}
		
// ROTATION

		if (Input.GetMouseButton(1)){
			float h = rotationSpeed * Input.GetAxis ("Mouse X");
			float v = rotationSpeed * Input.GetAxis ("Mouse Y");
			transform.Rotate (0, h, 0, Space.World);

			transform.Rotate (v, 0, 0);

			if((Camera.main.transform.rotation.eulerAngles.x >= 90) &&(Camera.main.transform.rotation.eulerAngles.x <= 180)){
	
				transform.Rotate (-v, 0, 0);
			}
			if(((Camera.main.transform.rotation.eulerAngles.x >= 180)&&(Camera.main.transform.rotation.eulerAngles.x <= 270))||(Camera.main.transform.rotation.eulerAngles.x < 0) ){
	
				transform.Rotate (-v, 0, 0);
			}


			if((Camera.main.transform.rotation.eulerAngles.z >= 160)&&(Camera.main.transform.rotation.eulerAngles.z <= 200)){
				transform.Rotate (-v, 0, 0);
			}
		}	
		
		
		
	}
	
	
	
}
