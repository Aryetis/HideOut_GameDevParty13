using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour {

	public Rigidbody myBody;
	public float huntSpeed = 10;
	public float normalSpeed = 4;
	public float rangeMax = 30f;

	private Vector3 goalPosition;
	private NavMeshAgent agent;
	private bool hearNoise = false;
	private bool seePlayer = false;
	private GameObject soundTarget;
	private float cooldownHunt = 0;
	private Animator animBody;


	void Start () {
		goalPosition = Vector3.zero;
		myBody = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent>();
		goalPosition = RandomPoint(transform.position, rangeMax);
		agent.destination = goalPosition;
		animBody = GameObject.Find("Jason").GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldownHunt > 1) {
			cooldownHunt -= 0.1f;
			rangeMax = 2f;
			agent.speed = 1;
			animBody.SetBool("isHunting", false);

		} else if(!hearNoise && !seePlayer){
			animBody.SetBool("isHunting", false);
			rangeMax = 30f;
			agent.speed = normalSpeed;
		}

		if (hearNoise || seePlayer) {
			//goalPosition = soundTarget.transform.position;
			animBody.SetBool("isHunting", true);
			agent.destination = goalPosition;
			agent.speed = huntSpeed;
		}

		animBody.SetFloat("runSpeed", agent.speed);

		if (transform.position.x == goalPosition.x && transform.position.z == goalPosition.z) {
			if (hearNoise) {
				hearNoise = false;
				Destroy (soundTarget);
				agent.speed = normalSpeed;
				cooldownHunt = 10f;
			}
			if (seePlayer) {
				seePlayer = false;
				agent.speed = normalSpeed;
				cooldownHunt = 10f;
			}
			goalPosition = RandomPoint (transform.position, rangeMax);
			agent.destination = goalPosition;
		}

	}

	public void GoToRandomPoint(){
		agent.destination = RandomPoint(transform.position, rangeMax);
	}

	Vector3 RandomPoint(Vector3 center, float range) {
		bool isInMesh = false;
		Vector3 result = Vector3.zero;
		while(!isInMesh){
			Vector3 randomPoint = center + Random.insideUnitSphere * range;
			NavMeshHit hit;
			if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {
				result = hit.position;
				Debug.DrawRay(result, Vector3.up, Color.blue, 2.0f);
				isInMesh = true;
			}
		}
		return result;
	}

	public void setGoalPosition(Vector3 pos){
		goalPosition = pos;
	}

	public void setHearNoise(bool hear){
		hearNoise = hear;
	}

	public void setSeePlayer(bool see){
		seePlayer = see;
	}

	public void setSoundTarget(GameObject target){
		soundTarget = target;
	}
}
