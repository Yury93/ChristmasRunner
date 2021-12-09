
using System.Collections;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject modelPlayer;
    [SerializeField] private float deltaY = 0;
    private Vector3 playerPos;
    private FixedJoint fixedJoint;
    private GameObject player;
    private InputPlayer inputPlayer;
    [SerializeField] private float speedUp;
    [SerializeField] private float startSpeed;
    public bool activeRobot = false;
    public bool ActivityRobot => activeRobot;
    private float timer = 1f;

    /// <summary>
    /// скорость похищения
    /// </summary>
    [SerializeField] private float deltaAbduction;
   public  enum  StateMode
    {
        stalking,
        abduction
    }
    StateMode state = StateMode.stalking;
    private void Start()
    {
        fixedJoint = GetComponent<FixedJoint>();
        inputPlayer = modelPlayer.GetComponent<InputPlayer>();
        startSpeed = speed;
        StartCoroutine(corTimerActiveRobot());

    }
    private void Update()
    {
        if(timer < 0)
        {
            activeRobot = true;
        }
        if (activeRobot == true)
        {
            if (state == StateMode.stalking)
            {
                StalkingPlayer();
            }
            if (state == StateMode.abduction)
            {
                Abduction();
            }
        }
    }
    private void StalkingPlayer()
    {
        if (transform.position.y <= 5)
        {
            deltaY = 0;
        }
        else
        {
            deltaY = -1;
        }
        
        if (playerPos.z != modelPlayer.transform.position.z)
        {
            Vector3 playerPos = new Vector3(modelPlayer.transform.position.x, transform.position.y + deltaY, modelPlayer.transform.position.z);
            transform.position = Vector3.Slerp(transform.position, playerPos, speed * Time.deltaTime);
        }
        if(inputPlayer.Timer > 0)
        {
            speed = speedUp;
        }
        else
        {
            speed = startSpeed;
        }
    }
    private void Abduction()
    {
        if (modelPlayer != null)
        {
            modelPlayer.transform.position = gameObject.transform.position;
            transform.Translate(0, 20 * Time.deltaTime, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetModelPlayer(GameObject player)
    {
        if(modelPlayer==null)
        {
            modelPlayer = player;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<InputPlayer>().enabled = false;
            var rb = other.GetComponent<Rigidbody>();
            other.GetComponent<Animation>().enabled = false;
            fixedJoint.connectedBody = rb;
            state = StateMode.abduction;
        }
    }
    public void Active(bool a)
    {
        activeRobot = a;
        timer = 1;
    }
    IEnumerator  corTimerActiveRobot()
    {
        yield return new WaitForSeconds(timer);
        activeRobot = true;
    }
}
