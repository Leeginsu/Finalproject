using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        Difficulty();
        instance = this;

        for (int i = 0; i < level; i++)
        {
            Sprite sprite = Resources.Load<Sprite>("P_" + i);
            puzzleSprite.Add(sprite);
        }
    }
    public List<Sprite> puzzleSprite = new List<Sprite>();
    int level;
    public int puzzleDifficulty;
    public List<GameObject> difficulty = new List<GameObject>();
    public int clearCount = 0;
    public GameObject clearUI;
    public GameObject answerPosTutorial;
    public GameObject puzzleTutorial;
    public GameObject answerPosEasy;
    public GameObject puzzleEasy;
    public GameObject answerPosNormal;
    public GameObject puzzleNormal;
    public GameObject answerPosHard;
    public GameObject puzzleHard;
    public GameObject clearPos;
    float speed = 0.01f;
    
    public bool tutorial;
    public bool easy;
    public bool normal, hard;
    public float puzzleScale;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < difficulty.Count; i++)
        {
            difficulty[i].GetComponent<SpriteRenderer>().sprite = puzzleSprite[i];
        }
        if(clearCount == level)
        {
            clearUI.SetActive(true);
            answerPosTutorial.transform.localPosition = Vector3.MoveTowards(answerPosTutorial.transform.localPosition, clearPos.transform.localPosition, speed);
        }
    }

    public void Difficulty()
    {
        if (tutorial)
        {
            puzzleScale = 2f;
            level = 4;
            puzzleDifficulty = 0;
            answerPosTutorial.SetActive(true);
            puzzleTutorial.SetActive(true);
        }
        if (easy)
        {
            puzzleScale = 2.5f;
            level = 9;
            puzzleDifficulty = 1;
            answerPosEasy.SetActive(true);
        }
        if (normal)
        {
            puzzleScale = 3f;
            level = 12;
            puzzleDifficulty = 2;
            answerPosNormal.SetActive(true);
        }
        if (hard)
        {
            puzzleScale = 3f;
            level = 16;
            puzzleDifficulty = 3;
            answerPosHard.SetActive(true);
        }
    }
}
