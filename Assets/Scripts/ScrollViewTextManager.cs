using UnityEngine;
using UnityEngine.UI;

public class ScrollViewTextManager : MonoBehaviour
{
    public ScrollRect scrollRect; // Assignez votre ScrollRect dans l'inspecteur
    public int fontSize = 10;
    public Font font; // Assignez une police dans l'inspecteur

    void Start()
    {
        AdjustTextInScrollView();
    }

    public void AdjustTextInScrollView()
    {
        // Trouve tous les objets Text enfants du Content
        Text[] textObjects = scrollRect.content.GetComponentsInChildren<Text>();

        foreach (Text text in textObjects)
        {
            // Configure les paramètres de texte
            text.font = font ?? Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.fontSize = fontSize;
            text.color = Color.red;
            text.alignment = TextAnchor.MiddleCenter;

            // Ajuste le RectTransform
            RectTransform rectTransform = text.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 1);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.pivot = new Vector2(0.5f, 1);

            // Assurez-vous que le texte prend toute la largeur du parent
            LayoutElement layoutElement = text.GetComponent<LayoutElement>();
            if (layoutElement == null)
            {
                layoutElement = text.gameObject.AddComponent<LayoutElement>();
            }
            layoutElement.minWidth = scrollRect.viewport.rect.width;
        }
    }
}
