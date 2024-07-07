using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class powerchange : MonoBehaviour
{
    // Déclaration des variables publiques pour les objets UI
    public Slider mainSlider; // Slider principal
    private Text powertext; // Texte affichant la puissance
    public static int powerint = 1; // Valeur de puissance (statique pour être accessible de manière globale)
    public TMP_InputField minValueInputField;

    public Slider sliderDessus; // Slider pour afficher la progression de la puissance
    int progressPower = 0; // Progression de la puissance

    // Méthode appelée au démarrage
    void Start()
    {
        // Ajoute un écouteur au slider principal et invoque une méthode lorsque la valeur change
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        // Initialise la référence au composant Text
        powertext = GetComponent<Text>();

        // Initialiser le champ de texte avec la valeur minimale actuelle du slider
        minValueInputField.text = mainSlider.minValue.ToString();

        // Ajouter un listener pour détecter les changements dans l'Input Field
        minValueInputField.onEndEdit.AddListener(OnMinValueChanged);
    }

    // Méthode invoquée lorsque la valeur du slider change
    public void ValueChangeCheck()
    {
        // Met à jour la valeur de puissance avec la valeur actuelle du slider
        powerint = (int)mainSlider.value;
        // Affiche la valeur de puissance dans le texte
        powertext.text = powerint.ToString();
    }

    void OnMinValueChanged(string input)
    {
        float newMinValue;
        if (float.TryParse(input, out newMinValue))
        {
            // Changer la valeur minimale du slider
            mainSlider.minValue = newMinValue;

            // S'assurer que la valeur actuelle du slider n'est pas inférieure à la nouvelle valeur minimale
            if (mainSlider.value < newMinValue)
            {
                mainSlider.value = newMinValue;
            }
        }
        else
        {
            // En cas de saisie incorrecte, réinitialiser le champ de texte avec la valeur minimale actuelle
            minValueInputField.text = mainSlider.minValue.ToString();
        }
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Obtient la progression de la puissance à partir d'une autre classe (vitessecalcul)
        progressPower = vitessecalcul.vitesseint;
        // Affiche la progression de la puissance dans le slider correspondant
        sliderDessus.value = progressPower;
        // Affiche la progression de la puissance dans la console à des fins de débogage
       //  Debug.Log(progressPower);
    }
}
