using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSwapper : MonoBehaviour {

    public Shader shader1;
    public Shader shader2;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Unlit/Color");
        shader2 = Shader.Find("Custom/Silhouette");
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            if (rend.material.shader == shader1)
                rend.material.shader = shader2;
            else
                rend.material.shader = shader1;

    }
}
