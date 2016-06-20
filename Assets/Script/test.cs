using UnityEngine;
using System.Collections;


public class test : MonoBehaviour {

    public float move;
    public Animator ani;
    public Rigidbody rigid;
    public float jump_force;
    bool jump_check=true;
    public GameObject bullet;
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
        if (Input.GetKeyDown(KeyCode.Z))
            StartCoroutine("magic");
       if (Input.GetKeyDown(KeyCode.Space)&&jump_check)
        {
            jump_check = false;
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
    void OnCollisionEnter(Collision other)
    {
       
        if (other.collider.tag == "ground")
        {
           
            jump_check = true;
        }
    }
    IEnumerator magic()
    {
        bullet.SetActive(true);
        yield return new WaitForSeconds(1f);
        bullet.transform.localPosition= new Vector3(this.gameObject.transform.position.x+3, 0, 10);
        bullet.SetActive(false);
        
    }
}
