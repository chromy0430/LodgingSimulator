using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ġ�� ������Ʈ�� �����͸� �����ϴ� Ŭ����
/// </summary>
public class PlacementData
{
    public List<Vector3Int> occupiedPositions;
    public int ID { get; private set; }
    public int PlacedObjectIndex { get; private set; }


    // KindIndex
    // 0 = �ٴ� ������Ʈ
    // 1 = ���� ������Ʈ
    
    public int kindIndex { get; private set; }

    public PlacementData(List<Vector3Int> occupiedPositions, int id, int placedObjectIndex, int kindOfIndex)
    {
        this.occupiedPositions = occupiedPositions;
        ID = id;
        PlacedObjectIndex = placedObjectIndex;
        kindIndex = kindOfIndex;
    }
}