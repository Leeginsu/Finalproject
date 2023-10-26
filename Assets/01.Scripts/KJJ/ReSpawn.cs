using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    public GameObject PlayerSpawn;
    Vector3 spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = PlayerSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        other.transform.position = spawn;
    }
}
