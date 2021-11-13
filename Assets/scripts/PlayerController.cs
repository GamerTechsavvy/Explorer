using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public Animator anim;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public float jumpForce;

    public bool jump;

    public Camera cam;

    public float leftMaxDir;
    public float rightMaxDir;
    public Vector3 leftFixCamPos;
    public Vector3 rightFixCamPos;

   // public AudioSource gameSound;
    public AudioSource coinSound;

    public Text scoreText;
    public Text lives;
    


    [SerializeField] Vector3 offset;

  public   GameObject gate;
    public GameObject key;

    GameManager gm;

    private void Awake()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        lives = GameObject.Find("Live").GetComponent<Text>();
        this.offset = new Vector3(7f, 0.5f, 0);
       
        this.jump = false;
        this.cam = Camera.main;
        this.coinSound = GetComponent<AudioSource>();
        // gameSound = GetComponent<AudioSource>(); 
       this.gate = GameObject.Find("Gate");
        this.gate.gameObject.SetActive(false);
        this.gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        this.cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y , -10) + this.offset;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
       this.rb = GetComponent<Rigidbody2D>();
        this.sr = GetComponent<SpriteRenderer>();


        // gameSound.Play();
    }

    // Update is called once per frame
    void Update()

    {

        //scoreText.SetText("Score : " + score);
       // print("12 = " + GameManager.instance.score);
        this.scoreText.text = "Score : " +GameManager.instance.score;
        this.lives.text = "Lives : " +GameManager.instance.lives;
       

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.sr.flipX = false;
            this.anim.SetInteger("walking", 1);
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.sr.flipX = true;
            this.anim.SetInteger("walking", 1);
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            this.anim.SetInteger("walking", 0);
        }
        if(transform.position.y <  -6  && gm.lives > 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Destroy(this.gameObject);
            gate.gameObject.SetActive(true);
            gm.playerInstance = null;
            gm.SpawnPlayer();
            

            gm.lives--;
            
        }
        if( gm.lives == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(4);
        }
      // if player goes below -6 lose life
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)  && !jump)
        {
            this.jump = true;
            this.anim.SetInteger("jump", 1);
            this.rb.velocity = Vector2.up * jumpForce;
        }

    }

    public void LateUpdate()
    {
        if (this.transform.position.x > 0 && this.transform.position.x < 58)
        {
            Vector3 playerPos = transform.position;
            playerPos.z = -10;
           playerPos.y = 0;
            this.cam.transform.position = playerPos;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "platform")
        {
            jump = false;
            anim.SetInteger("jump", 0);
        }
       
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            GameManager.instance.score = GameManager.instance.score + 1;
            coinSound.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Key")
        {
            gate.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Gate")
        {
            
            string name = SceneManager.GetActiveScene().name;

            if(name == "Level-1")
            {
                SceneManager.LoadScene(2);
              
            }
            if (name == "Level-2")
            {
                SceneManager.LoadScene(3);
               
            }
            if (name == "Level-3")
            {
                SceneManager.LoadScene(5);
            }


            if (jump)
            {
                jump = false;
            }

        }
    }


}
