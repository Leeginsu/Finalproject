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
        // Ű���尪�� �Է¹޴´�.
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //�Է¹��� Ű���尪�� �����Ѵ�.
        Vector3 xy = (x * transform.right) + (y * transform.up);
        transform.position += xy * speed * Time.deltaTime;
    }
}
