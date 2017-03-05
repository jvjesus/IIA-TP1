using UnityEngine;
using System.Collections;

public class CarBehaviourLight : CarBehaviour {

	public LightDetectorScript LeftLD;
	public LightDetectorScript RightLD;

    void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.GetLinearOutput ();
		float rightSensor = RightLD.GetLinearOutput ();


		if (RThreshold < leftSensor || LThreshold > leftSensor)
		{
			leftSensor = Min;
		}
		if (RThreshold < rightSensor || LThreshold > rightSensor)
		{
			rightSensor = Max;
		}

		if (leftSensor < Min)
		{
			m_LeftWheelSpeed = Min;
		}
		if (rightSensor < Min)
		{
			m_RightWheelSpeed = Min;
		}

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor * MaxSpeed;
		m_RightWheelSpeed = rightSensor * MaxSpeed;
    	}
	}

