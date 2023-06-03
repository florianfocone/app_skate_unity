using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class vitessecalcul : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{

    public static Text vit;
  
    public static int vitesseint = 1;
    public static string vitesse = "01";
    private float timeLeft = 0.0025f;
    public GameObject eclair;

    private bool isPressed;


    public Button deconnect, connectb, quiter, devicesB;
    public Slider powercontrol;

    // Start is called before the first frame update
    void Start()
    {
        eclair.SetActive(false);
        vit = GameObject.Find("vitesse").GetComponent<Text>();

    }


  void Update()
    {
        if (isPressed)
        {


            if (powerchange.powerint == 1)
            {
                vitesseint = 1;
            }
            else if (powerchange.powerint <= 1)
            {
                vitesseint = 1;
            }
            else if (powerchange.powerint > 24 && vitesseint < powerchange.powerint)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = 0.1f;
                    vitesseint++;
                }
            }

            if (deconnect.interactable == true)
            {
                deconnect.interactable = false;
            }
            if (connectb.interactable == true)
            {
                connectb.interactable = false;
            }
            if (quiter.interactable == true)
            {
                quiter.interactable = false;
            }
            if (devicesB.interactable == true)
            {
                devicesB.interactable = false;
            }
            if (powercontrol.interactable == true)
            {
                powercontrol.interactable = false;
            }


        }
        else
        {

            if (vitesseint > 10)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = 0.05f;
                    vitesseint--;
                }



                deconnect.interactable = false;


                connectb.interactable = false;


                quiter.interactable = false;


                devicesB.interactable = false;


                powercontrol.interactable = false;


            }


            if (vitesseint <= 10)
            {
                vitesseint = 0;


                if (deconnect.interactable == false)
                {
                    deconnect.interactable = true;
                }
                if (connectb.interactable == false)
                {
                    connectb.interactable = true;
                }
                if (quiter.interactable == false)
                {
                    quiter.interactable = true;
                }
                if (devicesB.interactable == false)
                {
                    devicesB.interactable = true;
                }
                if (powercontrol.interactable == false)
                {
                    powercontrol.interactable = true;
                }
            }

        }


        if (vitesseint < 10)
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


    // Start is called before the first frame update
    public void OnUpdateSelected(BaseEventData data)
    {
        
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
        eclair.SetActive(true);
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
        eclair.SetActive(false);



    }
}
