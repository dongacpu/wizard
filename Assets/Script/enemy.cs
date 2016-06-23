using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{

    public float hp;       // 현재 체력
    float move;     // 이동 속도
    int turn = 0;          // 회전 조건
    bool direction = false; // 방향 체크 false = 왼쪽  
    public fireball magic;

    void Start()
    {
        hp = 0.5f;
        move = 0.1f;
        turn = 0;
        magic = GameObject.Find("magic").transform.FindChild("fireball").GetComponent<fireball>();
    }
    void Update()
    {
        if (direction)
        {
            transform.position = new Vector3(transform.position.x + move, transform.position.y, 0);
            turn++;
            if (turn > 100)
            {
                this.transform.localRotation = Quaternion.Euler(0, 0, 0);
                turn = 0;
                direction = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - move, transform.position.y, 0);
            turn++;
            if (turn > 100)
            {
                this.transform.localRotation = Quaternion.Euler(0, 180, 0);
                turn = 0;
                direction = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("sdfsdf0");
        if (other.tag == "magic")
        {
            hp -= magic.damage;
            if (hp <= 0.0f)
            {
                die();
            }
        }
    }

    void die()
    {
        this.gameObject.SetActive(false);
    }
}
