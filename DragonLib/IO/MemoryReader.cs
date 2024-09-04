using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DragonLib.IO;

public class MemoryReader(Memory<byte> Buffer) {
	public int Offset { get; set; }

	public T Read<T>() where T : struct {
		var value = MemoryMarshal.Read<T>(Buffer[Offset..].Span);
		Offset += Unsafe.SizeOf<T>();
		return value;
	}

	public ReadOnlySpan<T> Read<T>(int count) where T : struct {
		var value = Buffer.Slice(Offset, count * Unsafe.SizeOf<T>());
		Offset += value.Length;
		return MemoryMarshal.Cast<byte, T>(value.Span);
	}

	public string ReadString() => SpanReader.ReadString(Buffer.Span, Offset);

	public string ReadUTF8String() => SpanReader.ReadUTF8String(Buffer.Span, Offset);
}
