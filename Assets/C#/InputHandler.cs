using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class InputHandler : MonoBehaviour {

	public static InputHandler instance;

	// CURSOR HANDLING ----------------

	public Texture2D normalCursor;
	public Texture2D hintCursor;
	public Vector2 cursorHotSpot = Vector2.zero;
	public CursorMode cursorMode = CursorMode.Auto;
	public GUIText interactiveObjectHint;
	public Vector2 interactiveObjectHintViewportOffset;

	// NAVIGATION HANDLING ----------------

	public int divisions;
	public float divisionOffset;
	public Agent agent;

	// ----------------

	void Awake() {
		instance = this;
		interactiveObjectHint.enabled = false;
	}

	void Start() {
		Cursor.SetCursor( normalCursor, cursorHotSpot, cursorMode );
	}
	
	void Update(){
		if( Input.GetMouseButtonDown( 0 ) ) GetMouseHit();
	}

	void GetMouseHit() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		NavMeshHit[] navmeshHits = new NavMeshHit[ divisions ];

		for( int i = 0; i < divisions; i++ ) {
			Vector3 point = ray.GetPoint( divisionOffset * i );
			NavMesh.SamplePosition( point, out navmeshHits[i], 100, int.MaxValue );
		}

		Array.Sort( navmeshHits, (a,b) => { return a.distance.CompareTo( b.distance ); } ); 
		agent.GoToPosition( navmeshHits[0].position );
	}

	void OnDrawGizmosSelected() {
		for( int i = 0; i < divisions; i++ ) {
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere( Camera.main.transform.position + ( Vector3.forward * divisionOffset * i ), 1 );
		}
	}

}
