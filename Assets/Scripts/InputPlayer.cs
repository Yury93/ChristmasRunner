using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class InputPlayer : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    private int hp;
    public int HP => hp;
    /// <summary>
    /// Сохранение скорости для будущего февера
    /// </summary>
    private float startSpeed;
    private float deltaX = 0f;
    [SerializeField] private float speedDeltaX;
    private Vector3 moveDirection;
    
    [SerializeField]private float timer = -1;
    public float Timer => timer;
    [SerializeField] private float speedUp;

    [SerializeField] private int score = 0;
    public int Score => score;


    //public void CalculateScore()
    //{
    //    PlayerSatistic.Instance.ShowScore();
    //}
    public void ApplyDamage(int damage)
    {
        hp -= damage;
    }
    void Start()
    {
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
        startSpeed = speed;
    }

    private void Update()
    {
        Move();
        if (timer > 0)
        {
            speed = speedUp;
            timer -= Time.deltaTime;
        }
        else
        {
            speed = startSpeed;
        }
    }
    private void Move()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            deltaX = Input.acceleration.x;
        }
        else
        {
            deltaX = Input.GetAxis("Horizontal");
        }

        moveDirection = new Vector3(deltaX * speedDeltaX, 0, speed);
        characterController.Move(moveDirection * Time.deltaTime);
    }
    public void UseTimerSpeed(float timerUp)
    {
        timer = timerUp;
    }
}
