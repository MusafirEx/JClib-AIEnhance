﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using System;
public class JoyconManager: MonoBehaviour
{

    // Settings accessible via Unity
    public bool EnableIMU = true;
    public bool EnableLocalize = true;

	// Different operating systems either do or don't like the trailing zero
	private const ushort vendor_id = 0x57e;
	private const ushort vendor_id_ = 0x057e;
	private const ushort product_l = 0x2006;
	private const ushort product_r = 0x2007;

    public List<Joycon> j; // Array of all connected Joy-Cons
    public List<Joycon> JCR;
    public List<Joycon> JCL;
    static JoyconManager instance;

    public static JoyconManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
		int i = 0;

		j = new List<Joycon>();
		JCL = new List<Joycon>();
		JCR = new List<Joycon>();
        bool isLeft = false;
		HIDapi.hid_init();

		IntPtr ptr = HIDapi.hid_enumerate(vendor_id, 0x0);
		IntPtr top_ptr = ptr;

		if (ptr == IntPtr.Zero)
		{
			ptr = HIDapi.hid_enumerate(vendor_id_, 0x0);
			if (ptr == IntPtr.Zero)
			{ 
				HIDapi.hid_free_enumeration(ptr);
				Debug.Log ("No Joy-Cons found!");
			}
		}
		hid_device_info enumerate;
		while (ptr != IntPtr.Zero) {
			enumerate = (hid_device_info)Marshal.PtrToStructure (ptr, typeof(hid_device_info));

			Debug.Log (enumerate.product_id);
			if (enumerate.product_id == product_l || enumerate.product_id == product_r) {
				if (enumerate.product_id == product_l) 
				{
					isLeft = true;
					Debug.Log ("Left Joy-Con connected.");
				} else if (enumerate.product_id == product_r) {
					isLeft = false;
					Debug.Log ("Right Joy-Con connected.");
				} 
				else 
				{
					Debug.Log ("Non Joy-Con input device skipped.");
				}
				IntPtr handle = HIDapi.hid_open_path (enumerate.path);
				HIDapi.hid_set_nonblocking (handle, 1);
				j.Add (new Joycon (handle, EnableIMU, EnableLocalize & EnableIMU, 0.05f, isLeft));
				
				if(isLeft)
                   JCL.Add(new Joycon(handle, EnableIMU, EnableLocalize & EnableIMU, 0.05f, isLeft));
				else
                   JCR.Add(new Joycon(handle, EnableIMU, EnableLocalize & EnableIMU, 0.05f, isLeft));

                ++i;
				}
				ptr = enumerate.next;
			}
		HIDapi.hid_free_enumeration (top_ptr);

       
    }
    public int JcrCount;
    public int JclCount;

    void Start()
    {
		for (int i = 0; i < j.Count; ++i)
		{
			Debug.Log (i);
			Joycon jc = j [i];
			byte LEDs = 0x0;
			LEDs |= (byte)(0x1 << i);
			jc.Attach (leds_: LEDs);
			jc.Begin ();
		}

        for (int i = 0; i < JCL.Count; ++i)
        {
            Debug.Log(i);
            Joycon jcl = JCL[i];
            byte LEDs = 0x0;
            LEDs |= (byte)(0x1 << i);
            jcl.Attach(leds_: LEDs);
            jcl.Begin();
        }
        for (int i = 0; i < JCR.Count; ++i)
        {
            Debug.Log(i);
            Joycon jcr = JCR[i];
            byte LEDs = 0x0;
            LEDs |= (byte)(0x1 << i);
            jcr.Attach(leds_: LEDs);
            jcr.Begin();
        }


        JcrCount = JCR.Count;
        JclCount = JCL.Count;


    }

    void Update()
    {
		for (int i = 0; i < j.Count; ++i)
		{
			j[i].Update();
		}

        for (int i = 0; i < JCL.Count; ++i)
        {
            JCL[i].Update();
        }

        for (int i = 0; i < JCR.Count; ++i)
        {
            JCR[i].Update();
        }

    }

    void OnApplicationQuit()
    {
		for (int i = 0; i < j.Count; ++i)
		{
			j[i].Detach ();
		}

        for (int i = 0; i < JCL.Count; ++i)
        {
            JCL[i].Detach();
        }
        for (int i = 0; i < JCR.Count; ++i)
        {
            JCR[i].Detach();
        }
    }    
}
