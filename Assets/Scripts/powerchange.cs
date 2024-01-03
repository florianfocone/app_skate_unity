using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerchange : MonoBehaviour
{
    // D�claration des variables publiques pour les objets UI
    public Slider mainSlider; // Slider principal
    private Text powertext; // Texte affichant la puissance
    public static int powerint = 1; // Valeur de puissance (statique pour �tre accessible de mani�re globale)

    public Slider sliderDessus; // Slider pour afficher la progression de la puissance
    int progressPower = 0; // Progression de la puissance

    // M�thode appel�e au d�marrage
    void Start()
    {
        // Ajoute un �couteur au slider principal et invoque une m�thode lorsque la valeur change
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        // Initialise la r�f�rence au composant Text
        powertext = GetComponent<Text>();
    }

    // M�thode invoqu�e lorsque la valeur du slider change
    public void ValueChangeCheck()
    {
        // Met � jour la valeur de puissance avec la valeur actuelle du slider
        powerint = (int)mainSlider.value;
        // Affiche la valeur de puissance dans le texte
        powertext.text = powerint.ToString();
    }

    // M�thode appel�e � chaque frame
    void Update()
    {
        // Obtient la progression de la puissance � partir d'une autre classe (vitessecalcul)
        progressPower = vitessecalcul.vitesseint;
        // Affiche la progression de la puissance dans le slider correspondant
        sliderDessus.value = progressPower;
        // Affiche la progression de la puissance dans la console � des fins de d�bogage
        Debug.Log(progressPower);
    }
}
