using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public Text skiptext; // Texte affichant le compte à rebours
    public float chrono = 10.0f; // Durée du compte à rebours en secondes

    // Méthode appelée au démarrage
    void Start()
    {
        // Chargement de la scène avec l'index 0 (peut être décommenté si nécessaire)
        // SceneManager.LoadScene(0);
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Décrémente le compte à rebours en fonction du temps écoulé depuis la dernière frame
        chrono -= Time.deltaTime;

        // Met à jour le texte affichant le compte à rebours
        skiptext.text = (Mathf.Round(chrono * 10f) / 10f).ToString();

        // Si le compte à rebours atteint zéro, charge la scène "1"
        if (chrono < 0.0f)
        {
            SceneManager.LoadScene("1");
        }
    }

    // Méthode appelée lorsqu'un bouton "skip" est pressé
    public void skipvoid()
    {
        // Charge la scène "1"
        SceneManager.LoadScene("1");
    }
}

