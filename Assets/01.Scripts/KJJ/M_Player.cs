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
    public bool inputClick = false;

    public GameObject puzzleDifTutorial;
    public GameObject puzzleDifEasy;
    public GameObject puzzleDifNormal;
    public GameObject puzzleDifHard;
    GameObject puzzle;
    bool grab = false;

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
        if (PreGameManager.instance.puzzleDifficulty == 0) puzzle = puzzleDifTutorial;
        else if (PreGameManager.instance.puzzleDifficulty == 1) puzzle = puzzleDifEasy;
        else if (PreGameManager.instance.puzzleDifficulty == 2) puzzle = puzzleDifNormal;
        else if (PreGameManager.instance.puzzleDifficulty == 3) puzzle = puzzleDifHard;

        if (Input.GetKeyDown(KeyCode.Alpha1)) GameManager.instance.currentTime = 0;
        
        RayCast();
        
        if(inputClick)
        {
            if (puzzleCount.Count == 1 && check == true)
            {

                puzzleCount[0].transform.parent = transform;
                puzzleCount.RemoveAt(0);
                transform.GetComponentInChildren<T_Drop>().space = false;
                grab = true;
            }
            else if (transform.childCount > 4)
            {
                int n = TTT();
                transform.GetComponentInChildren<T_Drop>().CheckAnswer(n);
                transform.GetComponentInChildren<T_Drop>().space = true;
                transform.GetChild(4).transform.parent = puzzle.transform;
                check = false;
                grab = false;
            }
            inputClick = false;
        }
        if(grab && transform.childCount == 5)
        {
            transform.GetChild(4).transform.localPosition = new Vector3(0,0,0);
            transform.GetChild(4).transform.rotation = Quaternion.Euler(0,0,0);
        }
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

    public List<GameObject> puzzleCount = new List<GameObject>();

    public bool check = false;

    private void FixedUpdate()
    {
        if(inputLeft)
        {
            moveVelocity = new Vector3(-1f, 0, 0);
            if(!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, -90, 90);
            Move();
        }
        if(inputLeft && inputUp) transform.rotation = Quaternion.Euler(-45, -90, 90);
        if(inputLeft && inputDown) transform.rotation = Quaternion.Euler(-315, -90, 90);
        if (inputRight)
        {
            moveVelocity = new Vector3(1f, 0, 0);
            if (!inputUp && !inputDown) transform.rotation = Quaternion.Euler(0, 90, -90);
            Move();
        }
        if(inputRight && inputUp) transform.rotation = Quaternion.Euler(-45, 90, -90);
        if(inputRight && inputDown) transform.rotation = Quaternion.Euler(-225, -90, 90);
        if (inputUp)
        {
            moveVelocity = new Vector3(0, 1f, 0);
            if(!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(-90, 0, 0);
            Move();
        }
        if(inputDown)
        {
            moveVelocity = new Vector3(0, -1f, 0);
            if (!inputLeft && !inputRight) transform.rotation = Quaternion.Euler(-270, -90, 90);
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
    void RayCast()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Puzzle");

        if (puzzleCount.Count != 0) check = true;
        else check = false;

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            if (puzzleCount.Count == 0 && transform.childCount == 4 && check == false && hit.transform.gameObject.CompareTag("Puzzle"))
            {
                puzzleCount.Add(hit.transform.gameObject);
            }
            else if (!hit.transform.gameObject.CompareTag("Puzzle")) puzzleCount.Clear();
        }
    }
}
