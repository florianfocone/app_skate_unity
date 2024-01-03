using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public Text skiptext; // Texte affichant le compte � rebours
    public float chrono = 10.0f; // Dur�e du compte � rebours en secondes

    // M�thode appel�e au d�marrage
    void Start()
    {
        // Chargement de la sc�ne avec l'index 0 (peut �tre d�comment� si n�cessaire)
        // SceneManager.LoadScene(0);
    }

    // M�thode appel�e � chaque frame
    void Update()
    {
        // D�cr�mente le compte � rebours en fonction du temps �coul� depuis la derni�re frame
        chrono -= Time.deltaTime;

        // Met � jour le texte affichant le compte � rebours
        skiptext.text = (Mathf.Round(chrono * 10f) / 10f).ToString();

        // Si le compte � rebours atteint z�ro, charge la sc�ne "1"
        if (chrono < 0.0f)
        {
            SceneManager.LoadScene("1");
        }
    }

    // M�thode appel�e lorsqu'un bouton "skip" est press�
    public void skipvoid()
    {
        // Charge la sc�ne "1"
        SceneManager.LoadScene("1");
    }
}

