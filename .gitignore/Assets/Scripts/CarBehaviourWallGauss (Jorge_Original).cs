using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviourWallGauss : CarBehaviour {
    private float a;
    public float b;
    public float c;
    public WallBehaviourScript LeftWD;
    public WallBehaviourScript RightWD;       

    // Update is called once per frame
    void Update()
    {
        a = (float)(1 / (c * Math.Sqrt(2 * Math.PI)));
        //Read sensor values
        float leftSensor = LeftWD.GetLinearOutput();
        float rightSensor = RightWD.GetLinearOutput();

        //Calculate target motor values
        if (RThreshold > leftSensor && LThreshold < leftSensor)
        {
            m_LeftWheelSpeed = (float)(a*Math.Pow(Math.E, -(Math.Pow(leftSensor - b, 2)) / (2 * (Math.Pow(c, 2)))) * MaxSpeed);
            print(m_LeftWheelSpeed);
        }
        if (RThreshold > rightSensor && LThreshold < rightSensor)
        {
            m_RightWheelSpeed = (float)(a*Math.Pow(Math.E, -(Math.Pow(rightSensor - b, 2)) / (2 * (Math.Pow(c, 2)))) * MaxSpeed);
        }
        if (leftSensor < MinSpeed)
        {
            m_LeftWheelSpeed = MinSpeed;
        }
        if (rightSensor < MinSpeed)
        {
            m_RightWheelSpeed = MinSpeed;
        }
    }
}
