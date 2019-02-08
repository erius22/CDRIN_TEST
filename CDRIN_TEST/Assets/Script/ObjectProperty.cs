using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperty : MonoBehaviour
{
    // besoin pour faire la box modifiable autour de l'objet
    public Bounds bounds { get { return m_Bounds; } set { m_Bounds = value; } }
    [SerializeField]
    private Bounds m_Bounds = new Bounds(Vector3.zero, Vector3.one);
    public Color colorBoundsBox = Color.green;



    //differentes proprietes
    public float prix;
    public string nom;
    public string description;
    public float resistance;
    public string autrePropriete; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
