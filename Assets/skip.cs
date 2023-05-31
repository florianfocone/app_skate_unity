using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class skip : MonoBehaviour
{

    public Text skiptext;
    public float chrono = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
     //   SceneManager.LoadScene(0);

    }

    // Update is called once per frame
    void Update()
    {

        chrono -= Time.deltaTime;

       skiptext.text =  (Mathf.Round(chrono * 10f)/10f).ToString();

        if (chrono<0.0f)
        {
            SceneManager.LoadScene("1");
        }
    }

    public void skipvoid()
    {
        SceneManager.LoadScene("1");
    }
}
