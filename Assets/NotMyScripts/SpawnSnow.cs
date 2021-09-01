using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnow : MonoBehaviour
{

    [SerializeField] private GameObject m_Prefab;
    [SerializeField, Range(0.1f, 20f)] private float m_GenerateDelay = 2;
    [SerializeField, Range(1f, 60f)] private float m_DestroyDelay = 10;
    [SerializeField] private bool m_RotateRandomly;
    [SerializeField] private Vector3 m_InitialVelocity = Vector3.zero;
    private float m_LastTime;

    private void Update()
    {
        if (m_LastTime + m_GenerateDelay > Time.time)
        {
            return;
        }

        m_LastTime = Time.time;
        GameObject instance = (GameObject)Instantiate(m_Prefab, transform.position, GetRotation());

        if (!m_InitialVelocity.Equals(Vector3.zero))
        {
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.velocity = m_InitialVelocity;
            }
        }

        Destroy(instance, m_DestroyDelay);
    }

    private Quaternion GetRotation()
    {
        return m_RotateRandomly ? Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)) : transform.rotation;
    }
    //public float objectSize;
    //public int objectsInRow = 5;
    //Vector3 objectPivot;
    //float objectPivotDistance;

    //public float time = 10;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    explode();
    //}
    //public void explode()
    //{
    //    gameObject.SetActive(false);
    //    for (int x = 0; x < objectsInRow; x++)
    //    {
    //        for (int y = 0; y < objectsInRow; y++)
    //        {
    //            for (int z = 0; z < objectsInRow; z++)
    //            {
    //                createPiece(x, y, z);
    //            }
    //        }
    //    }
    //    //yield return StartCoroutine(delay(0.30f));
    //}
    //private IEnumerator delay(float delayTime)
    //{
    //    yield return new WaitForSeconds(delayTime);
    //}
    //void createPiece(int x, int y, int z)
    //{
    //    //create piece
    //    GameObject piece;
    //    piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    //set the piece position and scale

    //    //all the pieces will be 0.5 units apart and equal distance?
    //    piece.transform.position = transform.position + new Vector3(objectSize * x, objectSize * y, objectSize * z) - objectPivot;
    //    piece.transform.localScale = new Vector3(objectSize, objectSize, objectSize);
    //    //piece.GetComponent<BoxCollider>().enabled = false;
    //    //add rigidbody and set mass
    //    //why?
    //    piece.AddComponent<Rigidbody>();
    //    piece.GetComponent<Rigidbody>().mass = objectSize;
    //    piece.GetComponent<Renderer>().material.color = Color.cyan;

    //    Destroy(piece, time);
    //}
}
