using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging, StopDrag = false;
    public Vector3 LastPosition;
    public int UID;

    private Collider2D _collider;

    private DragController _dragController;
    private GameController _gameController;
    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;

    

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
        _gameController = FindObjectOfType<GameController>();
    }

    void FixedUpdate()
    {
        if (IsDragging == true)
        {
            this.transform.parent = null;
        }
        
        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                _movementDestination = null;
                return;
            }

            if (transform.position == _movementDestination)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable collidedDraggable = collision.GetComponent<Draggable>();
        DraggableID dragUID = collision.gameObject.GetComponent<DraggableID>();

        
            if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
            {
                ColliderDistance2D colliderDistance2D = collision.Distance(_collider);
                Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
                transform.position -= diff;
            }

            if (StopDrag == false)
            {
                if (collision.CompareTag("DropValid") && UID == dragUID.dragUID)
                {
                    StopDrag = true;
                    collision.gameObject.SetActive(false);
                    _gameController.scoreAdd += 1;
                    _movementDestination = collision.transform.position;
                    this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, collision.gameObject.transform.localScale, 5f);
                }
                else if (collision.CompareTag("DropInvalid")) {
                    _movementDestination = LastPosition;
                }
                else
                {
                    return;
                }
            }
        
    }
}
