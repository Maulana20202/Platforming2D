using UnityEngine;

public class EnemyRoaming : MonoBehaviour
{
    public Transform pointA; // Titik awal gerakan
    public Transform pointB; // Titik akhir gerakan
    public float speed = 2f; // Kecepatan gerakan

    public Vector3 targetPosition; // Target posisi saat ini
    private bool movingToPointB = true; // Menyimpan arah gerakan

    void Start()
    {
        // Set target position untuk pertama kali
        if (pointA != null && pointB != null)
        {
            targetPosition = pointB.position;
        }
    }

    void Update()
    {
        // Pindahkan enemy jika pointA dan pointB ter-set
        if (pointA != null && pointB != null)
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {
        // Gerakkan enemy menuju targetPosition
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Cek jika sudah mencapai targetPosition dengan toleransi lebih besar
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            // Ubah target ke titik lain dan balik arah
            if (movingToPointB)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }
            movingToPointB = !movingToPointB;

            // Balikkan arah tampilan enemy dengan mengubah skala X
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
