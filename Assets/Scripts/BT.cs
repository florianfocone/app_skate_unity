// Importation des bibliothèques Unity nécessaires
using UnityEngine;
using UnityEngine.UI;

// Importation de la bibliothèque Bluetooth
using TechTweaking.Bluetooth; // Asset Bluetooth pour Android & Microcontrôleurs de YAHYA BADRAN acheté en 2018

// Déclaration de la classe BT (Bluetooth)
public class BT : MonoBehaviour
{

    // Variables membres
    private BluetoothDevice device; // Représente le périphérique Bluetooth auquel se connecter
    public string macadress; // Adresse MAC du périphérique Bluetooth
    public static string content; // Contenu des données reçues
    private Text devicNameText; // Texte affichant le nom du périphérique
    public Text status; // Texte affichant le statut de la connexion

    float timeLeft = 0.15f; // Durée entre l'envoi de données
    bool isPaused = false; // Indique si l'application est en pause

    // Méthode appelée au démarrage
    void Awake()
    {
        // Désactive la mise en veille de l'écran
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // Demande à l'utilisateur d'activer le Bluetooth
        BluetoothAdapter.askEnableBluetooth();

        // Ajoute des gestionnaires d'événements pour la détection des événements Bluetooth
        BluetoothAdapter.OnDeviceOFF += HandleOnDeviceOff;
        BluetoothAdapter.OnDevicePicked += HandleOnDevicePicked; // Pour obtenir le périphérique choisi par l'utilisateur dans la liste des périphériques
    }

    // Méthode appelée lorsqu'un périphérique est éteint
    void HandleOnDeviceOff(BluetoothDevice dev)
    {
        if (!string.IsNullOrEmpty(dev.Name))
            status.text = "Impossible de se connecter à :  " + dev.Name + ", le périphérique est peut-être éteint";
        else if (!string.IsNullOrEmpty(dev.MacAddress))
        {
            status.text = "Impossible de se connecter à : " + dev.MacAddress + ", le périphérique est peut-être éteint";
        }
    }

    // Méthode appelée lorsqu'un périphérique est choisi par l'utilisateur
    void HandleOnDevicePicked(BluetoothDevice device)
    {
        this.device = device; // Sauvegarde une référence globale au périphérique
        devicNameText.text = "Périphérique distant : " + device.Name;
        macadress = device.MacAddress;
    }

    // Méthodes liées aux boutons de l'interface utilisateur
    public void showDevices()
    {
        BluetoothAdapter.showDevices(); // Affiche la liste de tous les périphériques
    }

    public void connect()
    {
        // Connecte au périphérique Bluetooth seulement s'il n'est pas nul
        if (device != null)
        {
            device.connect();
            Send0();
        }
    }

    public void disconnect()
    {
        // Déconnecte du périphérique Bluetooth seulement s'il n'est pas nul
        if (device != null)
        {
            Send0();
            device.close();
        }
    }

    public void closeapp()
    {
        // Quitte l'application
        Application.Quit();
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Met à jour le statut de la connexion
        if (device.IsConnected)
        {
            status.text = "Connecté";
        }
        else
        {
            status.text = "Déconnecté";
        }

        // Envoie des données au périphérique
        Send();
    }

    // Envoie des données au périphérique Bluetooth
    private void Send()
    {
        if (device.IsReading)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0.15f;
                string vitesse = "x" + vitessecalcul.vitesse + "y";
                device.send(System.Text.Encoding.ASCII.GetBytes(vitesse));
            }
        }
    }

    private void Send0()
    {
        string vitesse = "x01y";
        device.send(System.Text.Encoding.ASCII.GetBytes(vitesse));
        StartCoroutine(waiter());
    }

    System.Collections.IEnumerator waiter()
    {
        // Attend pendant 1 seconde
        yield return new WaitForSeconds(1);
        // Vous pourriez ajouter du code ici à exécuter après l'attente
    }

    // Méthode appelée lors de la fermeture de l'application
    void OnApplicationQuit()
    {
        Send0();
        vitessecalcul.vitesseint = 1;
        vitessecalcul.vitesse = "01";
    }

    // Méthode appelée lorsqu'on perd/reprend le focus de l'application
    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
        Send0();
        vitessecalcul.vitesseint = 1;
        vitessecalcul.vitesse = "01";
    }

    // Méthode appelée lorsque l'application est mise en pause ou reprend
    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        Send0();
        vitessecalcul.vitesseint = 1;
        vitessecalcul.vitesse = "01";
    }

    // Méthode appelée lors de la destruction de l'objet
    void OnDestroy()
    {
        // Désenregistre les gestionnaires d'événements Bluetooth
        BluetoothAdapter.OnDevicePicked -= HandleOnDevicePicked;
        BluetoothAdapter.OnDeviceOFF -= HandleOnDeviceOff;
    }
}
