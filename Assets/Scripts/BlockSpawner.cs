using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private BlockProperties[] blockProperties;
    private void OnEnable()
    {
        Events.OnBlockSpawned.AddListener(StartDetectingNumbers);
    }

    private void OnDisable()
    {
        Events.OnBlockSpawned.RemoveListener(StartDetectingNumbers);
    }

    private void Start()
    {
        blockProperties = BlockPropertiesData.Instance.GetBlockProperties();
    }

    private void StartDetectingNumbers()
    {
        StartCoroutine(DetectNumbersFromKeyboard());
    }

    private IEnumerator DetectNumbersFromKeyboard()
    {
        while (true)
        {
            if (StateManager.Instance.CurrentState == GameState.SpawnBlock)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    SpawnBlockFromBlockProperties(0);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    SpawnBlockFromBlockProperties(1);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    SpawnBlockFromBlockProperties(2);
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    SpawnBlockFromBlockProperties(3);
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    SpawnBlockFromBlockProperties(4);
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    SpawnBlockFromBlockProperties(5);
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    SpawnBlockFromBlockProperties(6);
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    SpawnBlockFromBlockProperties(7);
                }
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    SpawnBlockFromBlockProperties(8);
                }
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    SpawnBlockFromBlockProperties(9);
                }
                
            }

            yield return null;
        }
    }

    private void SpawnBlockFromBlockProperties(int index)
    {
        Block block = Instantiate(blockPrefab, transform.position, Quaternion.identity);
        block.SetBlockProperties(blockProperties[index]);
        block.SetCurrentBlockPropertiesIndex(index);
        StateManager.Instance.ChangeState(GameState.Dragging);
    }
}