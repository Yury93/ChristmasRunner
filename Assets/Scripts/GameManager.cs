using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private GameObject MenuController;
    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] private GameObject prefabAliens;
    [SerializeField] private SyncTransform camera;
    [SerializeField] private GameObject PlayerTransform;
    [SerializeField] private GameObject AlienTransform;
    private GameObject newPlayer;
    [SerializeField] private Destroyer destr;
    public GameObject NewPlayer => newPlayer;
    /// <summary>
    /// жизни игрока
    /// </summary>
    public int hpReserv = 3;

    public delegate void HpController();
    public event HpController HpEdite;

    private void Start()
    {
        destr.OnDestroyObj += CreateNewPlay;
    }

    private void CreateNewPlay()
    {
        newPlayer = Instantiate(prefabPlayer, PlayerTransform.transform.position, Quaternion.identity);
        var newAlien = Instantiate(prefabAliens, AlienTransform.transform.position, Quaternion.identity);
        newAlien.GetComponent<Alien>().SetModelPlayer(newPlayer);
        newAlien.GetComponent<Alien>().Active(false);
        var player = newPlayer.GetComponent<InputPlayer>();
        player.GetComponent<InputPlayer>().enabled = true;
        hpReserv -=1 ;
        HpEdite();
        if (hpReserv < 0)
        {
            SceneManager.LoadScene(0);
        }
        camera.SetTarget(newPlayer);
    }
}
