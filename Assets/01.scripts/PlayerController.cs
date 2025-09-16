using UnityEngine;



//playerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{


    public AudioClip deathclip; //��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; //���� ��

    private int jumpCount = 0; //���� ���� Ƚ��
    private bool isGrounded = false; //�ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; //��� ����

    private Rigidbody2D playerRigidbody; //����� ������ٵ� ������Ʈ
    private Animator animator; //����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; //����� ����� �ҽ� ������Ʈ




    private void Start()
    {
        //�ʱ�ȭ

        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        //����� �Է��� �����ϰ� �����ϴ� ó��
        if (isDead)
        {
            //��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }

        //���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ���� (0,0)�� ����
            playerRigidbody.linearVelocity = Vector2.zero;
            //������ٵ� �������� ���� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
        }

        else if (Input.GetMouseButtonUp(0) && playerRigidbody.linearVelocity.y >0)
        {
            //���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y ���� ������(���� ��� ��)
            //���� �ӵ��� �������� ���� 
            // playerRigidbody.velocity *= 0.5f;
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }

        //�ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);


    }



    private void Die()
    {
        //���ó��(Ŀ���� �޼���)

        //�ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");

        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathclip���� ����
        playerAudio.clip = deathclip;


        //��� ȿ���� ���
        playerAudio.Play();

        //�ӵ��� ����(0,0)�� ����
        playerRigidbody.linearVelocity = Vector2.zero;

        //��� ���¸� true�� ����
        isDead = true;



    }



    private void OnTriggerEnter2D(Collider2D other) //(Collider2D collision)
    {
        //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
        if (other.tag == "Dead" &&!isDead)   //if (collision.tag == "Dead" &&!isDead)
        {
            //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die()����
            Die();
        }



    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ٴڿ� ������� �����ϴ� ó��
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� �����ϴ� ó��
    }
}
