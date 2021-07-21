using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour//, IDropHandler
{   
    [SerializeField]
    private Transform dragParent;
    [SerializeField]
    private GameObject diamond;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && dragParent.transform.childCount == 1 && transform.childCount == 0)
        {            
            GameObject item = dragParent.transform.GetChild(0).gameObject;
            Destroy(item);

            diamond.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            item = Instantiate(diamond, transform);           
        }
    }

    //public void OnDrop(PointerEventData item)
    //{
    //    Debug.Log("OnDrop");
    //    if (item.pointerDrag != null && transform.childCount == 0)
    //    {            
    //        item.pointerDrag.transform.SetParent(transform);
    //        item.pointerDrag.transform.position = transform.position;
    //        Debug.Log(Camera.main.ScreenToWorldPoint(transform.position));
    //        Debug.Log(transform.position);
    //        //item.pointerDrag.transform.localPosition = Vector2.zero;
    //    }
    //}
}
