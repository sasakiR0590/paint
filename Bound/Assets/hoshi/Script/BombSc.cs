using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSc : MonoBehaviour
{
    GameObject Liquid;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
      
        Instantiate(Liquid);
    }
}
