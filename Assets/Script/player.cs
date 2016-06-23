using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class player : MonoBehaviour {

    public GameObject cam;      // 카메라
    public float mp;        // 현재 마나
    float mp_max;       // 최대 마나
    public float hp;        // 현재 체력
    float hp_max;       // 최대 채력
    bool hp_remain;     // 체력이 남아 있는지 확인
    bool died = false;      // 죽었는지 확인
    public bool hit_check = false;      // 맞았는지 확인
    public SpriteRenderer image_this;       // 플레이어의 이미지
    bool up = false;        // 히트 이펙트 체크 
    float num=1f;       // 히트 이펙트용 변수
    public Slider hpbar;        // 체력ui
    public Slider mpbar;        // 마나 ui
    public float move;      // 이동 속도
    public Animator ani;        // 플레이어 애니메이션
    public Rigidbody rigid;     // 플레이어 리지드바디
    public float jump_force;        // 점프 크기
    bool jump_check = true;     // 점프중인지 확인
    public bool direction = false;     // 방향 체크 false = 왼쪽     
    public enum ANI_STATE       // 플레이어 애니메이션 상태
    {
        stay_left,
        stay_right,
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
            direction = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Translate(-move, 0, 0);
            AS = ANI_STATE.left;
            direction = false;
        }
       

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (mp > 0)
            {
                mp -= 10;
                magic("fireball");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump_check)
        {
            jump_check = false;
            rigid.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
            AS = ANI_STATE.stay_right;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            AS = ANI_STATE.stay_left;
        if (AS == ANI_STATE.left)
            ani.Play("test_left");
        else if (AS == ANI_STATE.right)
            ani.Play("test_right");
        else if (AS == ANI_STATE.stay_right)
            ani.Play("right_stay");
        else if (AS == ANI_STATE.stay_left)
            ani.Play("left_stay");

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
    void magic(string magic_name)
    {
        GameObject.Find("magic").transform.FindChild(magic_name).gameObject.SetActive(true);
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
