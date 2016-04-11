using UnityEngine;
using System.Collections;

public class GameCreator : MonoBehaviour {

    public int entityCount = 100;
    public GameObject entity;
    public float verticalSize;
    public float horizontalSize;
    void Start()
    {
        verticalSize =Camera.main.orthographicSize * 2.0f;
        horizontalSize = verticalSize * Screen.width / Screen.height;
        for(int i = 0; i < entityCount; i++)
        {
            Instantiate(entity, new Vector3(Random.Range((horizontalSize / 2)*-1, (horizontalSize/2)), Random.Range(verticalSize / 2*-1, verticalSize/2), 0f), Quaternion.identity);            
        }
       // print ("Started");

    }
}
