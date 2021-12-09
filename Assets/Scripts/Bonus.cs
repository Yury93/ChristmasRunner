using System.Collections;
using UnityEngine;


public class Bonus : Destructible
{
    [SerializeField] private int score = 0;
    public int Score => score;
    [SerializeField] private float powerUpTimer;

    private void Start()
    {
        StartCoroutine(corDestrBonus());
    }
    IEnumerator corDestrBonus()
    {
        yield return new WaitForSeconds(100f);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<InputPlayer>();
        
        if (player)
        {
            PlayerSatistic.Instance.ShowScore();
            player.UseTimerSpeed(3);
            Destroy(gameObject);
        }
    }
}
