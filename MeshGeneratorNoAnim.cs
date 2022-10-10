using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter))]
public class MeshGeneratorNoAnim : MonoBehaviour
{
    public Slider numerodePasos;
    public Slider tamXSlider;
    public Slider tamZSlider;
    private Mesh mesh;
    private Vector3[] vertices;
    public int pasos = 2;
    public static int tamX = 10;
    public static int tamZ = 10;
    public int xSize;
    public int zSize;
    Vector2[] uv = new Vector2[4];
    private int[] triangles;
    // Start is called before the first frame update
    void Start()
    {

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //createShape();
        //updateMesh();

    }
    private void Update() 
    {
        if(Input.GetKeyDown("space")){
            //print("presionado");
            createShape();
            updateMesh();
        }
    }


    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
    void createShape()
    {
        xSize = tamX*pasos;
        zSize = tamZ*pasos;

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        print(vertices.Length);
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 2f;
                vertices[i] = new Vector3((float)((double)x/pasos), 0, (float)((double)z/pasos));
                print((float)((double)x/pasos));
                i++;
                //rint(i);
            }
        }
        //print(vertices.Length);
        int vert = 0;
        int tris = 0;
        triangles = new int[xSize * zSize * 6];
        for (int z=0;z<zSize;z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
                
            }

            vert++;
        }
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i],0.1f);
        }
    }
    public void SliderPasos(){
        pasos =(int) numerodePasos.value;
    }
    public void SliderX(){
        tamX =(int) tamXSlider.value;
    }
    public void SliderZ(){
        tamZ = (int) tamZSlider.value;
    }
}
