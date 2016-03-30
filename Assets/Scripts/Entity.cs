using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0f);
       
    }
}
