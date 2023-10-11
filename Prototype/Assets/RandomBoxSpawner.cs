using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] GameObject circlePrefab;

    void Start (){
        SpawnBoxesOverTime();
    }

    void SpawnBoxesOverTime(){
        StartCoroutine(SpawnBoxesOverTimerRoutine());

        IEnumerator SpawnBoxesOverTimerRoutine(){

            int shapeType = 1;

            while(true){
                yield return new WaitForSeconds(1);

                if(shapeType == 1){
                    GameObject newBox = Instantiate(boxPrefab, new Vector3(Random.Range(-5,5),8,0),Quaternion.identity);
                    Destroy(newBox,10);
                    shapeType = 2;
                } else if(shapeType == 2){
                    GameObject newBox = Instantiate(boxPrefab, new Vector3(Random.Range(-5,5),8,0),Quaternion.identity);
                    Destroy(newBox,10);
                    shapeType = 3;
                } else if(shapeType == 3){
                    GameObject newCircle = Instantiate(circlePrefab, new Vector3(Random.Range(-5,5),8,0),Quaternion.identity);
                    Destroy(newCircle,10);
                    shapeType = 1;
                }

                //GameObject newBox = Instantiate(boxPrefab, new Vector3(Random.Range(-5,5),8,0),Quaternion.identity);
                //Destroy(newBox,10);
            }

            yield return null;
        }

    }

}
