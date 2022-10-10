using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarQuads : MonoBehaviour
{
    int x = 0;
    int y = 0;
    int z = 0;
    public Slider XSlider;
    public Slider YSlider;
    public Slider ZSlider;
    public float width = 1;
    public float height = 1;
    
    private void Start() {
        
        //CrearQuad(0,0,0);
    }
    private void Update() {
        if(Input.GetKeyDown("space")){
            CrearQuad(x,y,z);
        }
    }
   
    public void CrearQuad(int x,int y, int z)
    {
        //MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        //meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshCollider colision = gameObject.AddComponent<MeshCollider>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(x, y, z),
            new Vector3(width+x, y, z),
            new Vector3(x, height+y, z),
            new Vector3(width+x, height+y, z)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;
        colision.sharedMesh  = mesh;
    }
    public void SliderX(){
        x =(int) XSlider.value;
    }
    public void SliderY(){
        y =(int) YSlider.value;
    }
    public void SliderZ(){
        z =(int) ZSlider.value;
    }
}
