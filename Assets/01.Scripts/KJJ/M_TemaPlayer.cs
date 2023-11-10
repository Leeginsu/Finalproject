using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_TemaPlayer : MonoBehaviour
{
    public float speed = 8f;

    public Animator anim;

    Vector3 moveVelocity = Vector3.zero;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputUp = false;
    public bool inputDown = false;
    public bool inputClick = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();

        M_TemaController m_c = GameObject.FindGameObjectWithTag("Managers").GetComponent<M_TemaController>();
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
            moveVelocity = new Vector3(1f, 0, 0);
            if(!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, 90, 0);
            Move();
        }
        if(inputLeft && inputUp) transform.rotation = Quaternion.Euler(0, 135, 0);
        if(inputLeft && inputDown) transform.rotation = Quaternion.Euler(0, 45, 0);
        if (inputRight)
        {
            moveVelocity = new Vector3(-1f, 0, 0);
            if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, -90, 0);
            Move();
        }
        if(inputRight && inputUp) transform.rotation = Quaternion.Euler(0, -135, 0);
        if(inputRight && inputDown) transform.rotation = Quaternion.Euler(0, -45, 0);
        if (inputUp)
        {
            moveVelocity = new Vector3(0, 0, -1f);
            if(!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(0, 180, 0);
            Move();
        }
        if(inputDown)
        {
            moveVelocity = new Vector3(0, 0, 1f);
            if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(0, 0, 0);
            Move();
        }
        if (!inputLeft && !inputRight && !inputUp && !inputDown)
        {
            anim.SetBool("IsMoving", false);
        }
    }

    void Move()
    {
        anim.SetBool("IsMoving", true);
        transform.position += moveVelocity.normalized * speed * Time.deltaTime;
    }
}