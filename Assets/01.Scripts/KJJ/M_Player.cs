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

        if (GameManager.instance.puzzleDifficulty == 0) puzzle = puzzleDifTutorial;
        else if (GameManager.instance.puzzleDifficulty == 1) puzzle = puzzleDifEasy;
        else if (GameManager.instance.puzzleDifficulty == 2) puzzle = puzzleDifNormal;
        else if (GameManager.instance.puzzleDifficulty == 3) puzzle = puzzleDifHard;
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position += (moveVelocity * speed).normalized * Time.deltaTime;
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
        }
    }
}
