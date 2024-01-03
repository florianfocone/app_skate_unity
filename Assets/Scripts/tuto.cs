using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto : MonoBehaviour
{
    // La méthode Start est appelée avant la première frame
    void Start()
    {
        // Ici, vous pourriez mettre du code d'initialisation si nécessaire
    }

    // La méthode Update est appelée à chaque frame
    void Update()
    {
        // Ici, vous pourriez mettre du code qui doit être exécuté à chaque frame
    }

    // Cette méthode est publique, ce qui signifie qu'elle peut être appelée depuis d'autres scripts ou objets
    public void OpenURL()
    {
        // Ouvre une URL dans le navigateur par défaut
        Application.OpenURL("https://florianfocone.com");
    }
}

