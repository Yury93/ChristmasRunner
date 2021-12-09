using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// работает в связке с регистром
/// </summary>
public class LevelGenerator : MonoBehaviour
{
    /// <summary>
    /// Длина уровня
    /// </summary>
    [SerializeField]private float lengthLvl;

    [SerializeField] private RegisterPlayer register;
    [SerializeField] private LevelGenerator ground;
    [SerializeField] private GameObject parentPosition;
    [SerializeField] private Destroyer destr;


    void Start()
    {
        ground = GetComponent<LevelGenerator>();
        var bounds = GetComponent<Collider>().bounds;
        lengthLvl = bounds.size.z;
        register.OnGenerate += GenerateActiveted;
        StartCoroutine(corDetroyGround());
    }

    public void GenerateActiveted()
    {
        StartCoroutine(corCreaterGround());
    }
    IEnumerator corDetroyGround()
    {
        yield return new WaitForSeconds(400f);
        Destroy(gameObject);
    }
    IEnumerator corCreaterGround()
    {
        yield return new WaitForSeconds(1f);
        var s = lengthLvl - register.transform.position.z;//Расстояние до конца уровня
        Vector3 placeGenertion = new Vector3(transform.position.x, transform.position.y, transform.position.z + lengthLvl);
        if (destr.Death == true)
        {
            SceneManager.LoadScene(0);
        }
        ground = Instantiate(ground, placeGenertion, Quaternion.identity);
        ground.transform.parent = parentPosition.transform;
        
        StartCoroutine(corDetroyGround());
    }
}
