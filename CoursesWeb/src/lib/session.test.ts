import { describe, expect, test } from "vitest";
import { seal, open } from "./session";

describe("seal", () => {
	test("encodes and encrypts payload", async () => {
		const actual = await seal({ userId: "123" });
		expect(actual).toBeTypeOf("string");
		const decoded = Buffer.from(actual, "base64url");
		expect(decoded.length).toBeGreaterThan(16 + 24);
	});
});
