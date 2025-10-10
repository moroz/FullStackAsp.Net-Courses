import type { Timestamp__Output } from "./proto/google/protobuf/Timestamp";

export function timestampToISO(ts: Timestamp__Output | null): string | null {
	if (!ts) return null;
	const date = new Date(Number(ts.seconds) * 1000 + ts.nanos * 1e6);
	return date.toISOString();
}
