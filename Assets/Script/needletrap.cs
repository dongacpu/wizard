using UnityEngine;
using System.Collections;

public class needletrap : MonoBehaviour,trap {
    public player p;
    public float damage_once;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
            damage();
    }
    public void damage()
    {
        if (p.hit_check == false)
        {
            p.hp -= damage_once;
            p.StartCoroutine("hit");
        }
    }
    public void active_on()
    {
    }
    public void active_off()
    {

    }
   
}
