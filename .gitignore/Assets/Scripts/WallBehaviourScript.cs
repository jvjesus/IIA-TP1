using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class WallBehaviourScript : MonoBehaviour {

	public float angle;
	private bool useAngle = false;
	public float distance;


	public int numObjects;
	// Use this for initialization
	void Start () {

		distance = 0;
		numObjects = 0;
		if (angle >= 360) {
			useAngle = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		float temp;
		 
		GameObject[] walls;

		if (useAngle) {
			walls = GetVisibleWalls ();
		} else {
			walls = GetAllWalls ();
		}

		distance = 0;
		numObjects = walls.Length;

		foreach (GameObject wall in walls) {
			//distance = Vector3.Distance(transform.position, wall.transform.position);
			temp = 1.0f / ((transform.position - wall.transform.position).magnitude + 1);
			if (distance < temp) {
				distance = temp;
			}
	}	
}
		

	public float GetLinearOutput()
	{
		return distance;
	}

	public virtual float GetGaussianOutput()
	{
		throw new NotImplementedException ();
	}

	// Returns all "Wall" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllWalls()
	{
		return GameObject.FindGameObjectsWithTag ("Wall");
	}

	GameObject[] GetVisibleWalls()
	{
		ArrayList visibleWalls = new ArrayList();
		float halfAngle = angle / 2.0f;

		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Wall");

		foreach (GameObject wall in walls) {
			Vector3 toVector = (wall.transform.position - transform.position);
			Vector3 forward = transform.forward;
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle (forward, toVector);

			if (angleToTarget <= halfAngle) {
				visibleWalls.Add (wall);
			}
		}

		return (GameObject[])visibleWalls.ToArray(typeof(GameObject));
	}
}