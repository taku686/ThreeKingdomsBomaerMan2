using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private readonly Dictionary<Tuple<float, float>, Area> map = new();
    private const float MaxX = 8;
    private const float MaxZ = 5;
    private const float MinX = -8;
    private const float MinZ = -5;

    public enum Area
    {
        Block,
        BreakingBlock,
        Bomb,
        Explosion,
        None,
        Exception
    }

    private void Start()
    {
        AddBlockArea();
        AddNoneArea();
    }

    private void AddBlockArea()
    {
        for (var i = -7; i < 8; i += 2)
        {
            for (var j = -4; j < 5; j += 2)
            {
                AddMap(Area.Block, i, j);
            }
        }

        AddMap(Area.Block, -8, 3);
        AddMap(Area.Block, -7, 3);
        AddMap(Area.Block, -6, 3);
        AddMap(Area.Block, -5, 3);
        AddMap(Area.Block, -5, 5);
    }

    private void AddNoneArea()
    {
        for (int i = (int)MinX; i <= (int)MaxX; i++)
        {
            for (int j = (int)MinZ; j <= MaxZ; j++)
            {
                var point = new Tuple<float, float>(i, j);
                if (map.ContainsKey(point))
                {
                    continue;
                }

                AddMap(Area.None, i, j);
            }
        }
    }

    public void AddMap(Area area, float x, float z)
    {
        if (x > MaxX || x < MinX || z > MaxZ || z < MinZ)
        {
            return;
        }

        var point = new Tuple<float, float>(x, z);
        if (map.ContainsKey(point))
        {
            if (area == Area.Explosion)
            {
                if (map[point] == Area.Block)
                {
                    return;
                }
            }
        }

        map[point] = area;
    }

    public void RemoveMap(float x, float z)
    {
        var point = new Tuple<float, float>(x, z);
        if (!map.ContainsKey(point))
        {
            return;
        }

        if (map[point] == Area.Block)
        {
            return;
        }

        map[point] = Area.None;
    }

    public void ClearMap()
    {
        map.Clear();
    }

    public Area GetArea(float x, float z)
    {
        var point = new Tuple<float, float>(x, z);
        if (!map.ContainsKey(point))
        {
            return Area.Exception;
        }

        return map[point];
    }

    public Tuple<float, float> GetNearestNoneArea(Vector3 startPos)
    {
        var nearestPos = new Tuple<float, float>(0, 0);
        var nearestDis = float.MaxValue;
        foreach (var point in map.Where(x => x.Value == Area.None))
        {
            var end = new Vector3(point.Key.Item1, startPos.y, point.Key.Item2);
            var dis = Vector3.Distance(startPos, end);
            if (nearestDis > dis)
            {
                nearestDis = dis;
                nearestPos = point.Key;
            }
        }

        return nearestPos;
    }
}