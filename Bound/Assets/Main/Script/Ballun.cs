﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ballun : MonoBehaviour
{
    [SerializeField] private GameObject ballun;
    [SerializeField] private GameObject ballun2;

    private parcentageSc ptSc;
    private ParticleSystem[] particle;
    private ParticleSystem particle2;

    private GameObject obj;

  
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("percent");
        ptSc = obj.GetComponent<parcentageSc>();
        particle = new ParticleSystem[transform.childCount];
        for (int i = 0; i< particle.Length; i++) 
        particle[i] = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // Handheld.Vibrate();
            for (int i = 0; i < transform.childCount; i++)
                particle[i].Play();
           
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            
//            Destroy(gameObject);
        }
    }

   
}
