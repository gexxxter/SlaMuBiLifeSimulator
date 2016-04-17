using UnityEngine;
using System.Collections;

public class Minicam : MonoBehaviour
{
    public float xEntity = 0;
    public float yEntity = 0;
    public float zEntity = 0;
    public GameObject entity = null;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (null == entity)
        {
            return;
        }

        //Set Camera to entity
        xEntity = entity.transform.position.x;
        yEntity = entity.transform.position.y;
        zEntity = gameObject.transform.position.z;
        transform.position = new Vector3(xEntity, yEntity, zEntity);
    }
}
