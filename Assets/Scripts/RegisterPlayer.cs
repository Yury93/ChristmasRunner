using UnityEngine;

public class RegisterPlayer : MonoBehaviour
{
    private LevelGenerator lvlGen;
    /// <summary>
    /// события для создания уровня 
    /// </summary>
    public delegate void PlayerFind();
    public event PlayerFind OnGenerate;

    private void Start()
    {
        GetComponentInParent<LevelGenerator>();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnGenerate();
        }
    }
}
