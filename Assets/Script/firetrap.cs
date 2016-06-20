using UnityEngine;
using System.Collections;
using System;

public interface trap
{
    void damage();
    void active_on();
    void active_off();

}


public class firetrap : MonoBehaviour,trap
{
    public GameObject player;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    
	}
    public void damage()
    {
    }
    public void active_on()
    {
    }
    public void active_off()
    {

    }
}
