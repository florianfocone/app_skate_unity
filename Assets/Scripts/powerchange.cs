using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerchange : MonoBehaviour
{
    // Déclaration des variables publiques pour les objets UI
    public Slider mainSlider; // Slider principal
    private Text powertext; // Texte affichant la puissance
    public static int powerint = 1; // Valeur de puissance (statique pour être accessible de manière globale)

    public Slider sliderDessus; // Slider pour afficher la progression de la puissance
    int progressPower = 0; // Progression de la puissance

    // Méthode appelée au démarrage
    void Start()
    {
        // Ajoute un écouteur au slider principal et invoque une méthode lorsque la valeur change
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        // Initialise la référence au composant Text
        powertext = GetComponent<Text>();
    }

    // Méthode invoquée lorsque la valeur du slider change
    public void ValueChangeCheck()
    {
        // Met à jour la valeur de puissance avec la valeur actuelle du slider
        powerint = (int)mainSlider.value;
        // Affiche la valeur de puissance dans le texte
        powertext.text = powerint.ToString();
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Obtient la progression de la puissance à partir d'une autre classe (vitessecalcul)
        progressPower = vitessecalcul.vitesseint;
        // Affiche la progression de la puissance dans le slider correspondant
        sliderDessus.value = progressPower;
        // Affiche la progression de la puissance dans la console à des fins de débogage
        Debug.Log(progressPower);
    }
}
