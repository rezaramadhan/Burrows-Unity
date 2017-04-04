using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class HatchController : MonoBehaviour {
	public ScoreController control;
	private float idletime; // time of idle 
	private bool istate;

	public AudioSource hatchSFX;

	public Text state;

	float timer;

    public SerialPort serialPort = new SerialPort("COM4", 9600);

	// Use this for initialization
	void Start () {
		istate = false;
        serialPort.Open();
        serialPort.ReadTimeout = 1; 
	}

	// Update is called once per frame
	/// <summary>
	/// if player is idling (not opening any hatches) for 5 seconds, 
	/// 1 life will be taken away for each 5 seconds
	/// </summary>
	void Update () {
        if (serialPort.IsOpen)
        {
            try
            {
                int reading = serialPort.ReadByte();
                serialPort.BaseStream.Flush();
                if (reading == 1 || reading == 4 || reading == 5  || reading == 7)
                {
                    this.transform.GetChild(0).gameObject.SetActive(true);
                    this.transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(false);
                }
                else {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                    this.transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(true);
                }

                if (reading == 2 || reading == 4 || reading == 6 || reading == 7)
                {
                    this.transform.GetChild(1).gameObject.SetActive(true);
                    this.transform.parent.GetChild(0).GetChild(1).gameObject.SetActive(false);
                }
                else {
                    this.transform.GetChild(1).gameObject.SetActive(false);
                    this.transform.parent.GetChild(0).GetChild(1).gameObject.SetActive(true);
                }

                if (reading == 3 || reading == 5 || reading == 6 || reading == 7)
                {
                    this.transform.GetChild(2).gameObject.SetActive(true);
                    this.transform.parent.GetChild(0).GetChild(2).gameObject.SetActive(false);
                }
                else {
                    this.transform.GetChild(2).gameObject.SetActive(false);
                    this.transform.parent.GetChild(0).GetChild(2).gameObject.SetActive(true);
                }

                //if no input is pressed and all hatches are closed (idle)
                if (!this.transform.parent.GetChild(0).GetChild(0).gameObject.activeSelf &&
                    !this.transform.parent.GetChild(0).GetChild(1).gameObject.activeSelf &&
                    !this.transform.parent.GetChild(0).GetChild(2).gameObject.activeSelf)
                {
                    //checks if this is the first caught instance of idling
                    if (!istate)
                    {
                        //initiate idle time count
                        idletime = Time.time;
                        istate = true;

                        //notify player that they are idling
                        state.text = "Idle! ";
                    }
                    else { //check if idle time >= 5 seconds
                        if (Time.time >= idletime + 5f)
                        {
                            //reduce life & reset idle time count
                            control.reduceLife();
                            idletime = Time.time;

                            //show player they are taking damage
                            //also play sound effect
                            /*
                            this.transform.GetChild (0).transform.Translate (-0.1f, 0, 0);
                            this.transform.GetChild (1).transform.Translate (-0.1f, 0, 0);
                            this.transform.GetChild (2).transform.Translate (-0.1f, 0, 0);
                            timer = 0f;
                            while (timer <= 3f) {
                                if (dir) {
                                    this.transform.GetChild (0).transform.Translate (0.2f, 0, 0);
                                    this.transform.GetChild (1).transform.Translate (0.2f, 0, 0);
                                    this.transform.GetChild (2).transform.Translate (0.2f, 0, 0);
                                    dir = false;
                                } else {
                                    this.transform.GetChild (0).transform.Translate (-0.2f, 0, 0);
                                    this.transform.GetChild (1).transform.Translate (-0.2f, 0, 0);
                                    this.transform.GetChild (2).transform.Translate (-0.2f, 0, 0);
                                    dir = true;
                                }
                                timer += Time.deltaTime;
                            }
                            this.transform.GetChild (0).transform.position.Set (0, 0, 0);
                            this.transform.GetChild (1).transform.position.Set (0, 0, 0);
                            this.transform.GetChild (2).transform.position.Set (0, 0, 0);
                            */
                            //notify player that they are taking damage
                            //state.text = "Idle! Health -1";
                        }
                    }
                }
                else {
                    //one or more hatches are open; reset idle state
                    istate = false;
                    state.text = "";
                }
            }
            catch (System.Exception)
            {

            }

        } 
		
	}

	void hatchContact (GameObject obj) {
		//make items bounce
		Rigidbody rb;
		rb = obj.GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (0, 5, 0), ForceMode.Impulse);

		//play hatch sound effect
		hatchSFX.Play();
	}

    void hatchControl (int hole)
    {
        if (hole == 1)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        else {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.parent.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        if (hole == 2)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.parent.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        else {
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.parent.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
        if (hole == 3)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.parent.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
        else {
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.parent.GetChild(0).GetChild(2).gameObject.SetActive(true);
        } //if no input is pressed and all hatches are closed (idle)
        if (!this.transform.parent.GetChild(0).GetChild(0).gameObject.activeSelf &&
            !this.transform.parent.GetChild(0).GetChild(1).gameObject.activeSelf &&
            !this.transform.parent.GetChild(0).GetChild(2).gameObject.activeSelf)
        {
            //checks if this is the first caught instance of idling
            if (!istate)
            {
                //initiate idle time count
                idletime = Time.time;
                istate = true;

                //notify player that they are idling
                state.text = "Idle! ";
            }
            else { //check if idle time >= 5 seconds
                if (Time.time >= idletime + 5f)
                {
                    //reduce life & reset idle time count
                    control.reduceLife();
                    idletime = Time.time;

                    //show player they are taking damage
                    //also play sound effect
                    /*
                    this.transform.GetChild (0).transform.Translate (-0.1f, 0, 0);
                    this.transform.GetChild (1).transform.Translate (-0.1f, 0, 0);
                    this.transform.GetChild (2).transform.Translate (-0.1f, 0, 0);
                    timer = 0f;
                    while (timer <= 3f) {
                        if (dir) {
                            this.transform.GetChild (0).transform.Translate (0.2f, 0, 0);
                            this.transform.GetChild (1).transform.Translate (0.2f, 0, 0);
                            this.transform.GetChild (2).transform.Translate (0.2f, 0, 0);
                            dir = false;
                        } else {
                            this.transform.GetChild (0).transform.Translate (-0.2f, 0, 0);
                            this.transform.GetChild (1).transform.Translate (-0.2f, 0, 0);
                            this.transform.GetChild (2).transform.Translate (-0.2f, 0, 0);
                            dir = true;
                        }
                        timer += Time.deltaTime;
                    }
                    this.transform.GetChild (0).transform.position.Set (0, 0, 0);
                    this.transform.GetChild (1).transform.position.Set (0, 0, 0);
                    this.transform.GetChild (2).transform.position.Set (0, 0, 0);
                    */
                    //notify player that they are taking damage
                    //state.text = "Idle! Health -1";
                }
            }
        }
        else {
            //one or more hatches are open; reset idle state
            istate = false;
            state.text = "";
        }

    }
}
