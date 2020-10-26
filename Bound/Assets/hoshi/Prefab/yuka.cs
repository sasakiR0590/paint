using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuka : MonoBehaviour
{
    [SerializeField] private ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!gameObject.CompareTag("sibu"))
        {
            var hoge = Instantiate(part, other.transform.position, Quaternion.identity);
            hoge.tag = "sibu";
        }
    }
}
