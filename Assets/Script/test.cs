using UnityEngine;
using System.Collections;


public class test : MonoBehaviour {

    public float move;
    public Animator ani;
    public Rigidbody rigid;
    public float jump_force;
    public enum ANI_STATE
    {
        stay,
        right,
        left
    };
    ANI_STATE AS;   
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.Translate(move, 0, 0);
            AS = ANI_STATE.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(-move, 0, 0);
            AS = ANI_STATE.left;
        }
       if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            rigid.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
            
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            AS = ANI_STATE.stay;
        if (AS == ANI_STATE.left)
            ani.Play("test_left");
        else if (AS == ANI_STATE.right)
            ani.Play("test_right");
        else if (AS == ANI_STATE.stay)
            ani.Play("New Animation");
    }
}
