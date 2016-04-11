using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{

    public float power;
    public float feedPower;
    public int generation = 0;
    // Use this for initialization
    float timeLastUpdate = 0f;
    public float timeLastBreed = 0f;

    public float basedecay;
    public float speed;
    public float powerdecay;
    public float sizedecay;
    public float minPowertoClone;
    public int DNA;


    void Start()
    {
        if (power != 0f)
        {
            return;
        }
        power = Random.Range(0, 1000);
        feedPower = 100;
        speed = Random.Range(0.05f, 1f);
        basedecay = 10; // base power decay happens for every entity per frame
        sizedecay = 10; //needs to be definded
        minPowertoClone = 500; // needs to be definded
        powerdecay = power / 100 * speed + basedecay + sizedecay; // speficic powerdecay per frame of this entity

        DNA = Random.Range(1, 100000);

        color();

    }

    // Update is called once per frame
    void Update()
    {
        timeLastUpdate += Time.deltaTime;
        if (timeLastUpdate >= speed)
        {
            if (this.power > 0)
            {
                transform.position += new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f);
                timeLastUpdate = 0f;
                this.power = this.power - powerdecay;
            };

            if (this.power < 1)
            {
                this.power = 0;
            };
            if (this.power > 1000)
            {
                if (transform.localScale.x < 10)
                {

                    transform.localScale += new Vector3(0.01F, 0.01f, 0);
                    timeLastUpdate = 0f;
                    this.speed = this.speed + 0.01f;
                    powerdecay += +0.10f;
                };
            };
            if (this.power < 300)
            {
                if (transform.localScale.x > 0.5)
                {
                    transform.localScale += new Vector3(-0.01F, -0.01f, 0);
                    timeLastUpdate = 0f;
                    if (this.speed > 0)
                    {
                        this.speed += -0.05f;
                    }
                    if (this.powerdecay > 0)
                        this.powerdecay += -0.1f;
                }
            };


            RaycastHit hit = new RaycastHit(); //checks for entities below and starts to suck power from them if conditions are met
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                var distanceToGround = hit.distance;
                if (distanceToGround > 0 && generation < 100 && power < 700 )

                {
                    // feed(hit);
                }
            }

        }
        timeLastBreed += Time.deltaTime;

        if (timeLastBreed > 5.02f && this.power > minPowertoClone) //breeding condition based on minimum requierd power and passed time
        {
            GameObject newEntity = clone(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
           // newEntity.GetComponent<Entity>().power = this.power / 2; // cloned entity gets half power of the motherentity
            this.power = this.power * 6 / 10; // clone cost for motherentity is 20% of power
            timeLastBreed = 0f;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Entity" && (col.gameObject.GetComponent<Entity>().DNA < this.DNA || col.gameObject.GetComponent<Entity>().DNA > this.DNA))
        {
            Entity enemy = col.gameObject.GetComponent<Entity>();
            if (enemy.power < this.power)
            {
                this.power += enemy.power;
                Destroy(col.gameObject);

            }
        }
    }

    void feed(RaycastHit rayhit) // feeds power from the ground if its on groundcell grid
    {
        if (rayhit.transform.gameObject.tag == "Ground" && rayhit.transform.gameObject.GetComponent<Entity>().power > 0)
        {
            this.power += feedPower;
            rayhit.transform.gameObject.GetComponent<Entity>().power += -feedPower;
              Destroy (rayhit.transform.gameObject);

        }
    }

    void color() // diferent sprite color
    {
        Color[] colors = { Color.green, Color.red, Color.white, Color.blue, Color.yellow, Color.grey, Color.magenta, Color.cyan  };

        int lengthOfColors = colors.Length;  //Isn't this is better name than thename?
        int rndColor = UnityEngine.Random.Range(0, lengthOfColors);

        gameObject.GetComponent<Renderer>().material.color = colors[rndColor];
    }

    private GameObject clone(Vector3 position)
    {
        GameObject newEntity = (GameObject)Instantiate(this.gameObject, position, Quaternion.identity);
        newEntity.GetComponent<Entity>().power = this.power/2;
        newEntity.GetComponent<Entity>().generation = this.generation + 1;
        newEntity.GetComponent<Entity>().speed = this.speed;
        newEntity.GetComponent<Entity>().timeLastBreed = 0;
        newEntity.GetComponent<Entity>().powerdecay = this.powerdecay;

        Color newColor = gameObject.GetComponent<Renderer>().material.color;
        newColor.g += (1f / 500f) * generation;
        newEntity.GetComponent<Renderer>().material.color = newColor;


        return newEntity;
    }
}
