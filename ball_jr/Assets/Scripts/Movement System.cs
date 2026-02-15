using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public float speed = 5f; // M�fetti� (Inspector) panelinden de�i�tirebilirsin
    Rigidbody rb;
    Vector3 movement;

    void Start()
    {
        // Rigidbody bile�enini al�yoruz
        rb = GetComponent<Rigidbody>();
    }

    // Giri�leri her karede (frame) kontrol ediyoruz
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket y�n�n� belirliyoruz (X ve Z ekseni �zerinde)
        movement = new Vector3(horizontalInput, 0f, verticalInput);
    }

    // Fizik hesaplamalar�n� burada yap�yoruz (Saniyede sabit 50 kez �al���r)
    void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        // Karakterin h�z�n� (velocity) ayarl�yoruz
        // Y eksenindeki mevcut h�z�n� (rb.velocity.y) koruyoruz ki yer�ekimi bozulmas�n
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Çarptığımız objenin tag'i "Coin" mi diye kontrol ediyoruz
        if (other.gameObject.CompareTag("Collectable"))
        {
            // Eğer öyleyse, o objeyi deaktif ediyoruz
            other.gameObject.SetActive(false);

            // Konsola bir mesaj yazdıralım (Test amaçlı)
            Debug.Log("Altın toplandı!");
        }
    }
}