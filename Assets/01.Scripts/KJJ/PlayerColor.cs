using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public SkinnedMeshRenderer color;

    public Material red;
    public Material blue;
    public Material green;
    public Material pink;
    public Material yellow;
    public Material white;

    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Red();
        Blue();
        Green();
        Pink();
        Yellow();
        White();
    }

    public void Red()
    {
        color.material = red;
    }
    public void Blue()
    {
        color.material = blue;
    }
    public void Green()
    {
        color.material = green;
    }
    public void Pink()
    {
        color.material = pink;
    }
    public void Yellow()
    {
        color.material = yellow;
    }
    public void White()
    {
        color.material = white;
    }
}
