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

    // every slot is a child object of the entity object, counted clockwise
    public Transform slot_top;
    public Transform slot_top_right;
    public Transform slot_right;
    public Transform slot_bot_right;
    public Transform slot_bot;
    public Transform slot_bot_left;
    public Transform slot_left;
    public Transform slot_top_left;
    public Transform slot_body;
    public Transform slot_eye_top;
    public Transform slot_eye_right;
    public Transform slot_eye_bot;
    public Transform slot_eye_left;

    public Sprite currentSprite;
    public Sprite currentSpritennn;
    public Sprite[] blaeye;
    public Sprite bullseye;

    private int spriteIndex;
    private int spriteIndex_skins;
    private int spriteIndex_eyes;

    private Sprite[] spriteArray;
    private Sprite[] spriteArray_skins;
    private Sprite[] spriteArray_eyes;


    void Start()
    {
        if (power != 0f)
        {
            return;
        }
        power = Random.Range(0, 1000);
        feedPower = 100;
        speed = Random.Range(0.05f, 3f);
        basedecay = 10; // base power decay happens for every entity per frame
        sizedecay = 10; //needs to be definded
        minPowertoClone = 500; // needs to be definded
        powerdecay = power / 100 * speed + basedecay + sizedecay; // speficic powerdecay per frame of this entity

        DNA = Random.Range(1, 100000);

        slot_top = this.gameObject.transform.GetChild(0);
        slot_top_right = this.gameObject.transform.GetChild(1);
        slot_right = this.gameObject.transform.GetChild(2);
        slot_bot_right = this.gameObject.transform.GetChild(3);
        slot_bot = this.gameObject.transform.GetChild(4);
        slot_bot_left = this.gameObject.transform.GetChild(5);
        slot_left = this.gameObject.transform.GetChild(6);
        slot_top_left = this.gameObject.transform.GetChild(7);
        slot_body = this.gameObject.transform.GetChild(8);

        slot_eye_top = this.gameObject.transform.GetChild(9);
        slot_eye_right = this.gameObject.transform.GetChild(10);
        slot_eye_bot = this.gameObject.transform.GetChild(11);
        slot_eye_left = this.gameObject.transform.GetChild(12);

        eyes();
        skins();

        for (float i = 0; i <= Random.Range(0f, 3f); ++i)
        {
            bodyparts();
        };


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
        float rndbreed = Random.Range(1f, 10f);

        if (timeLastBreed > rndbreed && this.power > minPowertoClone) //breeding condition based on minimum requierd power and passed time
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

    // gets all sprites from the folder Sprites/skins and adds one random to the body slot (child number 8)        
    void skins ()
    {
        spriteArray_skins = Resources.LoadAll<Sprite>("Sprites/skins");

        int lengthOfSprites_skins = spriteArray_skins.Length;
        int rndspriteArray_skins = UnityEngine.Random.Range(0, lengthOfSprites_skins);

        this.gameObject.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = spriteArray_skins[rndspriteArray_skins];

    }

    // gets random two eye slots (child number 9 to 12) and adds random an eyeskin from the folder Sprites/eyes 
    void eyes ()
    {
        
         int rndeye = UnityEngine.Random.Range(9,12);
         int rndeye2 = UnityEngine.Random.Range(9, 12);

        

        spriteArray_eyes = Resources.LoadAll<Sprite>("Sprites/eyes");

        int lengthOfSprites_eyes = spriteArray_eyes.Length;
        int rndspriteArray_eyes = UnityEngine.Random.Range(0, lengthOfSprites_eyes);

        this.gameObject.transform.GetChild(rndeye).GetComponent<SpriteRenderer>().sprite = spriteArray_eyes[rndspriteArray_eyes];
        this.gameObject.transform.GetChild(rndeye2).GetComponent<SpriteRenderer>().sprite = spriteArray_eyes[rndspriteArray_eyes];

    }

    // gets random body slot (number), adds a skin randomly from the folder Sprites/skins and colorize the same slot
    void bodyparts()
    {
        Transform[] slots = { slot_top, slot_top_right, slot_right, slot_bot_right, slot_bot, slot_bot_left, slot_left, slot_top_left };

        int lengthOfslots = slots.Length;
        int rndslot = UnityEngine.Random.Range(0, lengthOfslots);

        addBodyPart1(rndslot);
        color(rndslot);

    }

    void Awake()
    {
        // load all frames in fruitsSprites array
        blaeye = Resources.LoadAll<Sprite>("");
        spriteArray = Resources.LoadAll<Sprite>("Sprites/bodyparts");
    }


    //  adds random color to the passed child slot (number)
    void color(int colorizer) 
    {
        Color[] colors = { Color.green, Color.red, Color.white, Color.blue, Color.yellow, Color.grey, Color.magenta, Color.cyan };

        int lengthOfColors = colors.Length; 
        int rndColor = UnityEngine.Random.Range(0, lengthOfColors);

        this.gameObject.transform.GetChild(colorizer).GetComponent<Renderer>().material.color = colors[rndColor];
       
    }

    // adds random sprite to the passed child slot (number)
    void addBodyPart1(int newPart) 
    {
        int lengthOfSprites = spriteArray.Length;
        int randomSprite = UnityEngine.Random.Range(0, lengthOfSprites);

        this.gameObject.transform.GetChild(newPart).GetComponent<SpriteRenderer>().sprite = spriteArray[randomSprite];
    }



    private GameObject clone(Vector3 position)
    {
        GameObject newEntity = (GameObject)Instantiate(this.gameObject, position, Quaternion.identity);
        newEntity.GetComponent<Entity>().power = this.power/2;
        newEntity.GetComponent<Entity>().generation = this.generation + 1;
        newEntity.GetComponent<Entity>().speed = this.speed;
        newEntity.GetComponent<Entity>().timeLastBreed = 0;
        newEntity.GetComponent<Entity>().powerdecay = this.powerdecay;

        //  Color newColor = gameObject.GetComponent<Renderer>().material.color;
        //  newColor.g += (1f / 500f) * generation;
        // newEntity.GetComponent<Renderer>().material.color = newColor;


      //  slot = this.gameObject.transform;

        
     //   for (int i = 0; i <= 12; ++i)
     //   {
     //       newEntity.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = this.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
      //  }

        return newEntity;
    }
}
