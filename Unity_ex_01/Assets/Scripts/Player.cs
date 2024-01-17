using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;


    void Start()
    {
        //같은 Inspector 내에서 Rigidbody를 가져오겠다는 뜻
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // other 충돌된 물체
        if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
        }
    }

    //물리 사용을 위한 지속 호출
    private void FixedUpdate()
    {
        // 수평 축의 입력을 받음 (LEFT,RIGHT)
        float moveH = Input.GetAxis("Horizontal");

        // 수직 축의 입력을 받음 (UP,DOWN)
        float moveV = Input.GetAxis("Vertical");

        // 플레이어 이동
        Vector3 movement = new Vector3(moveH, 0, moveV);

        // 플레이어 힘을 가함
        rb.AddForce(movement * speed);
    }
}
