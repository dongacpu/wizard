using UnityEngine;
using System.Collections;

public class tile : MonoBehaviour {

    bool first=true;
    public float velocity;
    [System.Serializable]
    public struct PATH
    {
        public float distance;
        public string direc;
    }
    public PATH[] path;
    enum DIRECTION
    {
        left,
        right,
        up,
        down
    }
    void Start() { 
        move();

    }
    int count = 0;
    int i = 0;
    DIRECTION d;
    void Update()
    {
        if (d == DIRECTION.down)
        {
            this.gameObject.transform.Translate(0, -velocity, 0);
            count++;
        }
        else if (d == DIRECTION.up)
        {
            this.gameObject.transform.Translate(0, velocity, 0);
            count++;
        }
        else if (d == DIRECTION.right)
        {
            this.gameObject.transform.Translate(velocity, 0, 0);
            count++;
        }
        else if (d == DIRECTION.left)
        {
            this.gameObject.transform.Translate(-velocity, 0, 0);
            count++;
        }
        if (first == true&&count>path[i].distance/velocity)
        {
            i++;
            move();
            count = 0;
        }
        else if (first == false&& count > path[i].distance / velocity)
        {
            i--;
            move();
            count = 0;
        }
    }

    void move()
    {
        
        if (i >= path.Length)
        {
            i = path.Length-1;
            first = false;
        }
        if (i < 0)
        {
            i = 0;
            first = true;
        }
        if (first)
        {
            if (path[i].direc == "left")
                d = DIRECTION.left;
            else if (path[i].direc == "right")
                d = DIRECTION.right;
            else if (path[i].direc == "down")
                d = DIRECTION.down;
            else if (path[i].direc == "up")
                d = DIRECTION.up;
        }
        else
        {
            if (path[i].direc == "left")
                d = DIRECTION.right;
            else if (path[i].direc == "right")
                d = DIRECTION.left;
            else if (path[i].direc == "down")
                d = DIRECTION.up;
            else if (path[i].direc == "up")
                d = DIRECTION.down;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.parent = this.gameObject.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
