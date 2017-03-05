using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviourWallGauss : CarBehaviour {
    public float b;
    public float c;
	public WallBehaviourScript LeftWD;
    public WallBehaviourScript RightWD;
	private float gaussR;
	private float gaussL;


    // Update is called once per frame
    void Update()
    {
        //Read sensor values
        float leftSensor = LeftWD.GetLinearOutput();
        float rightSensor = RightWD.GetLinearOutput();

        //Calculate target motor values
		gaussL = (float)(Math.Pow (Math.E, -(Math.Pow (leftSensor - b, 2)) / (2 * (Math.Pow (c, 2)))));
		gaussR = (float)(Math.Pow (Math.E, -(Math.Pow (rightSensor - b, 2)) / (2 * (Math.Pow (c, 2)))));

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
		}
}
