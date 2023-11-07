using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player : MonoBehaviour
{
    public float speed = 8f;
    public GameObject player;

    Rigidbody rigid;

    Vector3 movement;

    public Animator anim;
    float h;
    float v;

    public bool inputLR = false;
    public bool inputUD = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();

        M_Controller m_c = GameObject.FindGameObjectWithTag("Managers").GetComponent<M_Controller>();
        m_c.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        //anim.SetFloat("Horizontal", h);
        //anim.SetFloat("Vertical", v);
        if(inputLR) anim.SetFloat("Horizontal", h);
        else if(inputUD) anim.SetFloat("Vertical", v);
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (h < 0) moveVelocity = Vector3.left;
        else if (h > 0) moveVelocity = Vector3.right;
        else if (v < 0) moveVelocity = Vector3.down;
        else if (v > 0) moveVelocity = Vector3.up;

        transform.position += moveVelocity * speed * Time.deltaTime;
    }
}
