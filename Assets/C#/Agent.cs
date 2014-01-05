using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	public NavMeshAgent navmeshAgent;

	public void GoToPosition( Vector3 position ) {
		if( !navmeshAgent.SetDestination( position ) ) {
			Debug.LogError( "Agent: unable to set destination " + position );
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere( navmeshAgent.destination, 1 );
	}

}
