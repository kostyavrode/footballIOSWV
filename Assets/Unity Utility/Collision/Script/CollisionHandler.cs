using UnityEngine;

public class CollisionHandler : CollisionBase {

	#region 3D
	private void OnCollisionEnter(Collision collision)
	{
		if (IsThisLayerCollidable(collision.gameObject) == true)
		{
			ICollisionEnter collidable = this.gameObject.GetComponent<ICollisionEnter>();
			if (collidable != null)
				collidable.onCollisionEnter(collision.gameObject);
		}
	}
	private void OnTriggerEnter(Collider collision)
	{
		if (IsThisLayerCollidable(collision.gameObject) == true)
		{
			ICollisionEnter collidable = this.gameObject.GetComponent<ICollisionEnter>();
			if (collidable != null)
				collidable.onCollisionEnter(collision.gameObject);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (IsThisLayerCollidable(collision.gameObject) == true)
		{
			ICollisionExit collidable = this.gameObject.GetComponent<ICollisionExit>();
			if (collidable != null)
				collidable.onCollisionExit(collision.gameObject);
		}
	}
	#endregion 3D
	

	#region 2D
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (IsThisLayerCollidable(collision.gameObject) == true)
		{
			ICollisionEnter collidable = this.gameObject.GetComponent<ICollisionEnter>();
			if (collidable != null)
				collidable.onCollisionEnter(collision.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (IsThisLayerCollidable(collision.gameObject) == true)
		{
			ICollisionEnter collidable = this.gameObject.GetComponent<ICollisionEnter>();
			if (collidable != null)
				collidable.onCollisionEnter(collision.gameObject);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (IsThisLayerCollidable(collision.gameObject) == true)
		{
			ICollisionExit collidable = this.gameObject.GetComponent<ICollisionExit>();
			if (collidable != null)
				collidable.onCollisionExit(collision.gameObject);
		}
	}
	#endregion  2D
}
