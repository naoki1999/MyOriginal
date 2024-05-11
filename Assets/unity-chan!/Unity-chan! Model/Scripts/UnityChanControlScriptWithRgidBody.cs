using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class UnityChanControllScriptWithRgidBody : MonoBehaviour 
{ 
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Animator _animator;
    private float _horizontal;
    private float _vertical;
    private Vector3 _velocity;
    private float _speed = 7f;
    public GameObject unityChan;
    private Vector3 _aim;
    private Quaternion _playerRotation;
    //スコアを表示
    private GameObject scoreText;
    //得点
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _playerRotation = _transform.rotation;

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
       
    }

    private void Update()
    {
        
    
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        var _horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        _velocity = _horizontalRotation * new Vector3(_horizontal, 0, _vertical).normalized;
        if (_aim.magnitude > 0.5f)
        {
            _playerRotation = Quaternion.LookRotation(_aim, Vector3.up);
        }
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _playerRotation, 600 * Time.deltaTime);
        if (_velocity.magnitude > 0.1f)
        {
            _animator.SetBool("Running", true);
        }
        else
        {
            _animator.SetBool("Running", false);
        }
        _rigidbody.velocity = _velocity * _speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UnityChanTag"))
        {
            Destroy(gameObject);

            //スコアを加算
            this.score += 10;

            //スコアテキストにスコアを表示
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";

        }
    }
}