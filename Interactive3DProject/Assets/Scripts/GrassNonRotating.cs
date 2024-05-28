using UnityEngine;

public class GrassNonRotating : MonoBehaviour
{
    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        if (terrain)
        {
            DetailPrototype[] detailPrototypes = terrain.terrainData.detailPrototypes;
            foreach (DetailPrototype detailPrototype in detailPrototypes)
            {
                detailPrototype.usePrototypeMesh = true; // 确保使用 Mesh 而不是草贴图
                detailPrototype.prototype.transform.rotation = Quaternion.identity; // 将草的旋转重置
            }
            terrain.terrainData.detailPrototypes = detailPrototypes;
        }
    }
}
