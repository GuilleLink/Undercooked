using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float force = 5f;
    public float forceBoost = 10f;
    private float tempForce = 0f;
    private float timer;
    private Vector3 moveTo;
    private Rigidbody rb;
    private FurnitureDetection furnitureDetection;
    private Holder PlayerHolder;
    private bool isChopping = false;
    public Animator animator;
    public Lightsaber lightsaber;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        furnitureDetection = GetComponent<FurnitureDetection>();
        PlayerHolder = GetComponent<Holder>();
        animator = GetComponent<Animator>();
        animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        moveTo = new Vector3(horizontalMovement, 0, verticalMovement);

        if (moveTo != Vector3.zero)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("IDLE", false);
            animator.SetBool("Pulling", false);
            animator.SetBool("Cutting", false);
        }
        else
        {
            if (isChopping)
            {
                animator.SetBool("IDLE", false);
                animator.SetBool("Walking", false);
                animator.SetBool("Pulling", false);
                animator.SetBool("Cutting", true);
            }
            else
            {
                animator.SetBool("IDLE", true);
                animator.SetBool("Walking", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Furniture currentFurniture = furnitureDetection.GetSelected();
            if (currentFurniture != null)
            {
                Holder currentFurnitureHolder = currentFurniture.GetComponent<Holder>();
                //Give
                if (PlayerHolder.HasMovable())
                {
                    //Si ambos tienen objeto no lo cambia, se queda igual
                    if (PlayerHolder.HasMovable() && currentFurnitureHolder.HasMovable())
                    {
                        MovableObject furnitureMovable = currentFurnitureHolder.GetMovable();
                        MovableObject playerMovable = PlayerHolder.GetMovable();

                        PlayerHolder.SetMovable(playerMovable);
                        currentFurnitureHolder.SetMovable(furnitureMovable);
                    }
                    //Si solo uno tiene objeto
                    else{
                        MovableObject movable = PlayerHolder.GetMovable();
                        Trash trash = currentFurniture.GetComponent<Trash>();
                        if (trash != null)
                        {
                            PlayerHolder.RemoveMovable();
                            Destroy(movable.gameObject);
                            /*Food food = movable.GetComponent<Food>();
                            if (food!= null)
                            {
                                food.Delete();
                            }*/
                        }
                        else
                        {
                            MovableObject furnitureMovable = currentFurnitureHolder.GetMovable();
                            if (furnitureMovable != null)
                            {
                                Pot olla = currentFurnitureHolder.GetComponent<Pot>();
                                Food food = movable.GetComponent<Food>();
                                if (olla != null && food.GetStatus() == FoodStatus.CUT)
                                {
                                    PlayerHolder.RemoveMovable();
                                }
                            }
                        }
                        currentFurnitureHolder.SetMovable(movable);
                        PlayerHolder.RemoveMovable();
                    }                    
                }
                //Pick
                else
                {
                    if (currentFurnitureHolder.HasMovable())
                    {
                        MovableObject movable = currentFurnitureHolder.GetMovable();
                        PlayerHolder.SetMovable(movable);
                        currentFurnitureHolder.RemoveMovable();
                    }
                    else
                    {
                        IngredientSpawner ingred = currentFurniture.GetComponent<IngredientSpawner>();
                        if (ingred != null)
                        {
                            MovableObject movable = ingred.GetIngredient();
                            PlayerHolder.SetMovable(movable);
                        }
                    }
                } 
                    
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Furniture currentFurniture = furnitureDetection.GetSelected();
            if (currentFurniture != null)
            {
                Chopper currentChopper = currentFurniture.GetComponent<Chopper>();
                //Comienza a cortar
                if (currentChopper != null)
                {
                    isChopping = currentChopper.StartChopping(this);                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            tempForce = force;
            Debug.Log("La fuerza temporal es");
            Debug.Log(tempForce);
            timer += Time.deltaTime;
            while (timer < 10.0f)
            {
                timer += Time.deltaTime;
                force = forceBoost;
                Debug.Log("La fuerza es");
                Debug.Log(force);
            }
            force = tempForce;
            Debug.Log("La fuerza es");
            Debug.Log(force);
        }
    }

    private void FixedUpdate()
    {
        if (moveTo.magnitude > 0.1)
        {
            rb.AddForce(force * moveTo);
            transform.forward = moveTo;
        }
    }

    public void StopChopping() {
        isChopping = false;
        animator.SetBool("IDLE", true);
        animator.SetBool("Walking", false);
        animator.SetBool("Pulling", false);
        animator.SetBool("Cutting", false);
    }
}
