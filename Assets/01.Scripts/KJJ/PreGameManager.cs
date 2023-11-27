using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PreGameManager : MonoBehaviourPun
{
    public static PreGameManager instance;

    public Transform[] spotGroup;
    public GameObject conUI;

    private void Awake()
    {
        Difficulty();

        instance = this;
    }

    // 퍼즐 조각에 이미지를 넣을 변수
    public List<Sprite> puzzleSprite = new List<Sprite>();

    // 퍼즐조각 갯수
    int level;

    float speed = 0.01f;

    // 퍼즐의 가로, 세로
    public int width = 0;
    public int length = 0;

    // 플레이어 기본 위치값을 0,0 으로 만들기위한 값
    public List<GameObject> initial = new List<GameObject>();
    public Vector3 initialxy;


    public int puzzleDifficulty;

    // 퍼즐 조각의 위치를 편하게 부르기위한 변수
    public List<GameObject> difficultyAnswer = new List<GameObject>();

    // 퍼즐 조각의 위치
    public List<GameObject> difficultyTutorial = new List<GameObject>();
    public List<GameObject> difficultyEasy = new List<GameObject>();
    public List<GameObject> difficultyNormal = new List<GameObject>();
    public List<GameObject> difficultyHard = new List<GameObject>();

    // 퍼즐조각을 편하게 섞기 위한 변수
    public List<GameObject> puzzlePos = new List<GameObject>();

    // 퍼즐조각을 섞기 위한 퍼즐조각의 위치
    public List<GameObject> puzzleTutuorialPos = new List<GameObject>();
    public List<GameObject> puzzleEasyPos = new List<GameObject>();
    public List<GameObject> puzzleNormalPos = new List<GameObject>();
    public List<GameObject> puzzleHardPos = new List<GameObject>();

    // 클리어 판별 카운트
    public int clearCount = 0;

    // 클리어, 실패 UI
    public GameObject clearUI;
    public GameObject failUI;

    // 퍼즐판의 위치
    public List<GameObject> answerPos = new List<GameObject>();

    // 클리어시 퍼즐판이 합쳐지기위한 위치
    public List<GameObject> answerClearPos = new List<GameObject>();

    public GameObject clearPos;

    // 테스트용
    bool tutorial = true;
    public bool easy = false;
    public bool normal = false;
    public bool hard = false;

    // 타이머
    public float currentTime;
    public Scrollbar time;
    public float timeLimit = 60;

    // 플레이어 좌표계산을위한 변수
    public float posx;
    public float posy;
    public float widthx;
    public float lengthy;

    // 플레이어 위치 초기화
    public GameObject aa;
    bool clearOn = true;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeLimit;
        time.size = 1;
        TImageLoad();
        PuzzleRandom();

        ImageIn();
        initialxy = initial[puzzleDifficulty].transform.position;
        print(initialxy);
        //if (Application.isMobilePlatform || NetworkManager.instance.isMoblie)
        //{
        //    conUI.SetActive(true);
        //    print("켜져라");
        //    idx = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        //    //int idx = 1;
        //    //Invoke("PlayerInstance", 1f);
        //    //PhotonNetwork.Instantiate("Player_Photon", spotGroup[idx].position, Quaternion.Euler(-90, 0, 0));
        //}
        //else
        //{
        //    conUI.SetActive(false);
        //    //PhotonNetwork.Instantiate("Player_Photon", spotGroup[0].position, Quaternion.Euler(-90, 0, 0));
        //    //Invoke("PlayerInstance", 1f);
        //}
        if (clearOn) ClearOn();
    }

    // Update is called once per frame
    void Update()
    {
        NetworkManager.instance.tema = false;
        // 클리어
        if (clearCount == level && level == 4)
        {
            scoreCount--;
            clearOn = true;
            clearCount = 0;
            tutorial = false;
            easy = true;
            EClear();
            if (clearOn) ClearOn();
        }
        if (clearCount == level && level == 9)
        {
            scoreCount--;
            clearCount = 0;
            easy = false;
            hard = true;
            Clear();
            if (clearOn) ClearOn();
        }
        if (clearCount == level && level == 16)
        {
            scoreCount = 0;
            End();
            clearUI.SetActive(true);
            if (clearOn) ClearOn();
            if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel("GalleryScene");
            clearCount = 0;
            //ClearMove();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            clearCount = level;
        }
        TimeLimit();
        ImageCount();
    }

    // 퍼즐 난이도 정보
    public void Difficulty()
    {
        if (tutorial)
        {
            width = 2;
            length = 2;
            level = width * length;
            puzzleDifficulty = 0;
            answerPos[puzzleDifficulty].SetActive(true);
            difficultyAnswer.Clear();
            difficultyAnswer.AddRange(difficultyTutorial);
            puzzlePos.Clear();
            puzzlePos.AddRange(puzzleTutuorialPos);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);

            // 무조건 0이 되야하므로 계산 잘해야됨
            posx = -0.4284096f;
            posy = 2.433241f;
            widthx = 3.4f;
            lengthy = 3.4f;
        }
        if (easy)
        {
            width = 3;
            length = 3;
            level = width * length;
            puzzleDifficulty = 1;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzlePos.Clear();
            puzzlePos.AddRange(puzzleEasyPos);
            difficultyAnswer.Clear();
            difficultyAnswer.AddRange(difficultyEasy);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);

            posx = -0.3384099f;
            posy = 2.483242f;
            widthx = 2.3f;
            lengthy = 2.3f;
        }
        if (normal)
        {
            width = 4;
            length = 3;
            level = width * length;
            puzzleDifficulty = 2;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzlePos.Clear();
            puzzlePos.AddRange(puzzleNormalPos);
            difficultyAnswer.Clear();
            difficultyAnswer.AddRange(difficultyNormal);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);
        }
        if (hard)
        {
            width = 4;
            length = 4;
            level = width * length;
            puzzleDifficulty = 3;
            answerPos[puzzleDifficulty].SetActive(true);
            puzzlePos.Clear();
            puzzlePos.AddRange(puzzleHardPos);
            difficultyAnswer.Clear();
            difficultyAnswer.AddRange(difficultyHard);
            difficultyAnswer[0].transform.parent.gameObject.SetActive(true);

            posx = -0.458409f;
            posy = 2.393241f;
            widthx = 1.68f;
            lengthy = 1.68f;
        }
    }

    // 퍼즐조각, 퍼즐판에 이미지 삽입
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
        answerPos[puzzleDifficulty].SetActive(false);
        difficultyAnswer[0].transform.parent.gameObject.SetActive(false);
        Difficulty();
        ImageLoad();
        PuzzleRandom();
        ImageIn();
    }

    public void End()
    {
        answerPos[puzzleDifficulty].SetActive(false);
        difficultyAnswer[0].transform.parent.gameObject.SetActive(false);
    }


    public void EClear()
    {
        answerPos[puzzleDifficulty].SetActive(false);
        difficultyAnswer[0].transform.parent.gameObject.SetActive(false);
        Difficulty();
        EImageLoad();
        PuzzleRandom();
        ImageIn();
    }

    public void ClearMove()
    {
        clearCount = 0;
        clearUI.SetActive(true);
        answerPos[puzzleDifficulty].transform.localPosition = Vector3.MoveTowards(answerPos[puzzleDifficulty].transform.localPosition, clearPos.transform.localPosition, speed);
        for (int i = 0; i < level; i++)
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
        else if (currentTime <= 0)
        {
            failUI.SetActive(true);
            End();
        }
        if (currentTime < timeLimit / 5) Timer.instane.timerOn = true;
    }

    // 퍼즐 이미지 로드
    public void TImageLoad()
    {
        // 변수초기화
        puzzleSprite.Clear();
        for (int i = 0; i < level; i++)
        {
            // 이미지 불러오기
            Texture2D tex = Resources.Load("PieceT_" + i) as Texture2D;
            // 이미지 생성
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            // 생성된 이미지 삽입
            puzzleSprite.Add(sprite);
        }
    }

    public void EImageLoad()
    {
        // 변수초기화
        puzzleSprite.Clear();
        for (int i = 0; i < level; i++)
        {
            // 이미지 불러오기
            Texture2D tex = Resources.Load("PieceE_" + i) as Texture2D;
            // 이미지 생성
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            // 생성된 이미지 삽입
            puzzleSprite.Add(sprite);
        }
    }

    public void ImageLoad()
    {
        // 변수초기화
        puzzleSprite.Clear();
        for (int i = 0; i < level; i++)
        {
            // 이미지 불러오기
            Texture2D tex = Resources.Load("Piece_" + i) as Texture2D;
            // 이미지 생성
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            // 생성된 이미지 삽입
            puzzleSprite.Add(sprite);
        }
    }

    // 퍼즐조각 섞기
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

    // 이미지 삽입
    void ImageIn()
    {
        if (puzzleDifficulty == 0) DifficultyTutorial();
        if (puzzleDifficulty == 1) DifficultyEasy();
        if (puzzleDifficulty == 2) DifficultyNormal();
        if (puzzleDifficulty == 3) DifficultyHard();
    }

    public Text score;
    public int scoreCount = 3;

    public void ImageCount()
    {
        score.GetComponent<Text>().text = scoreCount.ToString();
    }

    // 위치 초기화
    void ClearOn()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            NetworkManager.instance.playerInfo[0].transform.position = aa.transform.position;
            NetworkManager.instance.playerInfo[0].transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        clearOn = false;
    }

}
