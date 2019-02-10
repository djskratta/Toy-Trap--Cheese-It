using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform eyes;	                                    
        public Transform target;                                    // target to aim for
		private bool isDetected;
		public Transform[] points;
		//private Rigidbody player;
        private int destPoint = 0;
		public int detect_dist;
		
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
			//player = target.GetComponent<Rigidbody>();
			//isDetected = false;
			
	        agent.updateRotation = false;
	        agent.updatePosition = true;
			isDetected = false;
			
			//GotoNextPoint();
        }


        private void Update()
        {
            if (target != null){
				if(isDetected)
					agent.SetDestination(target.position);
				else if (!agent.pathPending && agent.remainingDistance < 0.5f)
					GotoNextPoint();

			}
			

			RaycastHit hit;
			if (Physics.Linecast(eyes.transform.position, eyes.transform.forward, out hit))
			{
				if(hit.rigidbody)
					isDetected = true;
				else{isDetected = false;}
			}
			else{isDetected = false;}
//			Debug.Log(isDetected);
			
			/*
			if (Physics.Raycast(agent.transform.position, player.position, out hit, detect_dist, 2))
			{
				if(hit.rigidbody)
					isDetected = true;
				else{isDetected = false;}
			}
			else{isDetected = false;}
			*/
//			Debug.Log(hit.collider);
            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

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
    }
}
