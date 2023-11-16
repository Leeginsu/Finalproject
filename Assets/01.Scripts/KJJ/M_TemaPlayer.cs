using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class M_TemaPlayer : MonoBehaviourPun
{
    float speed = 6f;

    public Animator anim;

    Vector3 moveVelocity = Vector3.zero;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputUp = false;
    public bool inputDown = false;
    public bool inputClick = false;

    public M_TemaController m_c;
    public GameObject controll;

    // Start is called before the first frame update
    void Start()
    {
        m_c = GetComponent<M_TemaController>();
        if (m_c == null) return;
        else m_c.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            controll.SetActive(true);
            anim = gameObject.GetComponentInChildren<Animator>();
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            if (inputLeft)
            {
                moveVelocity = new Vector3(1f, 0, 0);
                if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, 90, 0);
                //Move();
                anim.SetBool("IsMoving", true);
                transform.position += moveVelocity.normalized * speed * Time.deltaTime;
            }
            if (inputLeft && inputUp) transform.rotation = Quaternion.Euler(0, 135, 0);
            if (inputLeft && inputDown) transform.rotation = Quaternion.Euler(0, 45, 0);
            if (inputRight)
            {
                moveVelocity = new Vector3(-1f, 0, 0);
                if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, -90, 0);
                //Move();
                anim.SetBool("IsMoving", true);
                transform.position += moveVelocity.normalized * speed * Time.deltaTime;
            }
            if (inputRight && inputUp) transform.rotation = Quaternion.Euler(0, -135, 0);
            if (inputRight && inputDown) transform.rotation = Quaternion.Euler(0, -45, 0);
            if (inputUp)
            {
                moveVelocity = new Vector3(0, 0, -1f);
                if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(0, 180, 0);
                //Move();
                anim.SetBool("IsMoving", true);
                transform.position += moveVelocity.normalized * speed * Time.deltaTime;
            }
            if (inputDown)
            {
                moveVelocity = new Vector3(0, 0, 1f);
                if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(0, 0, 0);
                //Move();
                anim.SetBool("IsMoving", true);
                transform.position += moveVelocity.normalized * speed * Time.deltaTime;
            }
            if (!inputLeft && !inputRight && !inputUp && !inputDown)
            {
                anim.SetBool("IsMoving", false);
            }
        }
    }

    void Move()
    {
        anim.SetBool("IsMoving", true);
        transform.position += moveVelocity.normalized * speed * Time.deltaTime;
    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(transform.position);
    //        stream.SendNext(transform.rotation);
    //    }
    //    else
    //    {
    //        transform.position = (Vector3)stream.ReceiveNext();
    //    }
    //}
}
