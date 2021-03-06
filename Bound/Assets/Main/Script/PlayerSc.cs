﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public struct mVector
{
    public Vector3 pos;
    public bool flag;
}

public class PlayerSc : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 mouseDirection;
    private Rigidbody rb;
    Vector3 explosion = Vector3.zero;//バンパーの跳ね返しの値

    private Vector3 force;

    Vector3 startPos; //タップした場所を記録
    Vector3 endPos;　//指を離した場所を記録
    float dir = 0;
    float time = 0;
    float speed = 0;

    //  private Vector3 screenPoint;
    //private Vector3 offset;
    //private int floarX,floarY;

    //public GameObject splash;
    //public GameObject obj;
    //nizigennSc script;

    private ParticleSystem particle;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
       rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
      //rb.useGravity = false;

      //   script = obj.GetComponent<nizigennSc>();
         particle = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

        //floarX = 60 / 18;
        //floarY = 100 / 30;
        particle.Stop();
    }

   
    // Update is called once per frame
    void Update()
    {
            mouseDirection = (Input.mousePosition - this.screenPoint);
            mouseDirection.z = mouseDirection.y;
            mouseDirection.y = 0;
            mouseDirection = mouseDirection.normalized;
           
            if (Input.GetMouseButtonDown(0))
            {
                this.screenPoint = Input.mousePosition;
                this.startPos = Input.mousePosition;
                this.time = 0;
            }

            //スワイプ中の時間を取得する
            if (Input.GetMouseButton(0))
            {
                this.time += Time.deltaTime;
            }

            if (Input.GetMouseButtonUp(0))
            {
                force = new Vector3(mouseDirection.x, mouseDirection.y, mouseDirection.z);
               

                this.endPos = Input.mousePosition;
                endPos.z = 0;

                //スワイプした距離を取得する
                this.dir = Mathf.Abs(Vector3.Distance(this.startPos, this.endPos));

                //速度を計算する
                this.speed = (this.dir / this.time);

                
                if(speed > 2000)
                    speed = 2000;

                //rb.AddForce(force);  // 力を加える
                rb.AddForce(new Vector3(mouseDirection.x * speed , 0, mouseDirection.z * speed ));
            }

        //int idx = (int)(pos.x * 18.0f / 60.0f);
        //int idy = (int)(pos.z * 30.0f / 100.0f);
        //script.data2d[idy, idx] = true;
    }   

    private void OnCollisionEnter(Collision collision)
    {
        //バンパーの動作
        if (collision.gameObject.CompareTag("Bumper"))
        {
            //exprosion = collision.gameObject.transform.forward;
            //Rgd.AddForce(-exprosion * 10);
            //バンパーが当たった方向
            explosion = collision.gameObject.transform.position - transform.position;
            explosion.y = 0;
            //バンパーの跳ね返し
            rb.AddForce(explosion.normalized  * 100,ForceMode.Impulse);
        }

        //if(collision.gameObject.CompareTag("Floar"))

        //Instantiate(splash, gameObject.transform.position-new Vector3(0,1.3f,0), Quaternion.identity);
       
        particle.Play();
       
    }

    
    

}
