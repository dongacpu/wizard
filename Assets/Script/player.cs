using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public GameObject cam;
    

	void Start () {
	
	}
	

	void Update () {

        cam.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
