using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    // Use this for initialization
    float timeLastUpdate = 0f;
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timeLastUpdate += Time.deltaTime;
        if(timeLastUpdate >= 0.033f)
        {
            transform.position += new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0f);
            timeLastUpdate = 0f;
        }
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag == "Entity")
        {
            Destroy(col.gameObject);
        }
    }
}
