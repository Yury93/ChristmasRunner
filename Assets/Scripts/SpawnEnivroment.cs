using System.Collections;
using UnityEngine;

public class SpawnEnivroment : Factory<Bonus>
{
    /// <summary>
    /// ���������� ��������(������� ����� ������� �������� �� �����)
    /// </summary>
    [SerializeField] private int countObjects;
    [SerializeField] private float timerCreate;
    private void Start()
    {
        StartCoroutine(CorInstance());
    }

    public IEnumerator CorInstance()
    {
        yield return new WaitForSeconds(timerCreate);
        for (int i = 0; i < countObjects; i++)
        {
            GetNewInstance();
        }
    }
}
