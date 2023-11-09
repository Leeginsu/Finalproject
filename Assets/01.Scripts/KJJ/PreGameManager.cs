using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreGameManager : MonoBehaviour
{
    public static PreGameManager instance;
    private void Awake()
    {
        Difficulty();
        instance = this;
    }

    // ���� ������ �̹����� ���� ����
    public List<Sprite> puzzleSprite = new List<Sprite>();

    // �������� ����
    int level;

    public int puzzleDifficulty;

    // ���� ������ ��ġ�� ���ϰ� �θ������� ����
    public List<GameObject> difficultyAnswer = new List<GameObject>();

    // ���� ������ ��ġ
    public List<GameObject> difficultyTutorial = new List<GameObject>();
    public List<GameObject> difficultyEasy = new List<GameObject>();
    public List<GameObject> difficultyNormal = new List<GameObject>();
    public List<GameObject> difficultyHard = new List<GameObject>();

    // ���������� ���ϰ� ���� ���� ����
    public List<GameObject> puzzlePos = new List<GameObject>();

    // ���������� ���� ���� ���������� ��ġ
    public List<GameObject> puzzleTutuorialPos = new List<GameObject>();
    public List<GameObject> puzzleEasyPos = new List<GameObject>();
    public List<GameObject> puzzleNormalPos = new List<GameObject>();
    public List<GameObject> puzzleHardPos = new List<GameObject>();

    // Ŭ���� �Ǻ� ī��Ʈ
    public int clearCount = 0;

    // Ŭ����, ���� UI
    public GameObject clearUI;
    public GameObject failUI;

    // �������� ��ġ
    public List<GameObject> answerPos = new List<GameObject>();

    // Ŭ����� �������� ������������ ��ġ
    public List<GameObject> answerClearPos = new List<GameObject>();

    public GameObject clearPos;
    float speed = 0.01f;

    // �׽�Ʈ��
    public bool tutorial = false;
    public bool easy = false;
    public bool normal = false;
    public bool hard = false;

    // Ÿ�̸�
    public float currentTime;
    public Scrollbar time;
    public float timeLimit = 60;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeLimit;
        time.size = 1;
        ImageLoad();
        PuzzleRandom();

        if (puzzleDifficulty == 0) DifficultyTutorial();
        if (puzzleDifficulty == 1) DifficultyEasy();
        if (puzzleDifficulty == 2) DifficultyNormal();
        if (puzzleDifficulty == 3) DifficultyHard();

        //clearUI = GameObject.FindGameObjectWithTag("ClearUI");
        //failUI = GameObject.FindGameObjectWithTag("FailUI");
    }

    // Update is called once per frame
    void Update()
    {
        // Ŭ����
        if (clearCount == level)
        {
            Clear();
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            // ���� �̹��� �ε�
            ImageLoad();

            // ���񼯱�
            PuzzleRandom();
            //Clear();
        }
        TimeLimit();
    }

    // ���� ���̵� ����
    public void Difficulty()
    {
        if (tutorial)
        {
            level = 4;
            puzzleDifficulty = 0;
            answerPos[puzzleDifficulty].SetActive(true);
            difficultyAnswer.AddRange(difficultyTutorial);
            puzzlePos.AddRange(puzzleTutuorialPos);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);
        }
        if (easy)
        {
            level = 9;
            puzzleDifficulty = 1;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzlePos.AddRange(puzzleEasyPos);
            difficultyAnswer.AddRange(difficultyEasy);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);
        }
        if (normal)
        {
            level = 12;
            puzzleDifficulty = 2;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzlePos.AddRange(puzzleNormalPos);
            difficultyAnswer.AddRange(difficultyNormal);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);
        }
        if (hard)
        {
            level = 16;
            puzzleDifficulty = 3;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzlePos.AddRange(puzzleHardPos);
            difficultyAnswer.AddRange(difficultyHard);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);
        }
    }

    // ��������, �����ǿ� �̹��� ����
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

    // Ŭ����
    public void Clear()
    {
        clearCount = 0;

        //clearUI.SetActive(true);
        //answerPos[puzzleDifficulty].transform.localPosition = Vector3.MoveTowards(answerPos[puzzleDifficulty].transform.localPosition, clearPos.transform.localPosition, speed);
        //for (int i = 0; i < level; i++)
        //{
        //    answerPos[puzzleDifficulty].transform.GetChild(i).transform.localPosition =
        //        Vector3.MoveTowards(answerPos[puzzleDifficulty].transform.GetChild(i).transform.localPosition, answerClearPos[0].transform.GetChild(i).transform.localPosition, 0.001f);
        //}
    }

    // �ð�����
    public void TimeLimit()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            time.size = currentTime / timeLimit;
        }
        else if (currentTime <= 0)
        {
            failUI.SetActive(true);
        }
    }

    // ���� �̹��� �ε�
    public void ImageLoad()
    {
        // �����ʱ�ȭ
        puzzleSprite.Clear();
        for (int i = 0; i < level; i++)
        {
            // �̹��� �ҷ�����
            Texture2D tex = Resources.Load("Piece_" + i) as Texture2D;
            // �̹��� ����
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            // ������ �̹��� ����
            puzzleSprite.Add(sprite);
        }
    }

    // �������� ����
    public void PuzzleRandom()
    {
        GameObject[] puzzleSave = puzzlePos.ToArray();

        for (int i = 0; i < level; i++)
        {
            int random = Random.Range(0, puzzlePos.Count);
            difficultyAnswer[i].transform.position = puzzlePos[random].transform.position;
            puzzlePos.RemoveAt(random);
        }
        for (int i = 0; i < puzzleSave.Length; i++)
        {
            puzzlePos.Add(puzzleSave[i]);
        }
    }
}
