using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Transform sceneParent;

    public void OnDrop(PointerEventData item)
    {        
        //Debug.Log("OnDrop");
        if (item.pointerDrag != null && transform.childCount == 0)
        {            
            item.pointerDrag.transform.SetParent(sceneParent);
            item.pointerDrag.transform.position = transform.position;
        }        
    }
}
