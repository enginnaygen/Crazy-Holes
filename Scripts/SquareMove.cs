using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SquareMove : MonoBehaviour
{
    Rigidbody2D _rb;
    public static float jump = 8.5f;
    public bool _squareJump;
    public static int _score,_highScore;
    //[SerializeField]int _deathCount;
    Animator _animator;
    [SerializeField]Text text,highScoreText;
    [SerializeField] GameObject restart, quit, highscore, obsticleSpawner;
    [SerializeField] Color color1, color2, squareColor1,squareColor2;
    SpriteRenderer _spriteRenderer;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.HasKey("highscore"))
        {
            _highScore = PlayerPrefs.GetInt("highscore");
            highScoreText.text = "High Score:" + _highScore;
        }
        else
            _highScore = 0;
    
}
private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _squareJump = true;
            //Debug.Log("Tuþa Basýldý");
        }
        text.text = "Score:" + _score; 

        if(jump > 0)
        {
            Camera.main.backgroundColor = color1;
            _spriteRenderer.color = squareColor2;
        }
        else if(jump < 0)
        {
            Camera.main.backgroundColor = color2;
            _spriteRenderer.color = squareColor1;

        }
    }
    void FixedUpdate()
    {
        SquareMoves();
        _animator.SetFloat("GravityScale", _rb.gravityScale);
    }

    void SquareMoves()
    {
        if(_squareJump)
        {
            _rb.velocity = new Vector2(0, jump);     
            _squareJump =false;
            //Debug.Log("Zýpladý");
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _score++;
        if (_score > _highScore)
        {
            _highScore = _score;
            highScoreText.text = "High Score:" + _highScore;
            PlayerPrefs.SetInt("highscore", _highScore);

        }
        //Debug.Log("Skor 1 Arttý");
        if (collision.gameObject.tag == "ScorePoint")
        {
            if (_score > 0)
            {
                if (_score % 5 == 0)
                {
                    _rb.gravityScale *= -1;
                    jump *= -1;
                }
            }      
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            

            restart.SetActive(true);
            quit.SetActive(true);
            highscore.SetActive(true);
            Time.timeScale = 0;
        }
    }
    }

