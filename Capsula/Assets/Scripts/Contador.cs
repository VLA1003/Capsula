using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textoTiempo;

    public GameObject conjuntoCapsula, conjuntoHud, capsulaIndividual;
    public Slider barraTiempo;
    Vector3 escalaCapsula;
    float tiempoPartida;
    float tiempoMaximo = 30f;
    float tiempoMinimo = 10f;
    bool tiempoActivo = false;
    bool capsulaDestruida = false;

    public void Start()
    {
        //tiempoPartida = Random.Range(tiempoMinimo, tiempoMaximo);
        // Tiempo de 2 segundos para pruebas.
        tiempoPartida = 2;
        barraTiempo.maxValue = tiempoPartida;
        tiempoActivo = true;
    }

    public void Update()
    {
        float segundos = Mathf.FloorToInt(tiempoPartida % 60);
        textoTiempo.text = segundos.ToString();
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
                Destroy(conjuntoHud);
                LeanTween.scale(capsulaIndividual, escalaCapsula * 0.5f, 0.8f).setOnComplete(DestruirConjuntoCapsula);
            }
        }
    }

    public void DestruirConjuntoCapsula()
    {
        Object.Destroy(capsulaIndividual);
        Component.Destroy(GetComponent<Contador>());
        capsulaDestruida = true;
        if (capsulaDestruida == true)
        {
            
        }
    }
}