using System.Collections;
using UnityEngine;
 public class Obstacle : MonoBehaviour
    {
    private void Start()
    {
        StartCoroutine(CorDestroyObst());
    }
    IEnumerator CorDestroyObst()
    {
        yield return new WaitForSeconds(100f);
        Destroy(gameObject);
    }
        
}