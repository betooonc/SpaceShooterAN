using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TextMeshProUGUI textoOleadas;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private GameObject powerUpGunsPrefab;
    private bool flag = false;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator SpawnEnemy() {
        for (int i = 0; i < 5; i++) { // Niveles
            for (int j = 0; j < 2; j++) { // Oleadas
                textoOleadas.text = "Nivel " + (i+1) + " - Oleada " + (j+1);
                yield return new WaitForSeconds(3f);
                textoOleadas.text = "";
                for (int k = 0; k < 5; k++) { // Enemigos
                    Vector3 puntoAleatorio = new Vector3(transform.position.x, Random.Range(-4.48f, 4.48f), 0);
                    Instantiate(enemyPrefab, puntoAleatorio, Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);   
                }
                if (flag){
                    flag = false;
                    Vector3 puntoAleatorioPowerUp = new Vector3(transform.position.x, Random.Range(-4.48f, 4.48f), 0);
                    Instantiate(powerUpPrefab, puntoAleatorioPowerUp, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                } else {
                    Vector3 puntoAleatorioPowerUpGuns = new Vector3(transform.position.x, Random.Range(-4.48f, 4.48f), 0);
                    Instantiate(powerUpGunsPrefab, puntoAleatorioPowerUpGuns, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
                    flag = true;
                }   
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
