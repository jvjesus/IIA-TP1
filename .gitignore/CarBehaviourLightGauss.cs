using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviourLightGauss : CarBehaviour {
    public float b;
	public float c;
	private float gauss;
	public LightDetectorScript LeftLD;
	public LightDetectorScript RightLD;
	private float gaussR;
	private float gaussL;
	
	// Update is called once per frame
	void Update () {
        //Read sensor values
        float leftSensor = LeftLD.GetLinearOutput();
        float rightSensor = RightLD.GetLinearOutput();


		gaussL = (float)( Math.Pow (Math.E, -(Math.Pow (leftSensor - b, 2)) / (2 * (Math.Pow (c, 2)))));
		gaussR = (float)( Math.Pow (Math.E, -(Math.Pow (rightSensor - b, 2)) / (2 * (Math.Pow (c, 2)))));

		if (RThreshold < rightSensor || LThreshold > rightSensor)
		{
			gaussR = Min;
		}
		if (RThreshold < leftSensor || LThreshold > leftSensor)
		{
			gaussL = Min;
		}

		if (gaussL < Min)
			gaussL = Min;

		if (gaussL > Max)
			gaussL = Max;

		if (gaussR < Min)
			gaussR = Min;

		if (gaussR > Max)
			gaussR = Max;

		m_LeftWheelSpeed = gaussL * MaxSpeed;
		m_RightWheelSpeed = gaussR * MaxSpeed;
		print ("sensR: " + rightSensor + "\nsensL: " + leftSensor);
		print ("R: " + gaussR + "\nL: " + gaussL);
    }
}
