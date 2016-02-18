using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour {

    public static float x, y, z;
    private bool right, left, up, down;
	void Start () {
	
	}
	
	

	void Update () {

        if (right && transform.position.x <= 47.7927f)
        { 
            transform.Translate(new Vector3(0.2f, 0f, 0f));
        }
        if (left && transform.position.x >= 18.84581f)
        {
            transform.Translate(new Vector3(-0.2f, 0f, 0f));
        }
        if (up && transform.position.z <= 48.48763f)
        
            transform.Translate(new Vector3(0f, 0.2f, 0f));

        if (down && transform.position.z >= 6.79967f)
        {
            transform.Translate(new Vector3(0f, -0.2f, 0f));
        }
        
            if (transform.position.x >= 47.7927f)
            {
                transform.Translate(new Vector3(-0.01f, 0f, 0f));
            }
            else if (transform.position.x <= 18.84581f)
            {
                transform.Translate(new Vector3(0.01f, 0f, 0f));
            }
            else if (transform.position.z >= 48.48763f)
            {
                transform.Translate(new Vector3(0f, -0.01f, 0f));
            }
            else if (transform.position.z <= 6.79967f)
            {
                transform.Translate(new Vector3(0f, 0.01f, 0f));
            }
        
    }
        public void goRight(){
            right = true;
        }

        public void goLeft()
        {
            left = true;
        }
        public void goUp()
        {
            up = true;
        }

        public void goDown()
        {
            down = true;
            Debug.Log("Down");
        }


        public void UngoRight()
        {
            right = false;
        }

        public void UngoLeft()
        {
            left = false;
        }
        public void UngoUp()
        {
            up = false;
        }

        public void UngoDown()
        {
            down = false;
        }  

    void OnGUI()
    {
       // GUI.TextField(new Rect(200, 200, 200, 200), "x: " + x + "\n y: " + y + "\n z: " + z, 25);
    }
}
