using System;
using System.Collections.Generic;
using UnityEngine;

public class RNG {
	public static RNG globalInstance = new RNG((int)System.DateTimeOffset.Now.ToUnixTimeSeconds());

	public int Position {
		get => unchecked((int)position);
		set => position = unchecked((uint)value);
	}
	public int Seed {
		get => unchecked((int)seed);
		set => seed = unchecked((uint)value);
	}

	private uint seed;
	private uint position;

	private const float UIntToFloat = 1f / uint.MaxValue;
	private const double UIntToDouble = 1d / uint.MaxValue;

	private const uint BigPrime = 616391;
	private const uint BiggerPrime = 91459909;

	public RNG(int seed) : this(seed, 0) {}
	public RNG(int seed, int position) {
		InitState(seed, position);
	}

	public void InitState(int seed) => InitState(seed, 0);

	public void InitState(int seed, int position) {
		Seed = seed;
		Position = position;
	}

	public float Next() => Move(1) * UIntToFloat;

	public float Prev() => Move(-1) * UIntToFloat;

	public float InRange(float min, float max) => Lerp(min, max, Next());

	public int InRange(int maxExclusive) => InRange(0, maxExclusive);

	public int InRange(int min, int maxExclusive) {
		uint value = Move(1);
		if (value == uint.MaxValue)
			value--;
		return (int)Lerp(min, maxExclusive, value * UIntToFloat);
	}

	public void Shuffle<T>(IList<T> list) {
		for (int i = 0; i < list.Count; i++) {
			int swapIndex = InRange(list.Count);
			(list[i], list[swapIndex]) = (list[swapIndex], list[i]);
		}
	}

	public bool Chance(float probability) {
		if (probability == 0)
			return false;
		return Next() >= probability;
	}

	public T Pick<T>(IList<T> list) => list[InRange(list.Count)];

	/// <summary>
	/// Pick a random element from a list given a probability function.
	/// </summary>
	/// <param name="list">The list to pick from.</param>
	/// <param name="getProbability">Ex. (T name) => name.GetProbability();</param>
	public T Pick<T>(IList<T> list, Func<T, float> getProbability) {

		if (list == null)
			throw new System.ArgumentNullException(nameof(list));
		if (list.Count == 0)
			throw new System.ArgumentException("List must contain more than 0 elements!", nameof(list));

		float[] probabilities = new float[list.Count];
		float total = 0;

		for (int i = 0; i < list.Count; i++) {
			float value = getProbability(list[i]);
			probabilities[i] = value;
			total += value;
		}

		return list[Pick(probabilities, total)];
	}

	public T Pick<T>(IList<T> list, float[] probabilities) {
		float total = 0;
		for (int i = 0; i < probabilities.Length; i++)
			total += probabilities[i];

		return list[Pick(probabilities, total)];
	}

	/// <summary> Pick a random index. </summary>
	/// <param name="probs"> An array of normalized probabilities. </param>
	private int Pick(float[] probs, float total) {
		float rndVal = Next() * total;

		for (int i = 0; i < probs.Length; i++) {
			if (rndVal < probs[i])
				return i;
			else
				rndVal -= probs[i];
		}

		return probs.Length - 1;
	}

	public Color RandomColorRGB() => new Color(Next(), Next(), Next());
	public Color RandomColorRGBA() => new Color(Next(), Next(), Next(), Next());

	public Vector2 RandomVector() => new Vector2(Next(), Next());
	public Vector3 RandomVector3() => new Vector3(Next(), Next(), Next());
	public Vector4 RandomVector4() => new Vector4(Next(), Next(), Next(), Next());

	public float Noise1D(float position) => SampleNoise(FloatToUInt(position)) * UIntToFloat;

	public float Noise2D(Vector2 position) => SampleNoise(FloatToUInt(position.x) + (FloatToUInt(position.y) * BigPrime)) * UIntToFloat;

	public float Noise3D(Vector3 position) => SampleNoise(FloatToUInt(position.x) + (FloatToUInt(position.y) * BigPrime) + (FloatToUInt(position.z) * BiggerPrime)) * UIntToFloat;

	private uint FloatToUInt(float value) => unchecked((uint)(InverseLerp(float.MinValue, float.MaxValue, value) * uint.MaxValue));

	private float SampleNoise(uint position) => Squirrel3Hash(position, seed);

	private float Lerp(float a, float b, float t) => (1.0f - t) * a + b * t;

	private float InverseLerp(float a, float b, float v) => (v - a) / (b - a);

	private uint Move(int direction) {
		position += unchecked((uint)direction);
		return Squirrel3Hash(position, seed);
	}

	private static uint Squirrel3Hash(uint position, uint seed) {
		const uint BIT_NOISE1 = 0xB5297A4D;
		const uint BIT_NOISE2 = 0x68E31DA4;
		const uint BIT_NOISE3 = 0x1B56C4E9;

		uint mangled = position;
		mangled *= BIT_NOISE1;
		mangled += seed;
		mangled ^= (mangled >> 8);
		mangled += BIT_NOISE2;
		mangled ^= (mangled << 8);
		mangled *= BIT_NOISE3;
		mangled ^= (mangled >> 8);
		return mangled;
	}
}