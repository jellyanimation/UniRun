using UnityEngine;

public class Platform : MonoBehaviour
{
    //�������μ� �ʿ��� ������ ���� ��ũ��Ʈ
    public GameObject[] obstacles; //��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� ĳ���Ͱ� ��Ҵ°�

    //������Ʈ�� ȣ��ȭ�� ������ �Ź� ����Ǵ� �޼���
    private void OnEnable()
    {
        //������ �����ϴ� ó��



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��




    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
