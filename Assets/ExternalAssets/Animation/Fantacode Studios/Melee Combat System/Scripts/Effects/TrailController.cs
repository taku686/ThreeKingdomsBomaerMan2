using UnityEngine;
namespace FS_CombatSystem
{
    public class TrailController : MonoBehaviour
    {
        private const int NUM_VERTICES = 12;

        //[SerializeField] GameObject tip;
        //[SerializeField] GameObject baseObj;


        [SerializeField]
        [Tooltip("The empty game object located at the tip of the blade")]
        private Transform _tip;

        [SerializeField]
        [Tooltip("The empty game object located at the base of the blade")]
        private Transform _base;

        [SerializeField]
        [Tooltip("The mesh object with the mesh filter and mesh renderer")]
        private GameObject _meshParent = null;

        [SerializeField]
        [Tooltip("The number of frame that the trail should be rendered for")]
        private int _trailFrameLength = 3;

        private Mesh _mesh;
        private Vector3[] _vertices;
        private int[] _triangles;
        private int _frameCount;
        private Vector3 _previousTipPosition;
        private Vector3 _previousBasePosition;

        public bool play;

        public GameObject trailObj;

        void Start()
        {
            //_tip = tip.transform.position;
            //_base = baseObj.transform.position;
            _mesh = new Mesh();
            _meshParent.GetComponent<MeshFilter>().mesh = _mesh;

            _vertices = new Vector3[_trailFrameLength * NUM_VERTICES];
            _triangles = new int[_vertices.Length];

            _previousTipPosition = _tip.position;
            _previousBasePosition = _base.position;
        }

        bool _play;

        void LateUpdate()
        {
            return;
            if (play)
            {
                if (!_play)
                {
                    _meshParent.GetComponent<MeshFilter>().mesh = _mesh;
                    _vertices = new Vector3[_trailFrameLength * NUM_VERTICES];
                    _triangles = new int[_vertices.Length];
                    _previousTipPosition = _tip.position;
                    _previousBasePosition = _base.position;
                }

                PlayTrail();
                _play = true;
            }
            else
            {
                if (_play)
                {
                    _mesh = new Mesh();
                    _meshParent.GetComponent<MeshFilter>().mesh = _mesh;
                }
                _play = false;
                //_previousTipPosition = _tip.position;
                //_previousBasePosition = _base.position;
            }
        }

        void PlayTrail()
        {
            if (_frameCount == (_trailFrameLength * NUM_VERTICES))
            {
                _frameCount = 0;
            }

            _meshParent.transform.position = Vector3.zero;
            _meshParent.transform.rotation = Quaternion.identity;

            _vertices[_frameCount] = _base.position;
            _vertices[_frameCount + 1] = _tip.position;
            _vertices[_frameCount + 2] = _previousTipPosition;

            _vertices[_frameCount + 3] = _base.position;
            _vertices[_frameCount + 4] = _previousTipPosition;
            _vertices[_frameCount + 5] = _tip.position;

            //Draw fill in triangle vertices
            _vertices[_frameCount + 6] = _previousTipPosition;
            _vertices[_frameCount + 7] = _base.position;
            _vertices[_frameCount + 8] = _previousBasePosition;

            _vertices[_frameCount + 9] = _previousTipPosition;
            _vertices[_frameCount + 10] = _previousBasePosition;
            _vertices[_frameCount + 11] = _base.position;

            //Set triangles
            _triangles[_frameCount] = _frameCount;
            _triangles[_frameCount + 1] = _frameCount + 1;
            _triangles[_frameCount + 2] = _frameCount + 2;
            _triangles[_frameCount + 3] = _frameCount + 3;
            _triangles[_frameCount + 4] = _frameCount + 4;
            _triangles[_frameCount + 5] = _frameCount + 5;
            _triangles[_frameCount + 6] = _frameCount + 6;
            _triangles[_frameCount + 7] = _frameCount + 7;
            _triangles[_frameCount + 8] = _frameCount + 8;
            _triangles[_frameCount + 9] = _frameCount + 9;
            _triangles[_frameCount + 10] = _frameCount + 10;
            _triangles[_frameCount + 11] = _frameCount + 11;

            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            //Track the previous base and tip positions for the next frame
            _previousTipPosition = _tip.position;
            _previousBasePosition = _base.position;
            _frameCount += NUM_VERTICES;
        }
    }
}