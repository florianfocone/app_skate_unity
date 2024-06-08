using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class vitessecalcul : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Text vit; // R�f�rence au composant Text repr�sentant la vitesse
    public static int vitesseint = 0; // Valeur de la vitesse (statique pour �tre accessible de mani�re globale)
    public static string vitesse = "00"; // Cha�ne de caract�res repr�sentant la vitesse (statique pour �tre accessible de mani�re globale)
    private float timeLeft = 0.0025f; // Temps restant pour l'incr�mentation/decr�mentation de la vitesse
    public GameObject eclair; // R�f�rence � un objet GameObject repr�sentant un �clair

    private bool isPressed; // Indique si le bouton est enfonc�

    // R�f�rences aux boutons et au slider dans l'interface utilisateur
    public Button deconnect, connectb, quiter, devicesB;
    public Slider powercontrol;

    // M�thode appel�e au d�marrage
    void Start()
    {
        eclair.SetActive(false); // D�sactive l'�clair au d�marrage
        vit = GameObject.Find("vitesse").GetComponent<Text>(); // Trouve le composant Text par son nom
    }

    // M�thode appel�e � chaque frame
    void Update()
    {
        // Si le bouton est enfonc�
        if (isPressed)
        {
            // Logique pour ajuster la vitesse en fonction de la puissance
            if (powerchange.powerint == 0)
            {
                vitesseint = 0;
            }
            else if (powerchange.powerint <= 1)
            {
                vitesseint = 0;
            }
            else if (powerchange.powerint > 2 && vitesseint < powerchange.powerint)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = 0.1f;
                    vitesseint++;
                }
            }

            // D�sactive l'interaction des boutons et du slider lorsque le bouton est enfonc�
            DisableButtonInteractables();
        }
        else // Si le bouton n'est pas enfonc�
        {
            // Logique pour ajuster la vitesse lorsqu'elle est sup�rieure � 10
            if (vitesseint > 1)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = 0.05f;
                    vitesseint--;
                }
                // D�sactive l'interaction des boutons et du slider
                DisableButtonInteractables();
            }

            // R�active l'interaction des boutons et du slider lorsque la vitesse est inf�rieure ou �gale � 10
            if (vitesseint <= 1)
            {
                EnableButtonInteractables();
            }
            Debug.Log(vitesseint);
        }

        // Affiche la vitesse dans le composant Text
        DisplaySpeed();

    }

    // D�sactive l'interaction des boutons et du slider
    void DisableButtonInteractables()
    {
        deconnect.interactable = false;
        connectb.interactable = false;
        quiter.interactable = false;
        devicesB.interactable = false;
        powercontrol.interactable = false;
    }

    // R�active l'interaction des boutons et du slider
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
        if (vitesseint <= 1)
        {
            vit.text = "0" + vitesseint.ToString();
            vitesse = "0" + vitesseint.ToString();
        }
        else
        {
            vit.text = vitesseint.ToString();
            vitesse = vitesseint.ToString();
        }
    }

    // M�thode appel�e lorsqu'un �l�ment est s�lectionn�
    public void OnUpdateSelected(BaseEventData data)
    {
        // Vous pourriez ajouter du code ici si n�cessaire
    }

    // M�thode appel�e lorsqu'un clic est d�tect� sur l'objet
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true; // Indique que le bouton est enfonc�
        eclair.SetActive(true); // Active l'�clair
    }

    // M�thode appel�e lorsqu'un clic est rel�ch� sur l'objet
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false; // Indique que le bouton n'est plus enfonc�
        eclair.SetActive(false); // D�sactive l'�clair
    }
}
