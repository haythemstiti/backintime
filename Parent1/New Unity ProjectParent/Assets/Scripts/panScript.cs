     using UnityEngine;
     using System.Collections;
     
     public class panScript : MonoBehaviour {
         public float speed = 0.1F;
         void Update()
         {

             if (transform.position.x <= 44f && transform.position.x >= 18f && transform.position.z <=44f && transform.position.z >= 13f)
             {
                 if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                 {
                     Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                     transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
                 }
                 transform.Translate(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
             }
             if (transform.position.x >= 44f)
             {
                 transform.Translate(new Vector3(-0.10f, 0f, 0f));
             }
             else if (transform.position.x <= 18)
             {
                 transform.Translate(new Vector3(0.1f, 0f, 0f));
             }
             else if (transform.position.z >= 44f)
             {
                 transform.Translate(new Vector3(0f, -0.1f, 0f));
             }
             else if (transform.position.z <= 13f)
             {
                 transform.Translate(new Vector3(0f, 0.1f, 0f));
             }
         }
     }

