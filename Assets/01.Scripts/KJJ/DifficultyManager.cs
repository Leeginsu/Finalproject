using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool tutorial = false;
    public bool easy = false;
    public bool normal = false;
    public bool hard = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
