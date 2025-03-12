using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [Header("���� ����")]
    public GridManager gridManager;      // �׸��� ��� ������Ʈ ����
    public LayerMask terrainLayer;       // �ͷ��ο� ������ ���̾�
    public GameObject buildingPrefab;    // ��ġ�� �ǹ� ������
    public Camera cam;

    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� �� ó��
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("������");

            // �ͷ��� ���̾ Raycast
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
            {
                Vector3 hitPoint = hit.point;
                Debug.Log($"{hitPoint} ����");

                // �׸��� ��ǥ�� ��ȯ ��, �� �߾� ��ġ ���
                Vector2Int gridCoord = gridManager.GetGridCoordinates(hitPoint);
                Vector3 placementPosition = gridManager.GetCellCenter(gridCoord);

                // �ǹ� ��ġ (ȸ���̳� �߰� ������ �ʿ信 ���� Ȯ��)
                Instantiate(buildingPrefab, placementPosition, Quaternion.identity);
                Debug.Log("��ġ?");
            }
        }
    }
}
