using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageLoad : MonoBehaviour, IPointerClickHandler
{
    public int stage_id;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(stage_id);
    }
    
}
