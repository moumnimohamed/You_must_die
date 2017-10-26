
using UnityEngine;
using UnityEngine.UI;
public class score_manager : MonoBehaviour {

    public GameObject ads_panel ;
     public Text score;
    public Text [] hightscore;
    public  int number = 0;

    public int score_to_share;

   public int a;
	// Use this for initialization

      public AudioSource audi;
       

	void Start () {
		audi = GetComponent<AudioSource>();
	hightscore[0].text=PlayerPrefs.GetInt("Hight").ToString();
    hightscore[1].text = PlayerPrefs.GetInt("Hight").ToString();
    score_to_share = PlayerPrefs.GetInt("Hight");
}


    void Update()
    {
       

    }

    public void Addscore()
    {
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("Hight", 0))
        {
            PlayerPrefs.SetInt("Hight", number);
            hightscore[0].text = number.ToString();
            hightscore[1].text = number.ToString();


        }
    }

public void Rest (){
	
	PlayerPrefs.DeleteKey("Hight");
}

public  void gift_score()
{ 
    audi.Play();

     a = PlayerPrefs.GetInt("Hight")+50;
    
    PlayerPrefs.SetInt("Hight", a);
    hightscore[1].text = PlayerPrefs.GetInt("Hight").ToString();

    ads_panel.SetActive(false);
}

}