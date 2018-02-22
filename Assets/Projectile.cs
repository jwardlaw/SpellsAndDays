using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float gravity = 0.1f;
    public float controlForce = 20f;

    public GameObject staticCam;
    public Camera flyingCam;
    public Shooter shooter;
    public Transform Player;

    Rigidbody rb;
    SphereCollider s;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        flyingCam = GetComponentInChildren<Camera>();
        s = GetComponent<SphereCollider>();
        Player = GameObject.Find("Player").transform;
	}

    IEnumerator CollisionCoroutine()
    {
        yield return new WaitForSeconds(2f);
        staticCam.SetActive(true);
        shooter.enabled = true;
        GameObject.Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        s.enabled = false;
        rb.isKinematic = true;
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);
        StartCoroutine(CollisionCoroutine());
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.AddForce(new Vector3((flyingCam.transform.forward.x * 0.5f), flyingCam.transform.forward.y, (flyingCam.transform.forward.z * 0.05f)) * controlForce);
        rb.AddForce(Vector3.down * gravity);
        gravity += 0.005f;
        controlForce += 0.15f;
	}
}
