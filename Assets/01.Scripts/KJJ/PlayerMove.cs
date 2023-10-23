using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 키보드값을 입력받는다.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //입력받은 키보드값을 누적한다.
        Vector3 xy = (x * transform.right) + (y * transform.up);
        transform.position += xy * speed * Time.deltaTime;
    }
}
