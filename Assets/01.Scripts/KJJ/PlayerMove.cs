using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    public GameObject puzzleDifTutorial;
    public GameObject puzzleDifEasy;
    public GameObject puzzleDifNormal;
    public GameObject puzzleDifHard;
    GameObject puzzle;
    bool grab = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.puzzleDifficulty == 0) puzzle = puzzleDifTutorial;
        else if (GameManager.instance.puzzleDifficulty == 1) puzzle = puzzleDifEasy;
        else if (GameManager.instance.puzzleDifficulty == 2) puzzle = puzzleDifNormal;
        else if (GameManager.instance.puzzleDifficulty == 3) puzzle = puzzleDifHard;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puzzleCount.Count == 1 && check == true)
            {
                puzzleCount[0].transform.parent = transform;
                puzzleCount.RemoveAt(0);
                transform.GetComponentInChildren<T_Drop>().space = false;
                grab = true;
            }
            else if (transform.childCount > 0)
            {
                transform.GetComponentInChildren<T_Drop>().space = true;
                transform.GetChild(0).transform.parent = puzzle.transform;
                check = false;
                grab = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && grab)
        {
            transform.GetChild(0).Rotate(0,0,-90);
        }
    }

    public List<GameObject> puzzleCount = new List<GameObject>();

    bool check = false;

    private void OnTriggerEnter(Collider other)
    {
        if (puzzleCount.Count == 0 && check == false && other.CompareTag("Puzzle"))
        {
            puzzleCount.Add(other.gameObject);
            check = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        puzzleCount.Clear();
        check = false;
    }
}
