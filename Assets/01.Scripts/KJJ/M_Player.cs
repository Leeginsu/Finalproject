using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player : MonoBehaviour
{
    public float speed = 8f;

    public Animator anim;

    Vector3 moveVelocity = Vector3.zero;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputUp = false;
    public bool inputDown = false;


    // Start is called before the first frame update
    void Start()
    {
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
        if(inputLeft)
        {
            moveVelocity = new Vector3(-1f, 0, 0);
            transform.rotation = Quaternion.Euler(0, -90, 90);// transform.Rotate(new Vector3(-180, 90, -90));
            Move();
        }
        if(inputRight)
        {
            moveVelocity = new Vector3(1f, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, -90);
            Move();
        }
        if(inputUp)
        {
            moveVelocity = new Vector3(0, 1f, 0);
            transform.rotation = Quaternion.Euler(-90, 0, 0);
            Move();
        }
        if(inputDown)
        {
            moveVelocity = new Vector3(0, -1f, 0);
            transform.rotation = Quaternion.Euler(-270, -90, 90);
            Move();
        }
        if (!inputLeft && !inputRight && !inputUp && !inputDown)
        {
            anim.SetBool("IsMoving", false);
            //transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }

    void Move()
    {
        anim.SetBool("IsMoving", true);
        transform.position += moveVelocity * speed * Time.deltaTime;
    }
}
