using UnityEngine;
using UnityEngine.UI;

using TechTweaking.Bluetooth;

public class BT : MonoBehaviour {

	private  BluetoothDevice device;
    public string macadress;
    public static string content;
    //public float volume = 0.0f;
    //public Button deviceButton;

  


    private Text devicNameText;
    public Text status;
   // public Text retour;

    float timeLeft = 0.15f;


    bool isPaused = false;


    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;



        BluetoothAdapter.askEnableBluetooth();//Ask user to enable Bluetooth

        BluetoothAdapter.OnDeviceOFF += HandleOnDeviceOff;
        BluetoothAdapter.OnDevicePicked += HandleOnDevicePicked; //To get what device the user picked out of the devices list

    }

    void HandleOnDeviceOff(BluetoothDevice dev)
    {
        if (!string.IsNullOrEmpty(dev.Name))
            status.text = "Couldn't connect to :  " + dev.Name + ", device might be OFF";
        else if (!string.IsNullOrEmpty(dev.MacAddress))
        {
            status.text = "Couldn't connect to : " + dev.MacAddress + ", device might be OFF";
        }
    }

    void HandleOnDevicePicked(BluetoothDevice device)//Called when device is Picked by user
    {
        this.device = device;//save a global reference to the device


        //this.device.UUID = UUID; //This is not required for HC-05/06 devices and many other electronic bluetooth modules.



        devicNameText.text = "Remote Device : " + device.Name;
        macadress = device.MacAddress;
    }


    //############### UI BUTTONS RELATED METHODS #####################
    public void showDevices()
    {
        BluetoothAdapter.showDevices();//show a list of all devices//any picked device will be sent to this.HandleOnDevicePicked()
    }

    public void connect()//Connect to the public global variable "device" if it's not null.
    {

        // check if mac-address different de null pour overide le connect du nom du remote device

        if (device != null)
        {
            device.connect();
            Send0();
           
        //    status.text = "Trying to connect...";
        }


    }

    public void disconnect()//Disconnect the public global variable "device" if it's not null.
    {
        if (device != null)
            Send0();
            device.close();
           

    }

    public void closeapp()//Disconnect the public global variable "device" if it's not null.
    {
        Application.Quit();
    }

   

    //############### Reading Data  #####################
    /* Please note that this way of reading is only used in this demo. All other demos use Coroutines(Unity offers many tutorials on Coroutines).
	 * Just to make things simple
	 */
    void Update() {

        if (device.IsConnected)
        {
            status.text = "Connecté";
        } 
        else
        {
            status.text = "Deconnecté";

        }

       
            Send();
         //   Read();


    }

    private void Send()
    {
       if (device.IsReading)
          {
           
              timeLeft -= Time.deltaTime;
              if (timeLeft < 0)
              {
                  timeLeft = 0.15f;
                  string vitesse = "x"+vitessecalcul.vitesse+"y";
                  device.send(System.Text.Encoding.ASCII.GetBytes(vitesse));
              }
          }
    }

   

  /*  private void Read()
    {

        if (device.IsDataAvailable)
        {
            byte[] msg = device.read();
            if (msg != null)
            {

                content = System.Text.ASCIIEncoding.ASCII.GetString(msg);

                retour.text = content;
            }
        }
    }*/



    private void Send0()
    {
       

          string vitesse = "x01y";
            device.send(System.Text.Encoding.ASCII.GetBytes(vitesse));
            StartCoroutine(waiter());

    }
    System.Collections.IEnumerator waiter()
    {
       
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

    }
        //############### UnRegister Events  #####################
        void OnDestroy()
    {
        BluetoothAdapter.OnDevicePicked -= HandleOnDevicePicked;
        BluetoothAdapter.OnDeviceOFF -= HandleOnDeviceOff;
    }



    void OnApplicationQuit()
    {
        Send0();
        vitessecalcul.vitesseint = 1;
        vitessecalcul.vitesse = "01";

    }

    void OnApplicationFocus(bool hasFocus)
    {
       isPaused = !hasFocus;
        Send0();
        vitessecalcul.vitesseint = 1;
        vitessecalcul.vitesse = "01";

    }

    void OnApplicationPause(bool pauseStatus)
    {
      isPaused = pauseStatus;
      Send0();
        vitessecalcul.vitesseint = 1;
        vitessecalcul.vitesse = "01";
    }

}
