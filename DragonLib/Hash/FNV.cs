using System.Numerics;
using System.Runtime.InteropServices;
using DragonLib.Hash.Algorithms;
using DragonLib.Hash.Basis;

namespace DragonLib.Hash;

public static class FNV {
	public const uint FNV32Prime = 0x01000193U;
	public const ulong FNV64Prime = 0x00000100000001B3UL;

	public static FNVAlgorithm<uint> Create(FNV32Basis basis = FNV32Basis.Default, uint prime = FNV32Prime) => new((uint) basis, prime);
	public static FNVInverseAlgorithm<uint> CreateInverse(FNV32Basis basis = FNV32Basis.Default, uint prime = FNV32Prime) => new((uint) basis, prime);
	public static FNVAlgorithm<ulong> Create(FNV64Basis basis = FNV64Basis.Default, ulong prime = FNV64Prime) => new((ulong) basis, prime);
	public static FNVInverseAlgorithm<ulong> CreateInverse(FNV64Basis basis = FNV64Basis.Default, ulong prime = FNV64Prime) => new((ulong) basis, prime);

	public static T HashData<T>(T basis, T prime, string text) where T : unmanaged, INumber<T>, IBitwiseOperators<T, T, T> => HashData(basis, prime, MemoryMarshal.AsBytes(text.AsSpan()));

	public static T HashData<T>(T basis, T prime, ReadOnlySpan<byte> data) where T : unmanaged, INumber<T>, IBitwiseOperators<T, T, T> {
		using var algorithm = new FNVAlgorithm<T>(basis, prime);
		return algorithm.ComputeHashValue(data);
	}

	public static T InverseHashData<T>(T basis, T prime, string text) where T : unmanaged, INumber<T>, IBitwiseOperators<T, T, T> => HashData(basis, prime, MemoryMarshal.AsBytes(text.AsSpan()));

	public static T InverseHashData<T>(T basis, T prime, ReadOnlySpan<byte> data) where T : unmanaged, INumber<T>, IBitwiseOperators<T, T, T> {
		using var algorithm = new FNVInverseAlgorithm<T>(basis, prime);
		return algorithm.ComputeHashValue(data);
	}
}
