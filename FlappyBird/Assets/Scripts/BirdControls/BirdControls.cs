using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControls : MonoBehaviour {

    public static BirdControls instance;
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip ping, fly, die;

    private bool isAlive;
    private bool didFlap;

    private GameObject spawner; 

    public float flag = 0;
    public int score = 0;

	// Use this for initialization
	void Awake () {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MakeInstance();
        spawner = GameObject.Find("SpawnerPipe");
	}

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        _BirdMovement();
	}

    void _BirdMovement()
    {
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(fly);
            }
        }

        if (myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void FlapButton()
    {
        didFlap = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            audioSource.PlayOneShot(ping);
            if (GamePlayControls.instance!= null)
            {
                GamePlayControls.instance._SetScore(score);
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(die);
                animator.SetTrigger("Die");
            }
            if (GamePlayControls.instance != null)
            {
                GamePlayControls.instance._BirdDieShowPanel(score);
            }
        }
    }
}
