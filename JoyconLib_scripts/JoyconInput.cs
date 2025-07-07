using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class JoyconInput : MonoBehaviour {

    public List<Joycon> joycons;
    public List<Joycon> JCR;
    public List<Joycon> JCL;
    public int jCount;
    public int JcrCount;
    public int JclCount;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;


    public float[] JoyCon1_RStick;
    public Vector3 JoyCon1_RGyro;
    public Vector3 JoyCon1_RAccel;
    public Quaternion JoyCon1_ROrientation;

    public float[] JoyCon2_RStick;
    public Vector3 JoyCon2_RGyro;
    public Vector3 JoyCon2_RAccel;
    public Quaternion JoyCon2_ROrientation;

    public float[] JoyCon3_RStick;
    public Vector3 JoyCon3_RGyro;
    public Vector3 JoyCon3_RAccel;
    public Quaternion JoyCon3_ROrientation;

    public float[] JoyCon4_RStick;
    public Vector3 JoyCon4_RGyro;
    public Vector3 JoyCon4_RAccel;
    public Quaternion JoyCon4_ROrientation;


    public float[] JoyCon1_LStick;
    public Vector3 JoyCon1_LGyro;
    public Vector3 JoyCon1_LAccel;
    public Quaternion JoyCon1_LOrientation;

    public float[] JoyCon2_LStick;
    public Vector3 JoyCon2_LGyro;
    public Vector3 JoyCon2_LAccel;
    public Quaternion JoyCon2_LOrientation;

    public float[] JoyCon3_LStick;
    public Vector3 JoyCon3_LGyro;
    public Vector3 JoyCon3_LAccel;
    public Quaternion JoyCon3_LOrientation;

    public float[] JoyCon4_LStick;
    public Vector3 JoyCon4_LGyro;
    public Vector3 JoyCon4_LAccel;
    public Quaternion JoyCon4_LOrientation;



    void Start()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        JoyCon1_RGyro = new Vector3(0, 0, 0);
        JoyCon1_RAccel = new Vector3(0, 0, 0);
        JoyCon1_LGyro = new Vector3(0, 0, 0);
        JoyCon1_LAccel = new Vector3(0, 0, 0);
        JoyCon2_RGyro = new Vector3(0, 0, 0);
        JoyCon2_RAccel = new Vector3(0, 0, 0);
        JoyCon2_LGyro = new Vector3(0, 0, 0);
        JoyCon2_LAccel = new Vector3(0, 0, 0);
        JoyCon3_RGyro = new Vector3(0, 0, 0);
        JoyCon3_RAccel = new Vector3(0, 0, 0);
        JoyCon3_LGyro = new Vector3(0, 0, 0);
        JoyCon3_LAccel = new Vector3(0, 0, 0);
        JoyCon4_RGyro = new Vector3(0, 0, 0);
        JoyCon4_RAccel = new Vector3(0, 0, 0);
        JoyCon4_LGyro = new Vector3(0, 0, 0);
        JoyCon4_LAccel = new Vector3(0, 0, 0);

        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
        JCL = JoyconManager.Instance.JCL;
        JCR = JoyconManager.Instance.JCR;
        jCount = joycons.Count;
        JcrCount = JCR.Count;
        JclCount = JCL.Count;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];
            // GetButtonDown checks if a button has been pressed (not held)
            if (j.GetButtonDown(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 pressed");
                // GetStick returns a 2-element vector with x/y joystick components
                Debug.Log(string.Format("Stick x: {0:N} Stick y: {1:N}", j.GetStick()[0], j.GetStick()[1]));

                // Joycon has no magnetometer, so it cannot accurately determine its yaw value. Joycon.Recenter allows the user to reset the yaw value.
                j.Recenter();
            }
            // GetButtonDown checks if a button has been released
            if (j.GetButtonUp(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 released");
            }
            // GetButtonDown checks if a button is currently down (pressed or held)
            if (j.GetButton(Joycon.Button.SHOULDER_2))
            {
                Debug.Log("Shoulder button 2 held");
            }

            if (j.GetButtonDown(Joycon.Button.DPAD_DOWN))
            {
                Debug.Log("Rumble");

                // Rumble for 200 milliseconds, with low frequency rumble at 160 Hz and high frequency rumble at 320 Hz. For more information check:
                // https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering/blob/master/rumble_data_table.md

                j.SetRumble(160, 320, 0.6f, 200);

                // The last argument (time) in SetRumble is optional. Call it with three arguments to turn it on without telling it when to turn off.
                // (Useful for dynamically changing rumble values.)
                // Then call SetRumble(0,0,0) when you want to turn it off.
            }

            stick = j.GetStick();

            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();

            orientation = j.GetVector();

            if (j.GetButton(Joycon.Button.DPAD_UP))
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            gameObject.transform.rotation = orientation;
            // gameObject.transform.Rotate(-90, 90, 0, Space.World);
        }*/

        if (JCR.Count > 0)
        {
            Joycon j1r = JCR[0];
            JoyCon1_RStick = j1r.GetStick();
            JoyCon1_RGyro = j1r.GetGyro();
            JoyCon1_RAccel = j1r.GetAccel();
            JoyCon1_ROrientation = j1r.GetVector();



            if (JCR.Count > 1)
            {
                Joycon j2r = JCR[1];
                JoyCon2_RStick = j2r.GetStick();
                JoyCon2_RGyro = j2r.GetGyro();
                JoyCon2_RAccel = j2r.GetAccel();
                JoyCon2_ROrientation = j2r.GetVector();

                if (JCR.Count > 2)
                {
                    Joycon j3r = JCR[2];
                    JoyCon3_RStick = j3r.GetStick();
                    JoyCon3_RGyro = j3r.GetGyro();
                    JoyCon3_RAccel = j3r.GetAccel();
                    JoyCon3_ROrientation = j3r.GetVector();
                    if (JCR.Count > 3)
                    {
                        Joycon j4r = JCR[3];
                        JoyCon4_RStick = j4r.GetStick();
                        JoyCon4_RGyro = j4r.GetGyro();
                        JoyCon4_RAccel = j4r.GetAccel();
                        JoyCon4_ROrientation = j4r.GetVector();
                    }
                }
            }
            
        }


        if (JCL.Count > 0)
        {
            Joycon j1l = JCL[0];
            JoyCon1_LStick = j1l.GetStick();
            JoyCon1_LGyro = j1l.GetGyro();
            JoyCon1_LAccel = j1l.GetAccel();
            JoyCon1_LOrientation = j1l.GetVector();
            if (JCL.Count > 1)
            {
                Joycon j2l = JCL[1];
                JoyCon2_LStick = j2l.GetStick();
                JoyCon2_LGyro = j2l.GetGyro();
                JoyCon2_LAccel = j2l.GetAccel();
                JoyCon2_LOrientation = j2l.GetVector();
                if (JCL.Count > 2)
                {
                    Joycon j3l = JCL[2];
                    JoyCon3_LStick = j3l.GetStick();
                    JoyCon3_LGyro = j3l.GetGyro();
                    JoyCon3_LAccel = j3l.GetAccel();
                    JoyCon3_LOrientation = j3l.GetVector();
                    if (JCL.Count > 3)
                    {
                        Joycon j4l = JCL[3];
                        JoyCon4_LStick = j4l.GetStick();
                        JoyCon4_LGyro = j4l.GetGyro();
                        JoyCon4_LAccel = j4l.GetAccel();
                        JoyCon4_LOrientation = j4l.GetVector();
                    }
                }
            }
        }
    }

    [Serializable]
    public class InputData
    {
        public float[] stick;
        public Vector3 gyro;
        public Vector3 accel;
        public Quaternion orientation;
    }

}