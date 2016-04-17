using UnityEngine;
using System.Collections;

public class hardpoints : MonoBehaviour {

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
    float timeLastUpdate = 0f;
    public Sprite bullseye;

    private int spriteIndex;
    private int spriteIndex_skins;
    private int spriteIndex_eyes;

    private Sprite[] spriteArray;
    private Sprite[] spriteArray_skins;
    private Sprite[] spriteArray_eyes;

    // Use this for initialization
    void Start() {

        
        
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
        


    }
    void skins ()
    {
        spriteArray_skins = Resources.LoadAll<Sprite>("Sprites/skins");

        int lengthOfSprites_skins = spriteArray_skins.Length;
        int rndspriteArray_skins = UnityEngine.Random.Range(0, lengthOfSprites_skins);

        this.gameObject.transform.GetChild(8).GetComponent<SpriteRenderer>().sprite = spriteArray_skins[rndspriteArray_skins];

    }


    void eyes ()
    {
        Transform[] eyes = { slot_eye_top, slot_eye_right, slot_eye_bot, slot_eye_left };
        
         int rndeye = UnityEngine.Random.Range(9,12);
         int rndeye2 = UnityEngine.Random.Range(9, 12);

        

        spriteArray_eyes = Resources.LoadAll<Sprite>("Sprites/eyes");

        int lengthOfSprites_eyes = spriteArray_eyes.Length;
        int rndspriteArray_eyes = UnityEngine.Random.Range(0, lengthOfSprites_eyes);

        this.gameObject.transform.GetChild(rndeye).GetComponent<SpriteRenderer>().sprite = spriteArray_eyes[rndspriteArray_eyes];
        this.gameObject.transform.GetChild(rndeye2).GetComponent<SpriteRenderer>().sprite = spriteArray_eyes[rndspriteArray_eyes];

    }

    void bodyparts()
    {
        Transform[] slots = { slot_top, slot_top_right, slot_right, slot_bot_right, slot_bot, slot_bot_left, slot_left, slot_top_left };

        int lengthOfslots = slots.Length;
        int rndslot = UnityEngine.Random.Range(0, lengthOfslots);

       // color(rndslot);
        if (this.gameObject.transform.GetChild(rndslot).GetComponent<SpriteRenderer>().sprite = currentSprite)
        {
            addBodyPart1(rndslot);
        }
        else
        {
            addBodyPart2(rndslot);
        }

    }

    void Awake()
    {
        // load all frames in fruitsSprites array
        blaeye = Resources.LoadAll<Sprite>("");
        spriteArray = Resources.LoadAll<Sprite>("Sprites/tooth");
    }
    void color(int colorizer) // diferent sprite color
    {
        Color[] colors = { Color.green, Color.red, Color.white, Color.blue, Color.yellow, Color.grey, Color.magenta, Color.cyan };

        int lengthOfColors = colors.Length; 
        int rndColor = UnityEngine.Random.Range(0, lengthOfColors);

        this.gameObject.transform.GetChild(colorizer).GetComponent<Renderer>().material.color = colors[rndColor];
       
    }
    void addBodyPart1(int newPart) // diferent sprite color
    {
        int lengthOfSprites = spriteArray.Length;
        int rndspriteArray = UnityEngine.Random.Range(0, lengthOfSprites);

        this.gameObject.transform.GetChild(newPart).GetComponent<SpriteRenderer>().sprite = spriteArray[rndspriteArray];
    }
    void addBodyPart2(int newPart) // diferent sprite color
    {
        int lengthOfSprites = spriteArray.Length;
        int rndspriteArray = UnityEngine.Random.Range(0, lengthOfSprites);

        this.gameObject.transform.GetChild(newPart).GetComponent<SpriteRenderer>().sprite = spriteArray[rndspriteArray];
    }
}

//gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("blaeye", typeof(Sprite)) as Sprite;