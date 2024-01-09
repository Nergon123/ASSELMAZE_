using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterMenu : MonoBehaviour
{
	
	public Button C1;
	public Button C2;
	public Button C3;
	public Button C4;
	public Button Back;
    // Start is called before the first frame update
    void Start()
    {
    	C1.onClick.AddListener(Chapter1);
    	C2.onClick.AddListener(Chapter2);
    	C3.onClick.AddListener(Chapter3);
    	C4.onClick.AddListener(Chapter4);
    	Back.onClick.AddListener(BackToMenu);
    	switch (PlayerPrefs.GetInt("CHAPTER",1)){
    		case 1:
    			C1.interactable =true;
    			C2.interactable =false;
    			C3.interactable =false;
    			C4.interactable =false;
    			break;    		
    		case 2:
    			C1.interactable =true;
    			C2.interactable =true;
    			C3.interactable =false;
    			C4.interactable =false;
    			break;
        	case 3:
    			C1.interactable =true;
    			C2.interactable =true;
    			C3.interactable =true;
    			C4.interactable =false;
    			break;
    		case 4:
    			C1.interactable =true;
    			C2.interactable =true;
    			C3.interactable =true;
    			C4.interactable =true;
    			break;
    		
    	}
    }

    void Chapter1(){
    	SceneManager.LoadScene("LEVEL1");
    }
     void Chapter2(){
    	SceneManager.LoadScene("LEVEL21");
    }
     void Chapter3(){
    	
    }
     void Chapter4(){
    	
    }
    void BackToMenu(){
    	SceneManager.LoadScene("Menu");
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
