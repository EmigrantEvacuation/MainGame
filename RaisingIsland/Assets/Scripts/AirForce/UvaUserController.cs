﻿using System;
using UnityEngine;
using UvaSimulator.Uva.ControlCalculator;

namespace UvaSimulator.Uva.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(UvaUserControllCalculator))]
    public class UvaUserController : MonoBehaviour {

        private Rigidbody planeRigid;
        private UvaUserControllCalculator uva;
        public float Throttle { get; private set; }
        public float Pitch { get; private set; }
        public float Row { get; private set; }
        public float Yaw { get; private set; }
        public bool AirBrake { get; private set; }

	    // Use this for initialization
	    void Start () {
            planeRigid = GetComponent<Rigidbody>();
            uva = GetComponent<UvaUserControllCalculator>();
	    }
	    
	    // Update is called once per frame
	    void Update () {
			Throttle = Input.GetKey (KeyCode.W) ? 1.0f : (Input.GetKey (KeyCode.S) ? -1.0f : 0.0f);
			print (Throttle);
			AirBrake = Input.GetKey(KeyCode.S)? true : false;
            Pitch = Input.GetAxis("Vertical");
            Row = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.A))
            {
                Yaw = -1.0f;
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Yaw = 1.0f;
                }
                else
                {
                    Yaw = 0.0f;
                }
            }
				
            uva.Move(Pitch,Row,Yaw,Throttle,AirBrake);
	    }
    }
}

