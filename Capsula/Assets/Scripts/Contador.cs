using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textoTiempo;

    public GameObject conjuntoCapsula;
    public Slider barraTiempo;
    float tiempoPartida;
    float tiempoMaximo = 30f;
    float tiempoMinimo = 10f;
    bool tiempoActivo = false;

    public void Start()
    {
        tiempoPartida = Random.Range(tiempoMinimo, tiempoMaximo);
        barraTiempo.maxValue = tiempoPartida;
        tiempoActivo = true;
    }

    public void Update()
    {
        float segundos = Mathf.FloorToInt(tiempoPartida % 60);
        if (tiempoActivo == true)
        {
            if (tiempoPartida > 0)
            {
                tiempoPartida -= Time.deltaTime;
                barraTiempo.value = tiempoPartida;
            }
            if (tiempoPartida <= 0)
            {
                tiempoPartida = 0;
                gameObject.SetActive(false);
            }
        }
        textoTiempo.text = segundos.ToString();
    }
}