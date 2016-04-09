using UnityEngine;
using System.Collections;

public class FieldCreator : MonoBehaviour
{

    public int GroundSideLenght = 100; // field length
    public GameObject GroundCell;
    public float yPos;
    public float xPos;
    public float xMultiplier;
    public float yMultiplier;
    public float hvMultiplier;
    public float hCounter;
    public float vCounter;
    public float cellCounter;
    void Start()
    {
        yPos = 0;
        xPos = 0;
        xMultiplier = 1;
        yMultiplier = 1;
        hvMultiplier = 1;
        cellCounter = 0;

        //   verticalSize = Camera.main.orthographicSize * 2.0f;
        //   horizontalSize = verticalSize * Screen.width / Screen.height;

        for (int i = 0; i < GroundSideLenght * GroundSideLenght; ++i)
        {
            Instantiate(GroundCell, new Vector3(xPos * xMultiplier, yPos * yMultiplier, 1f), Quaternion.identity);
            yPos += 1 * hvMultiplier;
            cellCounter += 1;

            if (yPos == (GroundSideLenght / 2) * hvMultiplier)
            {
                yPos = 0;
                xPos += 1 * hvMultiplier;

            };

            if (xPos == (GroundSideLenght / 2) * hvMultiplier)
            {
                xPos = 0;
                yPos = 0;
            };

            if (cellCounter == GroundSideLenght * GroundSideLenght * 0.25)
            {
                hvMultiplier = 1;
                xMultiplier = 1;
                yMultiplier = -1;
            };

            if (cellCounter == GroundSideLenght * GroundSideLenght * 0.5)
            {
                hvMultiplier = 1;
                xMultiplier = -1;
                yMultiplier = -1;
            };

            if (cellCounter == GroundSideLenght * GroundSideLenght * 0.75)
            {
                hvMultiplier = 1;
                xMultiplier = -1;
                yMultiplier = 1;
            }




        }
        

    }
}
