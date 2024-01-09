using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BitTask : MonoBehaviour
{
	public GameObject window;
	public GameObject gate;
    public Button[] bits;
    public Button close;
    public bool[] bitss;
    public Text status;
    public Text[] bitsText;
	public int user;
    int target;
    // Start is called before the first frame update
    void Start()
    {
		close.onClick.AddListener(delegate{window.SetActive(false);Time.timeScale = 1.0f;}); 
		
        bits[0].onClick.AddListener(delegate{
			bitss[0] = !bitss[0];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[1].onClick.AddListener(delegate{
			bitss[1] = !bitss[1];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[2].onClick.AddListener(delegate{
			bitss[2] = !bitss[2];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[3].onClick.AddListener(delegate{
			bitss[3] = !bitss[3];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[4].onClick.AddListener(delegate{
			bitss[4] = !bitss[4];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[5].onClick.AddListener(delegate{
			bitss[5] = !bitss[5];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[6].onClick.AddListener(delegate{
			bitss[6] = !bitss[6];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[7].onClick.AddListener(delegate{
			bitss[7] = !bitss[7];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});
			        bits[8].onClick.AddListener(delegate{
			bitss[8] = !bitss[8];
			user = GetBitSum(bitss[0],bitss[1],bitss[2],bitss[3],bitss[4],bitss[5],bitss[6],bitss[7],bitss[8]);
			output();
			});   
	for(int i=0;i<9;i++){
		Debug.Log(i.ToString());
	}
        target = randomm();       
    }
	int randomm(){
		bool[] temp = {true,true,true,true,true,true,true,true,true};
		for(int i=0;i<9;i++){
			int a = Random.Range(0,2);
			bool temp1 = false;
			if(a == 0){temp1 = false;}
			if(a == 1){temp1 = true;}
			temp[i] = temp1;
			Debug.Log(a.ToString());
		}
		return GetBitSum(temp[0],temp[1],temp[2],temp[3],temp[4],temp[5],temp[6],temp[7],temp[8]);
		
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Player"){
			window.SetActive(true);
			Time.timeScale = 0.0f;
		}
	}

    void output(){
        for(int i=0;i<9;i++){
            if(bitss[i]){
                bits[i].GetComponentInChildren<Text>().text = "1";     
            }
            else{
                bits[i].GetComponentInChildren<Text>().text = "0";
            }
        }
    }
    int GetBitSum(bool b256,bool b128,bool b64,bool b32,bool b16, bool b8,bool b4,bool b2,bool b){
        int sum = 0;
        if(b256){
           sum += 256; 
        }
        if(b128){
            sum +=128;
        }
        if(b64){
            sum +=64;
        }
        if(b32){
            sum +=32;
        }
        if(b16){
            sum +=16;
        }
        if(b8){
            sum +=8;
        }
        if(b4){
            sum +=4;
        }
        if(b2){
            sum +=2;
        }
        if(b){
            sum++;
        }
        
        return sum;
    }

    // Update is called once per frame
    void Update()
    {
        status.text = "Current:" + user.ToString() + "\nTarget:" + target.ToString();
		if(user == target){
			window.SetActive(false);
			gate.SetActive(false);
			Time.timeScale= 1f;
		}
    }
}
