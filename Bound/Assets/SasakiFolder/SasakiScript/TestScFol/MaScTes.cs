using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaScTes : MonoBehaviour
{
    private Texture texture;

    // Start is called before the first frame update
    void Start()
    {
        //script.Fuck();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void GetGroundMat(ref Material groundMat) 
    {
        gameObject.GetComponent<MeshRenderer>().material = groundMat;
    }
}
