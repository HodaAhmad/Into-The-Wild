using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float walking;
    public float backwards;
    public float rotationSp;
    public float jumpSpeed;

    /*public int hpp = 12;
    public int dmg = 20;
    public bool attack = true;
    public bool bossRange = false;
    public Slider hpUI;
    */
    Vector3 movingDirection = Vector3.zero;
    CharacterController controller;
    int jump;
    float rotation = 0f;
    public float gravity = 20.0f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*hpUI.value = hpp;

        if (hpp == 0)
        {
            Debug.Log("dead");
            Destroy(this);
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
        */
        if (controller.isGrounded) {
           
            if (Input.GetKey(KeyCode.Space)) {
                movingDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                movingDirection = transform.TransformDirection(movingDirection);
                movingDirection = movingDirection * walking;
                movingDirection.y = jumpSpeed;
            }



        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movingDirection = new Vector3(0, 0, 1);
            movingDirection = transform.TransformDirection(movingDirection);
            movingDirection = movingDirection * walking;
            movingDirection.y -= gravity * Time.deltaTime;
            anim.SetBool("Walk", true);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movingDirection = new Vector3(0, 0, -1);
            movingDirection = transform.TransformDirection(movingDirection);
            movingDirection = movingDirection * walking;
            anim.SetBool("Walk", true);

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            movingDirection = new Vector3(0, 0, 0);
            anim.SetBool("Walk", false);

        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            movingDirection = new Vector3(0, 0, 0);
            anim.SetBool("Walk", false);

        }
        /*if (bossRange && attack)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                attack = true;
                if (attack == true)
                {

                    StartCoroutine(PlayerAttacking());

                }
            }
            //anim.SetBool("Attack", false);
        }
        IEnumerator PlayerAttacking()
        {
            anim.SetBool("Attack", true);
            GameObject.FindGameObjectWithTag("Boss").GetComponent<BossScript>().bossHp -= dmg;
            yield return new WaitForSeconds(2);
            anim.SetBool("Attack", false);
            yield return new WaitForSeconds(2);
        }
        */
        controller.Move(movingDirection * Time.deltaTime);
        rotation += Input.GetAxis("Horizontal") * rotationSp * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        movingDirection.y -= gravity * Time.deltaTime;
    }

}