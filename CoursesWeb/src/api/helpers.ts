import Decimal from "decimal.js";
import type { Decimal__Output } from "./proto/courses/Decimal";
import type { Timestamp__Output } from "./proto/google/protobuf/Timestamp";

export function timestampToISO(ts: Timestamp__Output | null): string | null {
	if (!ts) return null;
	const date = new Date(Number(ts.seconds) * 1000 + ts.nanos / 1e6);
	return date.toISOString();
}

export function decodeDecimal(value: Decimal__Output | null): Decimal | null {
	if (!value) return null;

	const mantissa = BigInt(value.lo!) + (BigInt(value.hi!) << 64n);
	const scale = Math.abs(value.signScale!);

	let result = new Decimal(mantissa).div(new Decimal(10).pow(scale));
	if (value.signScale! < 0) return result.neg();
	return result;
}
