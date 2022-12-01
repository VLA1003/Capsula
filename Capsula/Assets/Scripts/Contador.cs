using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI contador;

    public GameObject conjuntoCapsula;
    public Slider barraTiempo;
    float tiempoPartida;
    bool tiempoActivo = false;

    public void Start()
    {
        // tiempoPartida = Random.Range(10f, 30f);
        tiempoPartida = 3;
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
            }
            if (tiempoPartida <= 0)
            {
                tiempoPartida = 0;
                conjuntoCapsula.SetActive(false);
            }

        }
        contador.text = segundos.ToString();
    }
}