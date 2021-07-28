using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public Vector3 lockpos;
    public GameObject WaterCan;
    public GameObject player;
    public Material CanMat;
    RaycastHit hit;
    static int correct = 0;
    bool done = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.BoxCast(lockpos, Vector3.one/2000,Vector3.forward, out hit))     //
        {
            if (hit.collider.tag == "interactable" && done != true)
            {
                player.GetComponent<move>().interacted = false;
                hit.transform.position = lockpos;
                hit.transform.rotation = Quaternion.Euler(0, 0, 0);
                done = true;
        }

        }
        if (player.GetComponent<move>().interacted == true)
        {
            done = false;
        }
     
    }

}
