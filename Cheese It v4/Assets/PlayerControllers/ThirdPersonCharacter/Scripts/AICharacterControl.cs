using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
		public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		//public Transform eyes;
		public Transform target;                                    // target to aim for
		private bool isDetected;
		private bool prev_detectState;
		public Transform[] points;
		private int destPoint = 0;
		public int detectionDistance;
		public Transform eyes;
		public AudioSource detectAudio;
		
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
			
	        agent.updateRotation = false;
	        agent.updatePosition = true;
			isDetected = false;
        }


        private void Update()
        {
			RaycastHit hit;
			Debug.DrawLine(eyes.transform.position, eyes.transform.forward, Color.yellow);
			if (Physics.Raycast(eyes.transform.position, eyes.transform.forward, out hit, detectionDistance))
			{
				if(hit.rigidbody){
					isDetected = true;
				}
				else{isDetected = false;}
			}
			else{isDetected = false;}

            if (target != null){
				//if the player is spotted, he is detected for five seconds; otherwise keep patrolling
				if(isDetected){
					StartCoroutine(DetectionCountdown());
					
					if(prev_detectState == false)
						detectAudio.Play();
				}
				else if (!agent.pathPending && agent.remainingDistance < 0.5f)
					GotoNextPoint();
			}

			//in case nothing works for some reason:
			//Debug.Log(isDetected);
			//Debug.Log(GetGameObjectPath(hit.transform.gameObject));

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

			prev_detectState = isDetected;
        }
		
		public static string GetGameObjectPath(GameObject obj)
		{
			string path = "/" + obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent.gameObject;
				path = "/" + obj.name + path;
			}
			return path;
		}
		
		public IEnumerator DetectionCountdown(){
			agent.SetDestination(target.position);
			yield return new WaitForSeconds(5f);
			isDetected = false;
		}
		
		void GotoNextPoint() {
			if (points.Length == 0)
				return;

			agent.destination = points[destPoint].position;
			destPoint = (destPoint + 1) % points.Length;
		}

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
		
		
        public void SetPoints(Transform[] points)
        {
            this.points = points;
        }
    }
}
