using UnityEngine;
using System.Collections;

public interface magic
{
    void move();
}

public class fireball : MonoBehaviour,magic {

	
	void Update () {
        if(this)
        move();
	}
    public void move() {
        this.gameObject.transform.Translate(-0.1f,-0.1f,0);
    }
}
