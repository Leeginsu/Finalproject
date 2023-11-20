using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PhotonPlayer : MonoBehaviourPun
{
    float speed = 6f;

    public Animator anim;

    Vector3 moveVelocity = Vector3.zero;

    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputUp = false;
    public bool inputDown = false;
    public bool inputClick = false;

    public GameObject puzzleDifTutorial;
    public GameObject puzzleDifEasy;
    public GameObject puzzleDifNormal;
    public GameObject puzzleDifHard;
    GameObject puzzle;

    public M_Controller m_c;
    public GameObject controll;

    bool temapuzzle = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();

        m_c = GetComponent<M_Controller>();
        if (m_c == null) return;
        else m_c.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NetworkManager.instance.tema && temapuzzle)
        {
            puzzleDifTutorial = PreGameManager.instance.difficultyTutorial[0].transform.parent.gameObject;
            puzzleDifEasy = PreGameManager.instance.difficultyEasy[0].transform.parent.gameObject;
            puzzleDifNormal = PreGameManager.instance.difficultyNormal[0].transform.parent.gameObject;
            puzzleDifHard = PreGameManager.instance.difficultyHard[0].transform.parent.gameObject;
            temapuzzle = false; 
        }

        if (!NetworkManager.instance.tema)
        {
            if (PreGameManager.instance.puzzleDifficulty == 0) puzzle = puzzleDifTutorial;
            else if (PreGameManager.instance.puzzleDifficulty == 1) puzzle = puzzleDifEasy;
            else if (PreGameManager.instance.puzzleDifficulty == 2) puzzle = puzzleDifNormal;
            else if (PreGameManager.instance.puzzleDifficulty == 3) puzzle = puzzleDifHard;
        }
        if(PhotonNetwork.IsMasterClient) DontDestroyOnLoad(this.gameObject);
        if (photonView.IsMine)
        {
            DontDestroyOnLoad(this.gameObject);
            controll.SetActive(true);
            if (inputClick)
            {
                photonView.RPC(nameof(RpcInputClick), RpcTarget.MasterClient);
                inputClick = false;
            }
        }

        if (puzzleCount != null)
        {
            puzzleCount.transform.localPosition = new Vector3(0, 0, 0);
            puzzleCount.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
     
    // RPC 퍼즐상호작용
    [PunRPC]
    void RpcInputClick()
    {
        // puzzleCount에 아무것도 없을때 RayCast를 실행
        if (puzzleCount == null) RayCast();

        // puzzleCount에 무언가 있다면
        else if (puzzleCount != null)
        {
            int n = TTT();
            // 정답인지 체크
            transform.GetComponentInChildren<T_Drop>().CheckAnswer(n);
            transform.GetComponentInChildren<T_Drop>().space = true;
            // puzzleCount의 부모를 퍼즐판으로 바꾸고
            puzzleCount.transform.parent = puzzle.transform;
            // puzzleCount를 비운다.
            puzzleCount = null;
        }
    }

    // RPG 애니메이션
    [PunRPC]
    void Animations(string parameter, bool b)
    {
        anim.SetBool(parameter, b);
    }

    public int TTT()
    {
        // 가로
        int w = PreGameManager.instance.width;
        // 세로
        int l = PreGameManager.instance.length;

        //-0.4115905, -3.233241 (플레이어 위치를 0,0으로 만들기위한 값)
        // 플레이어 위치
        Vector3 pos = transform.position;
        // 플레이어 위치를 0,0으로 만들기위해 값을 추가
        //pos.x += 0.4115905f;
        pos.x += PreGameManager.instance.posx;
        //pos.y += 3.233241f;
        pos.y += PreGameManager.instance.posy;

        // 좌표 구하기 공식
        // (x좌표/1칸의 가로길이) + ((y좌표/1칸의 세로길이) * 세로칸수)
        //int x = (int)(pos.x / 2.8f);
        int x = (int)(pos.x / PreGameManager.instance.widthx);
        //int y = (int)(pos.y / 2.8f);
        int y = (int)(pos.y / PreGameManager.instance.lengthy);
        int answerIdx = x + (y * l);

        answerIdx += ((w * (l - 1)) + (-(w * 2) * y));
        if (pos.x < 0 || pos.y < 0) answerIdx = 100;
        print(pos + " --- " + answerIdx);
        return answerIdx;
    }

    GameObject puzzleCount = null;

    public bool check = false;

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            if (NetworkManager.instance.tema)
            {
                if (inputLeft)
                {
                    moveVelocity = new Vector3(1f, 0, 0);
                    if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, 90, 0);
                    Move();
                    //anim.SetBool("IsMoving", true);
                    transform.position += moveVelocity.normalized * (speed/2) * Time.deltaTime;
                }
                if (inputLeft && inputUp) transform.rotation = Quaternion.Euler(0, 135, 0);
                if (inputLeft && inputDown) transform.rotation = Quaternion.Euler(0, 45, 0);
                if (inputRight)
                {
                    moveVelocity = new Vector3(-1f, 0, 0);
                    if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, -90, 0);
                    Move();
                    //anim.SetBool("IsMoving", true);
                    transform.position += moveVelocity.normalized * (speed / 2) * Time.deltaTime;
                }
                if (inputRight && inputUp) transform.rotation = Quaternion.Euler(0, -135, 0);
                if (inputRight && inputDown) transform.rotation = Quaternion.Euler(0, -45, 0);
                if (inputUp)
                {
                    moveVelocity = new Vector3(0, 0, -1f);
                    if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(0, 180, 0);
                    Move();
                    //anim.SetBool("IsMoving", true);
                    transform.position += moveVelocity.normalized * (speed / 2) * Time.deltaTime;
                }
                if (inputDown)
                {
                    moveVelocity = new Vector3(0, 0, 1f);
                    if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(0, 0, 0);
                    Move();
                    //anim.SetBool("IsMoving", true);
                    transform.position += moveVelocity.normalized * (speed / 2) * Time.deltaTime;
                }
                if (!inputLeft && !inputRight && !inputUp && !inputDown)
                {
                    photonView.RPC(nameof(Animations), RpcTarget.MasterClient, "IsMoving", false);
                }
            }
            else
            {
                if (inputLeft)
                {
                    moveVelocity = new Vector3(-1f, 0, 0);
                    if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, -90, 90);
                    Move();
                }
                if (inputLeft && inputUp) transform.rotation = Quaternion.Euler(-45, -90, 90);
                if (inputLeft && inputDown) transform.rotation = Quaternion.Euler(-315, -90, 90);
                if (inputRight)
                {
                    moveVelocity = new Vector3(1f, 0, 0);
                    if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, 90, -90);
                    Move();
                }
                if (inputRight && inputUp) transform.rotation = Quaternion.Euler(-45, 90, -90);
                if (inputRight && inputDown) transform.rotation = Quaternion.Euler(-225, -90, 90);
                if (inputUp)
                {
                    moveVelocity = new Vector3(0, 1f, 0);
                    if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(-90, 0, 0);
                    Move();
                }
                if (inputDown)
                {
                    moveVelocity = new Vector3(0, -1f, 0);
                    if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(-270, -90, 90);
                    Move();
                }
                if (!inputLeft && !inputRight && !inputUp && !inputDown)
                {
                    photonView.RPC(nameof(Animations), RpcTarget.MasterClient, "IsMoving", false);
                    //anim.SetBool("IsMoving", false);
                }
            }
        }

    }

    void Move()
    {
        photonView.RPC(nameof(Animations), RpcTarget.MasterClient, "IsMoving", true);
        //anim.SetBool("IsMoving", true);
        transform.position += moveVelocity.normalized * speed * Time.deltaTime;
    }

    // 잡기
    void RayCast()
    {
        // 레이를 쏘고
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Puzzle");

        // 퍼즐레이어가 달린 오브젝트가 걸리면
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            // puzzleCount에 hit게임오브젝트를 넣고
            puzzleCount = hit.transform.gameObject;
            // puzzleCount의 부모를 플레이어로 바꾼다.
            puzzleCount.transform.parent = transform;
            transform.GetComponentInChildren<T_Drop>().space = false;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
