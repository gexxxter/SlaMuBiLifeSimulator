using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour
{


    public Text countgameObjects;
    float timeLastUpdate = 0f;

    public Text countText;
    public Text winText;
    public Text HPText;
    public Text LPText;
    public Text EText;


    void Start()
    {

    }

    public GameObject[] evos;

    void Update()
    {



        timeLastUpdate += Time.deltaTime;
        GameObject lowPowerEntity = null;
        if (timeLastUpdate >= 0.1f)
        {
            int highPower = 0;
            int lowPower = 1000;
            evos = GameObject.FindGameObjectsWithTag("Entity");
            foreach (GameObject checkEntity in evos)
            {

                int checkPower = checkEntity.GetComponent<Entity>().power;

                if (checkPower > highPower)
                {
                    highPower = checkPower;

                }
                if (checkPower < lowPower)
                {
                    lowPower = checkPower;
                    lowPowerEntity = checkEntity;
                }
            }

            countText.text = "Entities:         H. Power:          L. Power:    ";
            HPText.text = "" + highPower;
            LPText.text = "" + lowPower;
            EText.text = "" + evos.Length;


            Minicam miniCam = GameObject.FindGameObjectWithTag("miniCam").GetComponent<Minicam>();
            miniCam.entity = lowPowerEntity;

            winText.text = "SlaMuBi Life Simulator";

            timeLastUpdate = 0f;


        }


    }
}