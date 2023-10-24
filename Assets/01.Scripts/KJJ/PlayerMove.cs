using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 8f;
    public GameObject puzzle;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puzzleCount.Count == 1 && check == true)
            {
                puzzleCount[0].transform.parent = transform;
                puzzleCount.RemoveAt(0);
                transform.GetComponentInChildren<T_Drop>().space = false;
            }
            else if (transform.childCount > 0)
            {
                transform.GetComponentInChildren<T_Drop>().space = true;
                transform.GetChild(0).transform.parent = puzzle.transform;
                check = false;
            }
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

    private void OnTriggerStay(Collider other)
    {
        
        
        //if(this.transform.childCount <= 0 && Input.GetKeyDown(KeyCode.Space))
        //{
        //        other.gameObject.transform.SetParent(this.transform);
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        this.transform.GetChild(0).SetParent(puzzle.transform);
        //    }
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        puzzleCount.Clear();
        check = false;
        //puzzleCount.Clear();
    }

}
