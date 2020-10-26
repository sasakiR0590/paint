using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Es.InkPainter.Sample
{
	public class PaintCube : MonoBehaviour
	{
		/// <summary>
		/// Types of methods used to paint.
		/// </summary>
		[System.Serializable]
		private enum UseMethodType
		{
			RaycastHitInfo,
			WorldPoint,
			NearestSurfacePoint,
			DirectUV,
		}

		[SerializeField]
		private Brush brush;

		[SerializeField]
		private UseMethodType useMethodType = UseMethodType.RaycastHitInfo;

		[SerializeField]
		bool erase = false;

		//// Start is called before the first frame update
		//void Start()
		//{
		//}
		//// Update is called once per frame
		//void Update()
		//{
		//}

		private void OnCollisionStay(Collision collision)
		{
			Debug.Log("当たったよー");

			var paintObject = collision.gameObject.transform.GetComponent<InkCanvas>();
			bool success = true;

			if (paintObject != null)
				foreach (ContactPoint point in collision.contacts)
				{
					success = erase ? paintObject.Erase(brush, point.point) : paintObject.Paint(brush, point.point);
				}

			//if (paintObject != null)
			//	switch (useMethodType)
			//	{
			//		case UseMethodType.RaycastHitInfo:
			//			success = erase ? paintObject.Erase(brush, point.point) : paintObject.Paint(brush, point.point);
			//			break;

			//		case UseMethodType.WorldPoint:
			//			success = erase ? paintObject.Erase(brush, hitInfo.point) : paintObject.Paint(brush, hitInfo.point);
			//			break;

			//		case UseMethodType.NearestSurfacePoint:
			//			success = erase ? paintObject.EraseNearestTriangleSurface(brush, hitInfo.point) : paintObject.PaintNearestTriangleSurface(brush, hitInfo.point);
			//			break;

			//		case UseMethodType.DirectUV:
			//			if (!(hitInfo.collider is MeshCollider))
			//				Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
			//			success = erase ? paintObject.EraseUVDirect(brush, hitInfo.textureCoord) : paintObject.PaintUVDirect(brush, hitInfo.textureCoord);
			//			break;
			//	}

			if (!success)
				Debug.LogError("Failed to paint.");

			//var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//RaycastHit hitInfo;
			//if (Physics.Raycast(ray, out hitInfo))
			//{
				
				
			//}
		}
	}
}
