using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("�׸��� ����")]
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float cellSize = 1f;

    // Ư�� �׸��� ��ǥ�� ���� ��ǥ�� ��ȯ�մϴ�.
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, 0, y * cellSize);
    }

    // ���� ��ǥ�� �׸��� ��ǥ�� ��ȯ�մϴ�.
    public Vector2Int GetGridCoordinates(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int y = Mathf.RoundToInt(worldPosition.z / cellSize);
        return new Vector2Int(x, y);
    }

    // �׸��� ��ǥ�� �ش��ϴ� ���� �߾� ��ġ�� ��ȯ�մϴ�.
    public Vector3 GetCellCenter(Vector2Int coordinates)
    {
        Vector3 worldPos = GetWorldPosition(coordinates.x, coordinates.y);
        return worldPos + new Vector3(cellSize / 2, 0, cellSize / 2);
    }
}
