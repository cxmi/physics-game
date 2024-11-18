using UnityEngine;
using TubeRendererInternals;

namespace TubeRendererExamples
{
	public class SplineNew : MonoBehaviour
	{
		SplineMaker _splineMaker;
		Vector3[] _anchorPoints;
		public GameObject sphereHead;
    	public GameObject sphere1;
    	public GameObject sphere2;
    	public GameObject sphereButt;
		float anchorCount;
		public int numberOfAnchors = 4;

		// Material and texture you want to apply
        public Material newMaterial; // A new material to assign
        public Texture newTexture;   // A new texture to apply to the material

		private BoxCollider[] _boxColliders;

		void Start()
		{
			//anchorCount = _anchorPoints.Length;
			// Add TubeRendeder component. Can also use getcomponent to edit stuff
			TubeRenderer tube = gameObject.AddComponent<TubeRenderer>();

			tube.radius = 0.3f;

			// Optimise for realtime manipulation.
			tube.MarkDynamic();
			
			// Optionally, you can set a default texture here (if no new texture is provided)
            if (newTexture != null)
            {
                // If a new texture is provided, set it
                Material material = tube.GetComponent<Renderer>().sharedMaterial;
                material.mainTexture = newTexture;  // Set the texture
                tube.uvRect = new Rect(0, 0, 6, 1); // Set default UV Rect (adjust as necessary)
                tube.uvRectCap = new Rect(0, 0, 4/12f, 4/12f); // Set cap UV mapping (adjust as necessary)
            }

			// // Set a texture and a uv mapping.
			// Texture texture = ExampleHelpers.CreateTileTexture( 12 );
			// Material material = tube.GetComponent<Renderer>().sharedMaterial;
			// RenderPipelineHelpers.SetRenderPipelineDependentMainTexture( material, texture );
			// tube.uvRect = new Rect( 0, 0, 6, 1 );
			// tube.uvRectCap = new Rect( 0, 0, 4/12f, 4/12f );

			// Add a SplineMaker component.
			_splineMaker = gameObject.AddComponent<SplineMaker>();

			// Set the spline resolution.
			_splineMaker.pointsPerSegment = 16;

			// Route curve points from spline to tube.
			_splineMaker.onUpdated.AddListener( ( points ) => tube.points = points );

			// Create anchor points for curve.
			_anchorPoints = new Vector3[numberOfAnchors];
			//for( int a = 0; a < _anchorPoints.Length; a++ ) _anchorPoints[a] = new Vector3();
		
		
			//tube.ForceUpdate();


		}
		
		
		void Update()
		{
			Vector3 positionAtHead = sphereHead.transform.position;
			Vector3 positionAtIndex1 = sphere1.transform.position;
			Vector3 positionAtIndex2 = sphere2.transform.position;
			Vector3 positionAtIndex3 = sphereButt.transform.position;


		//this sets the locations to the spheres that control the worm body
			if (sphereHead != null){
                _anchorPoints[0] = sphereHead.transform.position;}
            if (sphere1 != null){
                _anchorPoints[1] = sphere1.transform.position;}
            if (sphere2 != null){
                _anchorPoints[2] = sphere2.transform.position;}
            if (sphereButt != null){
                _anchorPoints[3] = sphereButt.transform.position;}

			_splineMaker.anchorPoints = _anchorPoints;

            // Set the position in the LineRenderer for each index
            //lineRenderer.SetPosition(i, positions[i]);
			//_anchorPoints[i].Set(_anchorPoints[i].x, _anchorPoints[i].y, _anchorPoints[i].z);
			//CreateBoxColliders();
		
		 }

		//try to make box colliders

	    // void CreateBoxColliders(){
			
        // }


	}
}