using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    int hp = 100;
    public static int weaponPoint = 5;
    float delta = 0;
    float span = 0.2f;
    static public bool playerGoal = false;
    static public bool playerGameOver = false;

    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    Image hpFill;

    [SerializeField]
    Image[] weaponPointImage;

    [SerializeField]
    Image mainWeaponImage;

    [SerializeField]
    Image subWeaponImage;

    [SerializeField]
    Sprite[] weaponSprites;

    [SerializeField]
    Slider searchSlider;

    [SerializeField]
    GameObject gameOverImage;

    [SerializeField]
    SpriteRenderer goal;

    [SerializeField]
    Sprite[] goalSprites;

    PlayerMove playerMove;

    WeaponControl weaponControl;

    AudioSource audioSource;

    [SerializeField]
    Text mainWeaponText;

    [SerializeField]
    Text subWeaponText;

    [SerializeField]
    AudioClip[] audioClips ;

    int a = 4;

    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        weaponControl = GetComponent<WeaponControl>();
        audioSource = GetComponent<AudioSource>();
        goal.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        playerGoal = false;
        playerGameOver = false;
        weaponPoint = 5;
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerGoal)
        {
            transform.position = pos;
        }
    }

    public void Damage(int damage)
    {
        audioSource.PlayOneShot(audioClips[0]);
        Debug.Log(weaponControl.NoDamage());
        if (!weaponControl.NoDamage())
        {
            hp -= damage;
            if (hp <= 25)
            {
                hpFill.color = new Color32(255, 0, 0, 255);
            }
            else if (hp <= 50)
            {
                hpFill.color = new Color32(255, 255, 0, 255);
            }
            else
            {
                hpFill.color = new Color32(0, 255, 0, 255);
            }
            playerMove.KnockBack();
            hpSlider.value = (hp * 0.01f);

            if (hp <= 0)
            {
                GameOver();
            }
        }
    }

    public void WeaponPoint()
    {
        if (weaponPoint <= 5)
        {
            for (int i = 0; i < weaponPoint; i++)
            {
                weaponPointImage[i].color = new Color32(255, 0, 0, 255);
            }
            for (int j = weaponPoint; j < weaponPointImage.Length; j++)
            {
                weaponPointImage[j].color = new Color32(142, 142, 142, 255);
            }
        }

    }

    public void WeaponTimes(int main, int sub)
    {
        mainWeaponText.text = "" + main;
        subWeaponText.text = "" + sub;
    }

    public void SearchGauge(float searchGauge)
    {
        searchSlider.value = (searchGauge * 0.01f);
    }

    public void GetWeapon(int subWeapon, int mainWeapon)
    {
        mainWeaponImage.sprite = weaponSprites[mainWeapon];
        subWeaponImage.sprite = weaponSprites[subWeapon];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GameOver")
        {
            hp = 0;
            Damage(0);
            playerGameOver = true;

        }
        if(collision.gameObject.tag == "enemy")
        {
            Damage(10);
        }
        
        if (collision.gameObject.tag == "EnemyArrow")
        {
            Damage(20);
        }
        if(collision.gameObject.tag == "Goal")
        {
            goal.transform.localScale = new Vector3(0.18f, 0.18f, 1f);
            goal.sprite = goalSprites[1];
            playerGoal = true;
            pos = transform.position;
        }
    }

    void GameOver()
    {
        gameOverImage.SetActive(true);
        gameObject.SetActive(false);
    }
}
