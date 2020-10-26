using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BallSC : MonoBehaviour
{

    private Rigidbody Rgd;
    Vector3 force = Vector3.zero;
    Vector3 explosion = Vector3.zero;
    Vector3 Bumper = Vector3.zero;
    public float a = 1f;
    [SerializeField]private  int speed;
    // Start is called before the first frame update
    void Start()
    {
        Rgd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rgd.AddForce(0, 1 * a, 1 * a, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Rgd.AddForce(0, 1 * a, -1 * a, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rgd.AddForce(1 * a, 1 * a, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rgd.AddForce(-1 * a, 1 * a, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            //exprosion = collision.gameObject.transform.forward;
            //Rgd.AddForce(-exprosion * 10);
            explosion = collision.gameObject.transform.position - transform.position;
            explosion.y = 0;
            Rgd.AddForce(explosion.normalized * speed * 1000);
        }

        
    }
}
