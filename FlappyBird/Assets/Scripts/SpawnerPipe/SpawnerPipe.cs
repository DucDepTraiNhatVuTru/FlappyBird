using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour {

    [SerializeField]
    private GameObject pipeHolder;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawner());
	}
	
	IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2.0f, 2.0f);
        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
}
