using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCircleSpawner : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;

    void Start (){
        SpawnBoxesOverTime();
    }

    void SpawnBoxesOverTime(){
        StartCoroutine(SpawnBoxesOverTimerRoutine());

        IEnumerator SpawnBoxesOverTimerRoutine(){

            while(true){
                yield return new WaitForSeconds(3);
                GameObject newBox = Instantiate(boxPrefab, new Vector3(Random.Range(-5,5),15,0),Quaternion.identity);
                Destroy(newBox,10);
            }

            yield return null;
        }

    }
}
