using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolucionDropdown;

    Resolution[] resoluciones;

    void Start()
    {
        resoluciones = Screen.resolutions;

        resolucionDropdown.ClearOptions();

        List<string> opciones = new List<string>(); 

        int indiceResolucionActual = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                indiceResolucionActual = i;
            }
        }

        resolucionDropdown.AddOptions(opciones);
        resolucionDropdown.value = indiceResolucionActual;
        resolucionDropdown.RefreshShownValue();
    }

    public void FijarResolucion(int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    /// <summary>
    /// Método que llamamos cuando cambiamos el valor del volumen
    /// </summary>
    /// <param name="volumen"></param>
    public void FijarVolumen (float volumen)
    {
        // Cambiamos el parametro de volumen, aplicando el valor dado por el slider
        audioMixer.SetFloat("volumen", volumen);
    }

    /// <summary>
    /// Método que llamamos cuando cambiamos el parametro de calidad gráfica
    /// </summary>
    /// <param name="indiceCalidad"></param>
    public void FijarGraficos(int indiceCalidad)
    {
        // Llamamos a la función que se encarga de asignar la calidad grafica dependiendo de un indice
        QualitySettings.SetQualityLevel(indiceCalidad);
    }

    /// <summary>
    /// Método que llamamos cuando activamos/desctivamos el trigger de pantalla completa
    /// </summary>
    /// <param name="estaPantallaCompleta"></param>
    public void FijarPantallaCompleta(bool estaPantallaCompleta)
    {
        // Llamamos a la funcion que se encarga de la pantalla completa con un booleano
        Screen.fullScreen = estaPantallaCompleta;
    }
}
