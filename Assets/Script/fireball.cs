﻿using UnityEngine;
using System.Collections;

public interface magic
{
    void move();
}

public class fireball : MonoBehaviour,magic {

    public Vector3 setposition;
    public GameObject player;
    public float velocity;
    public float time;
    public player p;


    void OnEnable()
    {
        if (p.direction)
            this.transform.localPosition = new Vector3(player.transform.position.x + setposition.x, player.transform.position.y + setposition.y, player.transform.position.z + setposition.z);
        else
        {
            this.transform.localPosition = new Vector3(player.transform.position.x - setposition.x, player.transform.position.y + setposition.y, player.transform.position.z + setposition.z);
            this.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        StartCoroutine("wait");
    }
	void Update () {
        if(this)
            move();
	}
    public void move() {
        if(p.direction)
              this.gameObject.transform.Translate(velocity,0,0);
      /*  else
            this.gameObject.transform.Translate(-velocity, 0, 0);*/
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
