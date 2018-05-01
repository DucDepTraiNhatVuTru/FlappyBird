using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (BirdControls.instance != null)
        {
            if (BirdControls.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        _PipeMovement();
	}

    void _PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
