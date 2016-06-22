using UnityEngine;
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

    void Awake()
    {

    }
    void OnEnable()
    {
        this.transform.localPosition = new Vector3(player.transform.position.x+setposition.x,player.transform.position.y+setposition.y,player.transform.position.z+setposition.z);
        StartCoroutine("wait");
    }
	void Update () {
        if(this)
        move();
	}
    public void move() {
        this.gameObject.transform.Translate(velocity,0,0);
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
