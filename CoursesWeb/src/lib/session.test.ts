import { describe, expect, test } from "vitest";
import { encode } from "cbor2";
import { seal, open, encodeAndSeal, openAndDecode } from "./session";
import crypto from "node:crypto";

describe(seal, () => {
	test("encrypts string payload", async () => {
		const payload = "Hello world!";
		const actual = await seal(payload);
		expect(actual).toBeTypeOf("string");
		const decoded = Buffer.from(actual, "base64url");
		expect(decoded.length).toEqual(16 + 24 + payload.length);
	});

	test("encrypts Uint8Array payload", async () => {
		const payload = encode({ userId: "123" });
		const actual = await seal(payload);
		expect(actual).toBeTypeOf("string");
		const decoded = Buffer.from(actual, "base64url");
		expect(decoded.length).toEqual(16 + 24 + payload.length);
	});
});

describe(open, () => {
	test("decrypts string payload back", async () => {
		const payload = "Hello world!";
		const encrypted = await seal(payload);
		const decrypted = await open(encrypted);
		expect(decrypted).toBeInstanceOf(Uint8Array);
		const decoder = new TextDecoder("utf-8");
		const asString = decoder.decode(decrypted);
		expect(asString).toEqual(payload);
	});

	test("decrypts Uint8Array", async () => {
		const payload = encode({ userId: "123" });
		const encrypted = await seal(payload);
		const decrypted = await open(encrypted);
		expect(decrypted).toBeInstanceOf(Uint8Array);
		expect(decrypted.length).toEqual(payload.length);
		expect(decrypted).toEqual(payload);
	});
});

describe(encodeAndSeal, async () => {
	test("encodes and decodes object with an user token and a language value", async () => {
		const payload = { userToken: new Uint8Array(crypto.randomBytes(32)), language: "pl" };
		const cookie = await encodeAndSeal(payload);
		const decoded = await openAndDecode<typeof payload>(cookie);
		expect(decoded).toEqual(payload);
	});
});
