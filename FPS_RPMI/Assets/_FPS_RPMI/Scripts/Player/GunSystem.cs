using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    #region GENERAL VARIABLES
    [Header("General references")]
    [SerializeField] Camera fpsCam; // Ref si disparamos desde el centro de la cam
    [SerializeField] Transform shootPoint; // Ref si disparamos desde el cañon del arma
    [SerializeField] LayerMask impactLayer; // Layer con la que interactua el raycast
    RaycastHit hit; // Almacen de la informacion de los objetos con los que el raycast puede chocar

    [Header("Weapon Parameters")]
    [SerializeField] int damage = 10; // Daño del arma por bala
    [SerializeField] float range = 100; // Distancia maxima de disparo
    [SerializeField] float spread = 0; // Radio de dispercion del disparo
    [SerializeField] float shootingCooldown = 0.2f; // Tiempo entre disparos
    [SerializeField] float reloadTime = 1.5f; // Tiempo de recarga en segundos
    [SerializeField] bool allowButtonHold = false; // Si el disparo se ejecuta por click (false) o por mantener (true)

    [Header("Bullet Management")]
    [SerializeField] int ammoSize = 30; // Cantidad maxima de balas por cargador
    [SerializeField] int bulletPerTap = 1; // Cantidad de balas disparadas por cada ejecucion del disparo
    int bulletsLeft; // Cantidad de balas dentro del cargador

    [Header("Feedback References")]
    [SerializeField] GameObject impactEffect; // Referencia al VFX de impacto de bala

    [Header("Dev - Gun State Bools")]
    [SerializeField] bool shooting; // Indica si estamos disparando
    [SerializeField] bool canShoot; // Indica si podemos disparar en X momento del juego
    [SerializeField] bool reloading; // Indica si estamos en el proceso de recarga

    #endregion

    private void Awake()
    {
        bulletsLeft = ammoSize; // Al iniciar la partida, tenemos el cargador lleno
        canShoot = true; // Al iniciar la partida, podemos disparar
    }

    #region INPUT SYSTEM

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    public void OnReload(InputAction.CallbackContext context)
    {

    }

    #endregion

    void Shoot()
    {
        // ESTE ES EL METODO MAS IMPORTANTE
        // SE DEFINE DISPARO POR RAYCAST -> UTILIZABLE POR CUALQUIER MECANICA

        // Almacenar la direccion del disparo y modificarla en caso de haber dispercion
        Vector3 direction = fpsCam.transform.forward;

        // Añadir dispersion aleatoria segun el valor de spread
        direction.x += Random.Range(-spread, spread);
        direction.y += Random.Range(-spread, spread);

        //DECLARACION DEL RAYCAST
        //Physics.Raycast(Origen del rayo, direccion, almacen de la info del impacto, longitud del rayo, layer con la que impacta el rayo)
        if(Physics.Raycast(fpsCam.transform.position, direction, out hit, range, impactLayer))
        {
            //AQUI PODEMOS CODEAR TODOS LOS EFECTOS QUE QUIERO PARA LA INTERACCION
            Debug.Log(hit.collider.name);
        }

    }
}
