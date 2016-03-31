using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour
{

    public float speed;
    public Text countgameObjects;
    float timeLastUpdate = 0f;
    public float timeLastBreed = 0f;
    private int count;
    public int HighPower;
    public int LowPower;
    public Text countText;
    public Text winText;
    public Text HPText;
    public Text LPText;
    public Text EText;

    void Start ()
    {
        HighPower = 0;
        LowPower = 0;
    }

    public GameObject[] evos;

    void Update()
    {
        evos = GameObject.FindGameObjectsWithTag("Entity");

        for (int i = 0; i < evos.Length; i++)
        {
            

            timeLastUpdate += Time.deltaTime;
            if (timeLastUpdate >= 5f)
            {
                foreach (GameObject checkEntity in evos)
                {
                
                    int CheckPower = checkEntity.GetComponent<Entity>().power;

                    if (CheckPower > HighPower)
                    {
                        HighPower = CheckPower;
                    }
                    if (CheckPower < LowPower)
                    {
                        LowPower = CheckPower;
                    }
                }
    
                    countText.text = "Entities:         H. Power:          L. Power:    ";
                HPText.text = "" + HighPower;
                LPText.text = "" + LowPower;
                EText.text = "" + i;

                winText.text = "SlaMuBi Life Simulator";

                //   print("Entities "+i+" highest power "+HighPower + " lowest power " + LowPower);
                timeLastUpdate = 0f;
                LowPower = 1000;
                HighPower = 0;
            }
        }
    }
}