using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] private float velocidad;
    [SerializeField] private Vector3 direccion; 
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}
