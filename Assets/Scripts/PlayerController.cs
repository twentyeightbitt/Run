using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed = 10;
    private float _horizontalInput;
    [SerializeField] private float _xBorder = 2.5f;
    [SerializeField] private int _jumpForce = 7;
    private bool _onGround = true;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioSource _audioSource;



    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (Input.GetKeyDown(KeyCode.Space) && _onGround == true)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _onGround = false;
            _audioSource.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Вы проиграли");
            _gameManager.gameStatus = 0;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Вы выиграли!");
            _gameManager.gameStatus = 1;
        }

        if (collision.gameObject.CompareTag("Road"))
        {
            _onGround = true;
        }
    }
}
