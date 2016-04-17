using UnityEngine;
using System.Collections;

public class FieldCreator : MonoBehaviour
{
    public float power = 2000;
    public int GroundSideLenght = 100; // field length
    public GameObject GroundCell;
    public float yPos = 0;
    public float xPos = 0;
    public float xscale;
    public float yscale;
    public float xMultiplier = 1;
    public float yMultiplier = 1;
    public float hvMultiplier = 1;
    public float cellCounter;
    void Start()
    {
        

        yPos = 0;
        xPos = 0;
        yscale = this.transform.localScale.y;
        xscale = this.transform.localScale.x;
        xMultiplier = 1;
        yMultiplier = 1;
        hvMultiplier = 1;
        cellCounter = 0;

        //   verticalSize = Camera.main.orthographicSize * 2.0f;
        //   horizontalSize = verticalSize * Screen.width / Screen.height;

        for (int i = 0; i < GroundSideLenght * GroundSideLenght; ++i)
        {
            Instantiate(GroundCell, new Vector3(xPos * xMultiplier, yPos * yMultiplier, 1f), Quaternion.identity);
            yPos += yscale * hvMultiplier;
            cellCounter += 1;

            if (yPos == (GroundSideLenght / 2) * hvMultiplier)
            {
                yPos = 0;
                xPos += xscale * hvMultiplier;

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
