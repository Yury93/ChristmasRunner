
using UnityEngine;
using UnityEngine.UI;

public class PlayerSatistic : SingletonBase<PlayerSatistic>
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int score = 0;
    [SerializeField] private int hp = 3;
    [SerializeField]  private Text Hp;
    private int record;
    [SerializeField] private Text recordText;
    private void Start()
    {
        GameManager.Instance.HpEdite += ShowHP;
        record = PlayerPrefs.GetInt("Record");
        recordText.text = "Record: " + record.ToString();
    }
    public void ShowScore()
    {
        score += 1;
        scoreText.text = "Pack: "+ score.ToString();
        if(record < score)
        {
            RecordScore(score);
        }
    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Pack: " + score.ToString();
    }
    public void ShowHP()
    {
        hp -= 1;
        Hp.text = "HP: " + hp.ToString();
    }
    public void ResetHP()
    {
        hp = 3;
        Hp.text = "HP: " + hp.ToString();
        score = 0;
        scoreText.text = "Pack: " + score.ToString();
    }
    public void RecordScore(int newScore)
    {
        record = newScore;
        recordText.text = "Record: " + record.ToString();
        PlayerPrefs.SetInt("Record", record);
    }
}
