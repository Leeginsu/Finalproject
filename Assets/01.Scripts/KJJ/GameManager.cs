using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;

        for (int i = 0; i < num; i++)
        {
            Sprite sprite = Resources.Load<Sprite>("P_" + i);
            puzzleSprite.Add(sprite);
        }
    }
    public List<Sprite> puzzleSprite = new List<Sprite>();
    int num = 4;
    public List<GameObject> easy = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < easy.Count; i++)
        {
            easy[i].GetComponent<SpriteRenderer>().sprite = puzzleSprite[i];
        }
    }
}
