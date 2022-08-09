using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcg : MonoBehaviour
{
	[SerializeField] int width, height;
	[SerializeField] int minHeight, maxHeight;
	[SerializeField] int repeatNum, spikeSpawnHeight;
	[SerializeField] GameObject dirt, grass, obstacle1, obstacle2, spike, coin;
    // Start is called before the first frame update
    void Start()
    {
		Generation();
    }

	void Generation()
	{
		int repeatValue = 0;
		for (int x=0; x<width; x++)
		{
			if(repeatValue == 0)
			{
				height = Random.Range(minHeight, maxHeight);
				GenerateFlatPlatform(x);
				repeatValue = repeatNum;
			}
			//int minHeight = height - 1;
			//int maxHeight = height + 2;
			else
			{
				GenerateFlatPlatform(x);
				repeatValue--;
			}

		}
	}

	void GenerateFlatPlatform(int x)
	{
		for (int y=0; y<height; y++)
		{
			spawnObject(dirt, x, y);
		}
			
		if(height < 7)
		{
			spawnObject(grass, x, height);
			spawnObject(spike, x, height+1);
		}
		else
		{
			spawnObject(grass, x, height);
		}


	}
	void spawnObject(GameObject obj, int width, int height)
	{
		obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
		obj.transform.parent = this.transform;
	}
    // Update is called once per frame
}
