using System.Collections;
using UnityEngine;

public class CodeAnimation : MonoBehaviour
{
	public static CodeAnimation Instance;

	public enum CurveType
	{
		LINEAR = 0,

		IN_QUAD,
		OUT_QUAD,
		IN_OUT_QUAD,

		IN_CUBIC,
		OUT_CUBIC,
		IN_OUT_CUBIC,

		IN_QUART,
		OUT_QUART,
		IN_OUT_QUART,

		IN_QUINT,
		OUT_QUINT,
		IN_OUT_QUINT,

		IN_SINE,
		OUT_SINE,
		IN_OUT_SINE,

		IN_EXPO,
		OUT_EXPO,
		IN_OUT_EXPO,

		IN_CIRC,
		OUT_CIRC,
		IN_OUT_CIRC,

		IN_ELASTIC,
		OUT_ELASTIC,
		IN_OUT_ELASTIC,

		IN_BACK,
		OUT_BACK,
		IN_OUT_BACK,

		IN_BOUNCE,
		OUT_BOUNCE,
		IN_OUT_BOUNCE,

		STEP,
		SOFT_LOOP,
		BOOMERANG_LOOP,
	}
	[Header("Penner's Curves")]
	public AnimationCurve[] animationCurves;

	private void Awake()
	{
		if (Instance == null) Instance = this;
	}

	public static Coroutine Animate(Transform trans, float animationTime, CurveType curveType,float delay = 0, float? xScale = null, float? yScale = null, float? zScale = null, float? x = null, float? y = null, float? z = null, float? rotation = null, bool? delayPersistent = null, int iterations = 1, bool loop = false, bool localPos = true, System.Action onComplete = null)
	{
		IEnumerator func = Instance.StartAnimation(animationTime, curveType, trans, delay, xScale, yScale, zScale, x, y, z, rotation, delayPersistent, iterations, loop, localPos, onComplete);
		Coroutine routine = Instance.StartCoroutine(func);
		return routine;
	}
	public static Coroutine Animate(Transform trans, float animationTime, CurveType curveType, out IEnumerator enumerator, float delay = 0, float? xScale = null, float? yScale = null, float? zScale = null, float? x = null, float? y = null, float? z = null, float? rotation = null, bool? delayPersistent = null, int iterations = 1, bool loop = false, bool localPos = true, System.Action onComplete = null)
	{
		IEnumerator func = Instance.StartAnimation(animationTime, curveType, trans, delay, xScale, yScale, zScale, x, y, z, rotation, delayPersistent, iterations, loop, localPos, onComplete);
		Coroutine routine = Instance.StartCoroutine(func);
		enumerator = func;
		return routine;
	}

	public static Coroutine BlendColor(SpriteRenderer sprite, float animationTime, CurveType curveType, float delay = 0, float? r = null, float? g = null, float? b = null, float? a = null, int iterations = 1, bool loop = false)
	{
		IEnumerator func = Instance.StartColorBlend(animationTime, curveType, sprite, delay, r, g, b, a, iterations, loop);
		Coroutine routine = Instance.StartCoroutine(func);
		return routine;
	}

	public static Coroutine BlendColor(SpriteRenderer sprite, float animationTime, CurveType curveType, out IEnumerator enumerator, float delay = 0, float? r = null, float? g = null, float? b = null, float? a = null, int iterations = 1, bool loop = false)
	{
		IEnumerator func = Instance.StartColorBlend(animationTime, curveType, sprite, delay, r, g, b, a, iterations, loop);
		Coroutine routine = Instance.StartCoroutine(func);
		enumerator = func;
		return routine;
	}

	private IEnumerator StartAnimation(float animationTime, CurveType curveType, Transform trans, float delay, float? xScale, float? yScale, float? zScale, float? x, float? y, float? z, float? rotation, bool? delayPersistent, int iterations, bool loop, bool localPos, System.Action onComplete)
	{
		yield return new WaitForSeconds(delay);

		float currentIteration = 0;
		Vector3 originalPosition;

		if (trans == null) yield break;

		if (localPos)
			originalPosition = trans.localPosition;
		else
			originalPosition = trans.position;

		Vector3 originalScale = trans.localScale;
		float originalRotation = trans.rotation.eulerAngles.z;

		while (currentIteration < iterations || loop)
		{
			if (delayPersistent != null && (bool)delayPersistent)
				yield return new WaitForSeconds(delay);

			float t = 0;
			Vector3 currentPosition = originalPosition;
			Vector3 currentScale = originalScale;
			float currentRotation = originalRotation;

			while (t < 1)
			{
				if (!trans)
				{
					yield break;
				}
				Vector3 newPosition = Vector3.zero;
				if (localPos)
				{
					newPosition.x = x ?? trans.localPosition.x;
					newPosition.y = y ?? trans.localPosition.y;
					newPosition.z = z ?? trans.localPosition.z;
				}
				else
				{
					newPosition.x = x ?? trans.position.x;
					newPosition.y = y ?? trans.position.y;
					newPosition.z = z ?? trans.position.z;
				}


				Vector3 newScale = Vector3.zero;
				newScale.x = xScale ?? trans.localScale.x;
				newScale.y = yScale ?? trans.localScale.y;
				newScale.z = zScale ?? trans.localScale.z;

				float newRotation = rotation ?? trans.rotation.eulerAngles.z;

				t += Time.deltaTime / animationTime;
				newPosition = Vector3.LerpUnclamped(currentPosition, newPosition, animationCurves[(int)curveType].Evaluate(t));
				newScale = Vector3.LerpUnclamped(currentScale, newScale, animationCurves[(int)curveType].Evaluate(t));
				newRotation = Mathf.LerpUnclamped(currentRotation, newRotation, animationCurves[(int)curveType].Evaluate(t));

				if (localPos)
				{
					if (x == null) newPosition.x = trans.localPosition.x;
					if (y == null) newPosition.y = trans.localPosition.y;
					if (z == null) newPosition.z = trans.localPosition.z;
				}
				else
				{
					if (x == null) newPosition.x = trans.position.x;
					if (y == null) newPosition.y = trans.position.y;
					if (z == null) newPosition.z = trans.position.z;
				}

				if (xScale == null) newScale.x = trans.localScale.x;
				if (yScale == null) newScale.y = trans.localScale.y;
				if (zScale == null) newScale.z = trans.localScale.z;

				if (rotation == null) newRotation = trans.rotation.eulerAngles.z;

				if (localPos)
					trans.localPosition = newPosition;
				else
					trans.position = newPosition;

				trans.localScale = newScale;
				trans.rotation = Quaternion.Euler(0, 0, newRotation);
				yield return null;
			}
			currentIteration++;
			yield return null;
		}
		if (onComplete != null) onComplete();
		yield return null;
	}



	private IEnumerator StartColorBlend(float animationTime, CurveType curveType, SpriteRenderer sprite, float delay, float? r, float? g, float? b, float? a, int iterations, bool loop)
	{
		yield return new WaitForSeconds(delay);

		float currentIteration = 0;
		Color originalColor = sprite.color;

		while (currentIteration < iterations || loop)
		{
			float t = 0;

			Color currentColor = originalColor;

			while (t < 1)
			{
				if (!sprite)
				{
					yield break;
				}
				Color newColor = Color.white;
				newColor.r = r ?? sprite.color.r;
				newColor.g = g ?? sprite.color.g;
				newColor.b = b ?? sprite.color.b;
				newColor.a = a ?? sprite.color.a;

				// Debug.Log(newColor.a);

				t += Time.deltaTime / animationTime;
				sprite.color = Color.LerpUnclamped(currentColor, newColor, animationCurves[(int)curveType].Evaluate(t));
				yield return null;
			}
			currentIteration++;
			yield return null;
		}
	}

	public static void Stop(Coroutine routine)
	{
		if (routine != null && Instance != null)
			Instance.StopCoroutine(routine);
	}

	public static void Stop(IEnumerator enumerator)
	{
		if (enumerator != null && Instance != null)
			Instance.StopCoroutine(enumerator);
	}

	public static void Resume(IEnumerator enumerator)
	{
		if (enumerator != null && Instance != null)
			Instance.StartCoroutine(enumerator);
	}
}