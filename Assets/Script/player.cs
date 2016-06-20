using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public GameObject cam;
    public float hp;
    bool hp_remain;
    bool died = false;
    public bool hit_check = false;
    public SpriteRenderer image_this;
    bool up = false;
    float num=1f;

	void Start () {
	
	}
	

	void Update () {
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
        cam.gameObject.transform.position = Vector3.Lerp(cam.gameObject.transform.position, new Vector3(transform.position.x,transform.position.y,-10), Time.timeScale*0.05f);
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
