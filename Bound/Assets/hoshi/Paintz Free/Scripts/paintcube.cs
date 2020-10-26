using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ParticlePainter1 : MonoBehaviour
{
    public Brush brush;
    public bool RandomChannel = false;

    
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PaintTarget paintTarget = collision.gameObject.GetComponent<PaintTarget>();
        if (paintTarget != null)
        {
            if (RandomChannel) 
                brush.splatChannel = Random.Range(0, 2);

            foreach (ContactPoint contact in collision.contacts)
            {
                PaintTarget.PaintObject(paintTarget, contact.point, contact.normal, brush);
            }
            
        }
    }

    //private void OnCollisionEnter(Colision r)
    //{
    //    PaintTarget paintTarget = other.GetComponent<PaintTarget>();
    //    if (paintTarget != null)
    //    {
    //        if (RandomChannel) brush.splatChannel = Random.Range(0, 2);

    //        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
    //        for (int i = 0; i < numCollisionEvents; i++)
    //        {
    //            PaintTarget.PaintObject(paintTarget, collisionEvents[i].intersection, collisionEvents[i].normal, brush);
    //        }
    //    }
    //}


}