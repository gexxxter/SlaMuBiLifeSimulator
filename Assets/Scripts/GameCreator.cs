using UnityEngine;
using System.Collections;

public class GameCreator : MonoBehaviour {

    public int entityCount = 100;
    public GameObject entity;
    void Start()
    {
        for(int i = 0; i < entityCount; i++)
        {
            Instantiate(entity, new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0f), Quaternion.identity);            
        }
        print ("Started");

    }
}
