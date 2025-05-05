using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
    [SerializeField] private float velocidad;
    [SerializeField] private float ratioDisparo;
    [SerializeField] private GameObject disparoPrefab;
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private TextMeshProUGUI textoVidas;
    [SerializeField] private TextMeshProUGUI textoScore;
    private float temporizadorDisparo = 0.5f;
    private float vidas = 100;
    private float score = 0;
    public GameOverScreen gameOverScreen;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Movimiento();
        DelimitarMovimiento();
        Disparar();
    }

    private void Movimiento() {
        // mover la nave cuando se oprima el cursor
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(horizontal, vertical).normalized * velocidad * Time.deltaTime);        
    }

    private void DelimitarMovimiento() {
        // Limitar la nave a la pantalla
        float xClamper = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float yClamper = Mathf.Clamp(transform.position.y, -4.48f, 4.48f);
        transform.position = new Vector3(xClamper, yClamper, 0);
    }

    private void Disparar() {
        temporizadorDisparo += 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && temporizadorDisparo > ratioDisparo) {
            // Crear un disparo
            Instantiate(disparoPrefab, spawnPoint1.transform.position, Quaternion.identity);
            Instantiate(disparoPrefab, spawnPoint2.transform.position, Quaternion.identity);
            temporizadorDisparo = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro) {
        if (elOtro.CompareTag("DisparoEnemigo") || elOtro.CompareTag("Enemigo")) {
            vidas -= 10;
            textoVidas.text = "Vida: " + vidas;
            Destroy(elOtro.gameObject);
            if (vidas <= 0) {
                Destroy(gameObject);
                GameOver();
            }
        }
        if (elOtro.CompareTag("PowerUp")) {
            Destroy(elOtro.gameObject);
            vidas += 10;
            textoVidas.text = "Vida: " + vidas;
        }
        if (elOtro.CompareTag("PowerUpGuns")) {
            Destroy(elOtro.gameObject);
            ratioDisparo -= 0.1f;
            if (ratioDisparo == 0.1f) {
                ratioDisparo = 0.1f;
            }
        }
    }

    public void AumentarScore() {
        score += 10;
        textoScore.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverScreen.Setup((int)score);
        gameObject.SetActive(false);
    }
}
