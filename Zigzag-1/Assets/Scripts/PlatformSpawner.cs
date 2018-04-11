using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {


    public GameObject platform;        //ınstatiate yapmak icin tanimlama;
    public GameObject diamonds;


    Vector3 lastPos;
    float size;
    public bool gameOver;

	// Use this for initialization
	void Start () {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for(int i=0;i<12;i++)
        {
            SpawnPlatforms();
        }
    }
	
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.1f);
    }

	// Update is called once per frame
	void Update () {
		if(GameManager.instance.gameOver==true)
        {
            CancelInvoke("SpawnPlatforms");
        }
	}


    void SpawnPlatforms()
    {
        if(gameOver)
        { return; }
        int rand = Random.Range(0, 6);    // 0 ile 6 arasinda rastgele sayi olustur
        if (rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }
    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos,Quaternion.identity);      //  Instantiate( kopyalancak platform, nereye, dondurulcek yon )

        int rand = Random.Range(0,8);       // diamondi rastgele ekleme kismi
        if(rand==3)
        {
            Instantiate(diamonds, new Vector3(pos.x,pos.y+1,pos.z), diamonds.transform.rotation);                   // diamonds lar platformun icinde olustugu icin yukseltilmesi 1 yuksek olmasi lazim
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);      //  Instantiate( kopyalancak platform, nereye, dondurulcek yon )
        int rand = Random.Range(0, 8);
        if (rand == 3)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
    }
}
