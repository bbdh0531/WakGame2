using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Sprite> list_image = new List<Sprite>();
    public RectTransform parent;
    public int enter;
    public float position_x;
    public float position_y;
    public CharacterImage prefabs;

    Vector3 dir_pos;
    int count;
    List<CharacterImage> character_Image_list = new List<CharacterImage>();

    CharacterImage ImageCreate()
    {
        prefabs = Resources.Load<CharacterImage>("Characterimage");
        CharacterImage tmp = Instantiate<CharacterImage>(prefabs);
        character_Image_list.Add(tmp);
        tmp.SetImage(list_image[0]);
        tmp.transform.SetParent(parent, false);
        count++;
        return tmp;
    }

    void CharacteImageCreate()
    {
        for(int i = 0; i < list_image.Count; i++)
        {
            CharacterImage tmp = ImageCreate();
            dir_pos.Set(position_x, 0f, 0f);
            character_Image_list[i].transform.localPosition = dir_pos;
            //if(enter == count)
            //{
            //    ImageCreate().SetPositionEnter(position_y);
            //    count = 0;
            //}
            //else
            //{
            //    ImageCreate().SetPosition(position_x);
            //}
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacteImageCreate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
