using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject staticCam;
    public GameObject flyingCam;

    public float angle = 5f;
    private float angleMin = 0f;
    private float angleMax = 40f;

    public GameObject spawnPoint;

    public float projectileForce = 5f;

	// Use this for initialization
	void Start ()
    {
        staticCam = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    void Shoot()
    {
        GameObject p = (GameObject)GameObject.Instantiate(Resources.Load("Fireball"), spawnPoint.transform.position, spawnPoint.transform.rotation);
        p.GetComponent<Rigidbody>().AddForce(p.transform.forward * projectileForce);
        p.GetComponent<Projectile>().staticCam = staticCam;
        p.GetComponent<Projectile>().shooter = this;
        staticCam.SetActive(false);
        this.enabled = false;
    }

    void HandleInput()
    {
        angle = Mathf.Clamp(angle - Input.GetAxis("Mouse ScrollWheel") * 5, angleMin, angleMax);
        spawnPoint.transform.rotation = Quaternion.AngleAxis(20f + angle, Vector3.left);
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
