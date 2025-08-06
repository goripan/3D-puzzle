using Unity.VisualScripting;
using UnityEngine;

public class Sample : MonoBehaviour
{
    bool isMove=true;

    private bool isFixed = false;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isMove = true;
            rb.isKinematic = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
            rb.isKinematic = true;
        }
        Debug.Log(isFixed);
        if (isMove)
        {
            // カーソル位置を取得
            Vector3 mousePosition = Input.mousePosition;
            // カーソル位置のz座標を10に
            mousePosition.z = 10;
            // カーソル位置をワールド座標に変換
            Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
            // GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入
            target.z = 0;
            transform.position = target;
            //Debug.Log(target);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (
            Mathf.Abs(transform.position.x - other.transform.position.x) < 0.8f &&
            Mathf.Abs(transform.position.y - other.transform.position.y) < 0.8f &&
            Mathf.Abs(transform.position.z - other.transform.position.z) < 0.8f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("左クリック");
                rb.isKinematic = false;
                //isMove = true;
            }
            else
            {
                transform.position = other.transform.position;
                rb.isKinematic = true;
                //isMove = false;
                //isFixed = true;
                Debug.Log("in");
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*
        if (!isFixed) // 固定されていない場合だけ isMoveを戻す
        {
            isMove = false;
            isFixed = false;
            if (Input.GetMouseButton(0))
            {
                rb.isKinematic = false;
                isFixed = true;
                isMove = true;
            }
            Debug.Log("out");
        }*/
    }
}
