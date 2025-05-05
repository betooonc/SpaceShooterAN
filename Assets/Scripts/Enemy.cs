using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);
    }

    IEnumerator Disparar() {
        while (true) {
            // Crear un disparo
            Instantiate(disparoPrefab, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);      
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro) {
        if (elOtro.CompareTag("DisparoJugador")) {
            Destroy(elOtro.gameObject);
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<Player>().AumentarScore();
        }
    }
}
