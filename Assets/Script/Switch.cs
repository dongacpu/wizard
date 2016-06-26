using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public GameObject switch2;
    Vector3 pos_switch2;
    public float distance;
    public bool on = false;
    public bool check = false;
    public enum DIRECTION {
        UP,
        LEFT,
        RIGHT,
        DOWN
    }
    public DIRECTION direc;
	void Start ()
    {
        pos_switch2 = switch2.gameObject.transform.localPosition;
	}
    void switch_on()
    {
        check = false;
        if (direc == DIRECTION.UP)
            switch2.transform.localPosition += Vector3.up * distance;
        else if (direc == DIRECTION.DOWN)
            switch2.transform.localPosition += Vector3.down * distance;
        else if (direc == DIRECTION.RIGHT)
            switch2.transform.localPosition += Vector3.right * distance;
        else
            switch2.transform.localPosition += Vector3.left * distance;
    }
    void switch_off()
    {
        switch2.transform.localPosition = pos_switch2;
    }
	void Update ()
    {
        if (on == true && check == true)
            switch_on();
        else if (on == false && check == true)
            switch_off();
	    
	}
}
