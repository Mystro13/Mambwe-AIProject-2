using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{

    public Color myColor;
    MeshRenderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
