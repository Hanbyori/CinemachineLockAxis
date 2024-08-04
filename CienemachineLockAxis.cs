using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class CienemachineLockAxis : CinemachineExtension
{
	[Header("Position Lock")]
	public bool lockX = false;
	public bool lockY = false;
	public bool lockZ = false;

	[Tooltip("Target position for locked axes")]
	public Vector3 lockedPosition = Vector3.zero;

	[Header("Rotation Lock")]
	public bool lockRotationX = false;
	public bool lockRotationY = false;
	public bool lockRotationZ = false;

	[Tooltip("Target rotation for locked axes (in degrees)")]
	public Vector3 lockedRotation = Vector3.zero;

	protected override void PostPipelineStageCallback(
		CinemachineVirtualCameraBase vcam,
		CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
	{
		if (stage == CinemachineCore.Stage.Body)
		{
			// Lock Position
			var pos = state.RawPosition;

			if (lockX) pos.x = lockedPosition.x;
			if (lockY) pos.y = lockedPosition.y;
			if (lockZ) pos.z = lockedPosition.z;

			state.RawPosition = pos;

			// Lock Rotation
			var rot = state.RawOrientation.eulerAngles;

			if (lockRotationX) rot.x = lockedRotation.x;
			if (lockRotationY) rot.y = lockedRotation.y;
			if (lockRotationZ) rot.z = lockedRotation.z;

			state.RawOrientation = Quaternion.Euler(rot);
		}
	}
}
