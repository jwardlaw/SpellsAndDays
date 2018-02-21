using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    public float gravity;

    public Camera staticCam;
    public Camera flyingCam;
    public Shooter shooter;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        flyingCam = GetComponentInChildren<Camera>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        staticCam.enabled = true;
        shooter.enabled = true;
        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(rb.velocity);

        rb.AddForce(new Vector3((flyingCam.transform.forward.x * 0.5f), flyingCam.transform.forward.y, (flyingCam.transform.forward.z * 0.05f)) * rb.velocity.magnitude);
        rb.AddForce(Vector3.down * gravity);
        gravity += 0.045f;
		
	}
}
