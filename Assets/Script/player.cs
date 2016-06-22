using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class player : MonoBehaviour {

    public GameObject cam;
    public float mp;
    float mp_max;
    public float hp;
    float hp_max;
    bool hp_remain;
    bool died = false;
    public bool hit_check = false;
    public SpriteRenderer image_this;
    bool up = false;
    float num=1f;
    public Slider hpbar;
    public Slider mpbar;
    public float move;
    public Animator ani;
    public Rigidbody rigid;
    public float jump_force;
    bool jump_check = true;
    public GameObject bullet;
    public enum ANI_STATE
    {
        stay,
        right,
        left
    };
    ANI_STATE AS;

    void Start () {
        hp_max = hp;
        mp_max = mp;
	}
  

	void Update () {
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
        {
            if (mp > 0)
            {
                mp -= 10;
                StartCoroutine("magic");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump_check)
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
        if (hp > 0)
            hp_remain = true;
        else
            hp_remain = false;
        if (!hp_remain && !died)
        {
            died = true;
            die();
        }
        if (up == false)
            num -= 0.03f;
        else
            num += 0.03f;
        if (num >= 1f)
        {
            num = 1f;
            up = false;
        }
        else if (num <= 0.4f)
        {
            num = 0.4f;
            up = true;
        }
        if (hit_check)
            image_this.color = new Color(1, 1, 1, num);
        else
            image_this.color = new Color(1, 1, 1, 1);

        hpbar.value = hp / hp_max;
        mpbar.value = mp / mp_max;
        cam.gameObject.transform.position = Vector3.Lerp(cam.gameObject.transform.position, new Vector3(transform.position.x,transform.position.y,-10), Time.timeScale*0.05f);
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
        bullet.transform.localPosition = new Vector3(this.gameObject.transform.position.x + 3, 0, 10);
        bullet.SetActive(true);
        yield return new WaitForSeconds(1f);
        bullet.transform.localPosition = new Vector3(this.gameObject.transform.position.x + 3, 0, 10);
        bullet.SetActive(false);

    }
    IEnumerator hit()
    {
        hit_check = true;
        yield return new WaitForSeconds(1f);
        hit_check = false;
    }
    void die()
    {
        this.gameObject.SetActive(false);
    }
}
