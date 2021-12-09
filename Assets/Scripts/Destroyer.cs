using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Destroyer : MonoBehaviour
{
    public delegate void Destr();
    public event Destr OnDestroyObj;
    private bool death = false;
    public bool Death => death;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            OnDestroyObj();
            var p = other.gameObject.GetComponent<InputPlayer>();
            p.ApplyDamage(1);
            Destroy(other.gameObject);
        }
    }
    public void DeathActive(bool active)
    {
        active = true;
    }
}
