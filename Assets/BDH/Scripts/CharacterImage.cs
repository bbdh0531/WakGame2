using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterImage : MonoBehaviour
{
    public Image character_imgae;
    public bool stage_clear = true;
    public Transform tr;

    public void SetImage(Sprite _character_image)
    {
        character_imgae.sprite = _character_image;
    }
}
