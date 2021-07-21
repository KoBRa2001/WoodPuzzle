using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Transform dragParent;
    private Transform startParent;
    private Vector3 startPosition;    
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
   
    public void OnBeginDrag(PointerEventData touch)
    {
        startParent = transform.parent;
        transform.SetParent(dragParent);
        startPosition = transform.position;
        Debug.Log("OnBeginDrag");
        offset = transform.position - (Vector3)touch.position;
        offset.z = 0f;
        canvasGroup.blocksRaycasts = false;        
    }

    public void OnDrag(PointerEventData touch)
    {
        //Debug.Log("OnDrag");
        transform.position = Camera.main.ScreenPointToRay(touch.position).origin;
    }    

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        if (transform.parent == dragParent)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
        }
        canvasGroup.blocksRaycasts = true;
    }
}
