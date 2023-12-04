//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//[ExecuteAlways]
//public class RaycastTest : MonoBehaviour
//{

//   public float m_MaxDistance = 1f;
    

//    Collider m_collider;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(Physics.BoxCast(transform.position,transform.lossyScale,transform.forward * 0.5f, Quaternion.identity, m_MaxDistance)){

//            Debug.Log("Hit");

//        }
//    }

//    private void OnDrawGizmos()
//    {
//        DrawBoxCast(transform.position, transform.position + m_MaxDistance * transform.forward, transform.lossyScale, transform.rotation);



//    }

//    void DrawBoxCast(Vector3 start, Vector3 end, Vector3 size, Quaternion rotation)
//    {
//        Gizmos.color = Color.blue;

//        Matrix4x4 currentMatrix = Gizmos.matrix;

//        Gizmos.matrix = Matrix4x4.TRS(start, rotation, size);
//        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
//        Gizmos.matrix = Matrix4x4.TRS(end, rotation, size);
//        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);


//        Vector3 x = Vector3.right * size.x * 0.5f;
//        Vector3 y = Vector3.up * size.y * 0.5f;
//        Vector3 z = Vector3.forward * size.z * 0.5f;
//        Gizmos.matrix  = Matrix4x4.TRS(start,rotation, Vector3.one);
//        Gizmos.DrawRay(Vector3.zero - x - y - z, Vector3.forward * m_MaxDistance);
//        Gizmos.DrawRay(Vector3.zero - x + y - z, Vector3.forward * m_MaxDistance);
//        Gizmos.DrawRay(Vector3.zero + x - y - z, Vector3.forward * m_MaxDistance);
//        Gizmos.DrawRay(Vector3.zero + x + y - z, Vector3.forward * m_MaxDistance);

//        Gizmos.matrix = currentMatrix;

//    }


