using UnityEngine;

[ExecuteAlways] // �����Ϳ� �÷��� ��� ��ο��� ����
public class GridDrawer : MonoBehaviour
{
    public int gridWidth = 10;    // �׸����� ���� �� ����
    public int gridHeight = 10;   // �׸����� ���� �� ����
    public float cellSize = 1f;   // �� ���� ũ��
    public Color gridColor = Color.green; // �׸��� �� ����

    void OnDrawGizmos()
    {
        Gizmos.color = gridColor;
        Vector3 origin = transform.position;

        // ���μ� �׸���
        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 start = origin + new Vector3(x * cellSize, 0, 0);
            Vector3 end = start + new Vector3(0, 0, gridHeight * cellSize);
            Gizmos.DrawLine(start, end);
        }

        // ���μ� �׸���
        for (int z = 0; z <= gridHeight; z++)
        {
            Vector3 start = origin + new Vector3(0, 0, z * cellSize);
            Vector3 end = start + new Vector3(gridWidth * cellSize, 0, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}
