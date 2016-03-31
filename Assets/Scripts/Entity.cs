using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    public int power;
    public int generation=0;
    // Use this for initialization
    float timeLastUpdate = 0f;
    public float timeLastBreed = 0f;


    void Start () {
        if(power != 0f)
        {
            return;
        }
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
        timeLastBreed += Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag == "Entity")
        {
            Entity enemy = col.gameObject.GetComponent<Entity>();
            if(enemy.power < this.power) {
                Destroy(col.gameObject);
                if(timeLastBreed > 0.02f)
                {
                    GameObject newEntity=clone(col.gameObject.transform.position);
                    newEntity.GetComponent<Entity>().power = power;
                    timeLastBreed = 0f;
                }
            }
        }
    }

    private GameObject clone(Vector3 position)
    {
        GameObject newEntity = (GameObject)Instantiate(this.gameObject, position, Quaternion.identity);
        newEntity.GetComponent<Entity>().power = this.power;
        newEntity.GetComponent<Entity>().generation = this.generation + 1;
        Color newColor = gameObject.GetComponent<Renderer>().material.color;
        newColor.g += (1f/500f)*generation;
        newEntity.GetComponent<Renderer>().material.color =newColor;
        

        return newEntity;
    }
}
