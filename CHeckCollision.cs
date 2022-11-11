using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CHeckCollision : MonoBehaviour
{
    public GameObject puntoRef;
    public GameObject QuadBase;
    public GameObject QuadResortes;
    public GameObject[] Quads;
    private GameObject temporal,temporal2;
    private float x1, y1, z1 = 0f;
    private float magnitud = 20;

    private float x2, y2, z2 = 0f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        print("choco");
        if(other.gameObject.CompareTag("Piel")){ //&& this.GetComponentInChildren<TagField>().value!="base"){
            //Destroy(other.gameObject);
            //this.GetComponent<Rigidbody>().isKinematic = true;
            //print(this.transform.position);
            QuadBase = other.gameObject;
            x1 = this.transform.position.x;
            y1 = this.transform.position.y-0.98f;
            z1 = other.gameObject.transform.position.z;
            Instantiate(puntoRef, new Vector3(x1, y1, z1), Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        x2 = this.transform.position.x;
        y2 = this.transform.position.y-0.5f;
        z2 = other.gameObject.transform.position.z;
        Instantiate(puntoRef, new Vector3(x2, y2, z2), Quaternion.identity);
        dividirEnDos(other.gameObject.transform);
        //print(other.gameObject.transform.localScale);
    }

    private void dividirEnDos(Transform datos)
    {
        temporal = Instantiate(QuadResortes, datos.position, Quaternion.Euler(-90,0,0));
        var localScale = QuadBase.transform.localScale;
        var position = temporal.transform.position;
        
        temporal.transform.localScale = new Vector3(x1-(position.x-localScale.x/2),localScale.y,localScale.z);
        
        float posicionX = (x1-(position.x-localScale.x/2))/2+(position.x-localScale.x/2);
        //float posicionX = (2*x1-3*(position.x-localScale.x/2))/4; //intenté simplificar la operacion pero no me salio
        position = new Vector3(posicionX, position.y, position.z);
        temporal.transform.position = position;
        
        // Hacer el complemento
        temporal2 = Instantiate(QuadResortes, datos.position, Quaternion.Euler(-90,0,0));
        position = temporal2.transform.position;
        float x3 = position.x + localScale.x / 2;
        
        temporal2.transform.localScale = new Vector3((x3)-x1,localScale.y,localScale.z);
        
        posicionX = (x1 + (x3-x1)/2);
        position = new Vector3(posicionX, position.y, position.z);
        temporal2.transform.position = position;
        Destroy(QuadBase);
    }
}
