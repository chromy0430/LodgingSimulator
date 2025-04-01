using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���๰���� �����͸� �����ϴ� ��ũ���ͺ������Ʈ 
/// </summary>
[CreateAssetMenu]
public class ObjectsDatabaseSO : ScriptableObject
{
    public List<ObjectData> objectsData;
}

[Serializable]
public class ObjectData
{
    [field : SerializeField]
    public string Name { get; private set; }
    
    [field : SerializeField]
    public int ID { get; private set; }

    [field : SerializeField]
    public int kindIndex { get; private set; }

    [field: SerializeField] 
    public Vector2Int Size { get; private set; } = Vector2Int.one;
    
    [field : SerializeField]
    public GameObject Prefab { get; private set; }
}
