using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int power;
    // Use this for initialization
    float timeLastUpdate = 0f;
    void Start () {
        power = Random.Range(0, 1000);

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
            Entity enemy =col.gameObject.GetComponent<Entity>();
            if(enemy.power < this.power) {
                Destroy(col.gameObject);
            }
        }
    }
}
