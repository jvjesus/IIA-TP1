using UnityEngine;
using System.Collections;

public class CarBehaviourLight : CarBehaviour {
	

	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.GetLinearOutput ();
		float rightSensor = RightLD.GetLinearOutput ();

		//Calculate target motor values

		if(m_LeftWheelSpeed > 5){
			m_LeftWheelSpeed = leftSensor * MaxSpeed ;
			m_RightWheelSpeed = rightSensor * MaxSpeed*1.5f;

		}
		else{
			m_LeftWheelSpeed = leftSensor * MaxSpeed*1.5f;
			m_RightWheelSpeed = rightSensor * MaxSpeed;
		}
	}
}
