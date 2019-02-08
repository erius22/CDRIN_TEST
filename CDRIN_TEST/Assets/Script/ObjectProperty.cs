using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperty : MonoBehaviour
{

    public float price;
    public string objectName;
    public string description;
    public float resistance;

    [HideInInspector]
    public Vector3 rectOffset;
    [HideInInspector]
    public Vector3 rectSize;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position + rectOffset, this.transform.localScale + rectSize);
        Debug.Log("working ?");
    }
}
