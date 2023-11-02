using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        Difficulty();
        instance = this;
        
        for (int i = 0; i < level; i++)
        {
            //Sprite sprite = Resources.Load<Sprite>("Piece_" + i); 160 * 120
            Texture2D tex = Resources.Load("Piece_" + i) as Texture2D;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            puzzleSprite.Add(sprite);
        }
    }
    public List<Sprite> puzzleSprite = new List<Sprite>();
    int level;
    public int puzzleDifficulty;

    public List<GameObject> difficultyAnswer = new List<GameObject>();
    public List<GameObject> difficultyTutorial = new List<GameObject>();
    public List<GameObject> difficultyEasy = new List<GameObject>();
    public List<GameObject> difficultyNormal = new List<GameObject>();
    public List<GameObject> difficultyHard = new List<GameObject>();


    public List<GameObject> puzzlePos = new List<GameObject>();
    public List<GameObject> puzzleTutuorialPos = new List<GameObject>();
    public List<GameObject> puzzleEasyPos = new List<GameObject>();
    public List<GameObject> puzzleNormalPos = new List<GameObject>();
    public List<GameObject> puzzleHardPos = new List<GameObject>();

    public int clearCount = 0;
    public GameObject clearUI;
    public List<GameObject> answerPos = new List<GameObject>();
    public List<GameObject> answerClearPos = new List<GameObject>();
    public GameObject puzzleTutorial;
    public GameObject puzzleEasy;
    public GameObject puzzleNormal;
    public GameObject puzzleHard;
    public GameObject clearPos;
    float speed = 0.01f;

    public bool tutorial = false;
    public bool easy = false;
    public bool normal = false;
    public bool hard= false;
    public float puzzleScale;

    float currentTime;
    public Scrollbar time;
    float maxTime = 1;
    public float timeLimit = 60;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < level; i++)
        {
            int random = Random.Range(0, puzzlePos.Count);
            difficultyAnswer[i].transform.position = puzzlePos[random].transform.position;
            puzzlePos.RemoveAt(random);
        }
        currentTime = timeLimit;
        time.size = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleDifficulty == 0) DifficultyTutorial();
        if (puzzleDifficulty == 1) DifficultyEasy();
        if (puzzleDifficulty == 2) DifficultyNormal();
        if (puzzleDifficulty == 3) DifficultyHard();
        
        // 클리어
        if (clearCount == level)
        {
            Clear();
        }
        TimeLimit();
    }

    public void Difficulty()
    {
        //easy = DifficultyManager.instance.easy;
        //normal = DifficultyManager.instance.normal;
        //hard = DifficultyManager.instance.hard;
        if (tutorial)
        {
            puzzleScale = 2f;
            level = 4;
            puzzleDifficulty = 0;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzleTutorial.SetActive(true);
            puzzlePos.AddRange(puzzleTutuorialPos);
            difficultyAnswer.AddRange(difficultyTutorial);
        }
        if (easy)
        {
            puzzleScale = 2.5f;
            level = 9;
            puzzleDifficulty = 1;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzleEasy.SetActive(true);
            puzzlePos.AddRange(puzzleEasyPos);
            difficultyAnswer.AddRange(difficultyEasy);
        }
        if (normal)
        {
            puzzleScale = 3f;
            level = 12;
            puzzleDifficulty = 2;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzleNormal.SetActive(true);
            puzzlePos.AddRange(puzzleNormalPos);
            difficultyAnswer.AddRange(difficultyNormal);
        }
        if (hard)
        {
            puzzleScale = 3f;
            level = 16;
            puzzleDifficulty = 3;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzleHard.SetActive(true);
            puzzlePos.AddRange(puzzleHardPos);
            difficultyAnswer.AddRange(difficultyHard);
        }
    }

    public void DifficultyTutorial()
    {
        for (int i = 0; i < difficultyTutorial.Count; i++)
        {
            difficultyTutorial[i].GetComponent<SpriteRenderer>().sprite = puzzleSprite[i];
            answerPos[puzzleDifficulty].transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = puzzleSprite[i];
        }
    }

    public void DifficultyEasy()
    {
        for (int i = 0; i < difficultyEasy.Count; i++)
        {
            difficultyEasy[i].GetComponent<SpriteRenderer>().sprite = puzzleSprite[i];
            answerPos[puzzleDifficulty].transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = puzzleSprite[i];
        }
    }

    public void DifficultyNormal()
    {
        for (int i = 0; i < difficultyNormal.Count; i++)
        {
            difficultyNormal[i].GetComponent<SpriteRenderer>().sprite = puzzleSprite[i];
            answerPos[puzzleDifficulty].transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = puzzleSprite[i];
        }
    }

    public void DifficultyHard()
    {
        for (int i = 0; i < difficultyHard.Count; i++)
        {
            difficultyHard[i].GetComponent<SpriteRenderer>().sprite = puzzleSprite[i];
            answerPos[puzzleDifficulty].transform.GetChild(i).GetComponentInChildren<SpriteRenderer>().sprite = puzzleSprite[i];
        }
    }

    // 클리어
    public void Clear()
    {
        clearUI.SetActive(true);
        answerPos[puzzleDifficulty].transform.localPosition = Vector3.MoveTowards(answerPos[puzzleDifficulty].transform.localPosition, clearPos.transform.localPosition, speed);
        for(int i = 0; i < level; i++)
        {
            answerPos[puzzleDifficulty].transform.GetChild(i).transform.localPosition = 
                Vector3.MoveTowards(answerPos[puzzleDifficulty].transform.GetChild(i).transform.localPosition, answerClearPos[0].transform.GetChild(i).transform.localPosition, 0.001f);
        }
    }

    // 시간제한
    public void TimeLimit()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            time.size = currentTime / timeLimit;
        }
        else currentTime = 0;
    }
}
