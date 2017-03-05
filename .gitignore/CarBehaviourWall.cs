using UnityEngine;
using System.Collections;

public class CarBehaviourWall : CarBehaviour {

	public WallBehaviourScript LeftWD;
	public WallBehaviourScript RightWD;

	void Update()
	{
		//Read sensor values
		float leftSensor = LeftWD.GetLinearOutput ();
		float rightSensor = RightWD.GetLinearOutput ();

        //Calculate target motor values
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
