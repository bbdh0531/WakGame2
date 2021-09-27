using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public List<Sprite> list_image = new List<Sprite>();
    //public List<GameObject> ui_list = new List<GameObject>();
    public Transform[] parent;
    public int page_value;
    public Text gold_text;
    public int[] character_lock;

    int page_state;
    int page_tr_page;
    CharacterImage prefabs;
    int count;
    List<CharacterImage> character_Image_list = new List<CharacterImage>();

    CharacterImage ImageCreate()
    {
        prefabs = Resources.Load<CharacterImage>("Characterimage");
        CharacterImage tmp = Instantiate<CharacterImage>(prefabs);
        character_Image_list.Add(tmp);
        tmp.SetImage(list_image[count]);
        tmp.transform.SetParent(parent[page_tr_page], false);
        count++;
        return tmp;
    }

    void CharacteImageCreate()
    {
        for(int i = 0; i < list_image.Count; i++)
        {
            ImageCreate();
            if (page_value == count)
            {
                page_tr_page++;
            }
        }
    }

    void SetPage()
    {
        for(int i = 0; i < parent.Length; i++)
        {
            parent[i].gameObject.SetActive(false);
        }
    }

    public void NextPage()
    {
        page_state++;
    }

    public void PrevPage()
    {
        page_state--;
    }

    void PageState()
    {
        switch (page_state)
        {
            case 0:
                SetPage();
                parent[0].gameObject.SetActive(true);
                break;
            case 1:
                SetPage();
                parent[1].gameObject.SetActive(true);
                break;
            case 2:
                SetPage();
                parent[2].gameObject.SetActive(true);
                break;
            case 3:
                SetPage();
                parent[3].gameObject.SetActive(true);
                break;
        }
    }

    void SpecialCharacterLock()
    {

        for (int i = 0; i < character_lock.Length; i++)
        {
            if (character_lock[i] >= character_Image_list.Count)
            {
                character_lock[i] = character_Image_list.Count-1;
            }
            character_Image_list[character_lock[i]].stage_clear = false;
        }
    }

    public void SpecialCharacterUnLock()
    {
        switch (Manager.instance.stage_clear)
        {
            case 5:
                character_Image_list[character_lock[0]].stage_clear = true;
                break;
            case 10:
                character_Image_list[character_lock[1]].stage_clear = true;
                break;
            case 15:
                character_Image_list[character_lock[2]].stage_clear = true;
                break;
            case 20:
                character_Image_list[character_lock[3]].stage_clear = true;
                break;
            case 25:
                character_Image_list[character_lock[4]].stage_clear = true;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        CharacteImageCreate();
        SetPage();
        SpecialCharacterLock();
        gold_text.text = Manager.instance.compensation_gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PageState();
    }
}
