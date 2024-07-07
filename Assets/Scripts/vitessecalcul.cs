using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class vitessecalcul : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Text vit; // Référence au composant Text représentant la vitesse
    public static int vitesseint = 0; // Valeur de la vitesse (statique pour être accessible de manière globale)
    public static string vitesse = "0"; // Chaîne de caractères représentant la vitesse (statique pour être accessible de manière globale)
    private float timeLeft = 0.0025f; // Temps restant pour l'incrémentation/decrémentation de la vitesse

    private bool isPressed; // Indique si le bouton est enfoncé

    // Références aux boutons et au slider dans l'interface utilisateur
    public Button deconnect, connectb, quiter, devicesB;
    public Slider powercontrol;

    // Méthode appelée au démarrage
    void Start()
    {
       
        vit = GameObject.Find("vitesse").GetComponent<Text>(); // Trouve le composant Text par son nom
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Si le bouton est enfoncé
        if (isPressed)
        {
            // Logique pour ajuster la vitesse en fonction de la puissance
            if (powerchange.powerint == 0)
            {
                vitesseint = 0;
            }
            else if (powerchange.powerint <= powercontrol.minValue)
            {
                vitesseint = 0;
            }
            else if (powerchange.powerint > powercontrol.minValue && vitesseint < powerchange.powerint)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = 0.1f;
                    vitesseint++;
                }
            }

            // Désactive l'interaction des boutons et du slider lorsque le bouton est enfoncé
            DisableButtonInteractables();
        }
        else // Si le bouton n'est pas enfoncé
        {
            // Logique pour ajuster la vitesse lorsqu'elle est supérieure à 10
            if (vitesseint > powercontrol.minValue)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = 0.05f;
                    vitesseint--;
                }
                // Désactive l'interaction des boutons et du slider
                DisableButtonInteractables();
            }

            // Réactive l'interaction des boutons et du slider lorsque la vitesse est inférieure ou égale à 10
            if (vitesseint <= powercontrol.minValue)
            {
                EnableButtonInteractables();
            }
        //    Debug.Log(vitesseint);
        }

        // Affiche la vitesse dans le composant Text
        DisplaySpeed();

    }

    // Désactive l'interaction des boutons et du slider
    void DisableButtonInteractables()
    {
        deconnect.interactable = false;
        connectb.interactable = false;
        quiter.interactable = false;
        devicesB.interactable = false;
        powercontrol.interactable = false;
    }

    // Réactive l'interaction des boutons et du slider
    void EnableButtonInteractables()
    {
        deconnect.interactable = true;
        connectb.interactable = true;
        quiter.interactable = true;
        devicesB.interactable = true;
        powercontrol.interactable = true;
    }

    // Affiche la vitesse dans le composant Text
    void DisplaySpeed()
    {
       
            vit.text =  vitesseint.ToString();
            vitesse = vitesseint.ToString();
       
    }

    // Méthode appelée lorsqu'un élément est sélectionné
    public void OnUpdateSelected(BaseEventData data)
    {
        // Vous pourriez ajouter du code ici si nécessaire
    }

    // Méthode appelée lorsqu'un clic est détecté sur l'objet
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true; // Indique que le bouton est enfoncé
  
    }

    // Méthode appelée lorsqu'un clic est relâché sur l'objet
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false; // Indique que le bouton n'est plus enfoncé
  
    }
}
