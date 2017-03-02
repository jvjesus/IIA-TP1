using UnityEngine;
using System.Collections;

public class CarBehaviourWall : CarBehaviour {

	public WallBehaviourScript LeftLD2;
	public WallBehaviourScript RightLD2;

	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD2.GetLinearOutput ();
		float rightSensor = RightLD2.GetLinearOutput ();

		//Calculate target motor values
		m_LeftWheelSpeed = leftSensor*MaxSpeed;
		m_RightWheelSpeed = rightSensor*MaxSpeed;	


		print("DistanceL: " + m_LeftWheelSpeed);
		print("DistanceR: " + m_RightWheelSpeed);
	}
}
