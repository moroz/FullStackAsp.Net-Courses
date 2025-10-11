import crypto from "node:crypto";
import { decode, encode } from "cbor2";
import sodium from "libsodium-wrappers";

export const SessionCookieName = "_courses_session";

const SecretKeyBaseBase64 =
	process.env.SECRET_KEY_BASE ??
	"jKeZVSULHKgV1REKtw6YZTzurg6/t/uGHdL8pctRizuvPSdnvpYtSVwSWmQ5MJuGtR2sXnT312YQqR/bFJCCKA==";

const KeyLength = 32;
const NonceLength = 24;
const AuthenticationTagLength = 16;

const SessionChachaEncryptionKey = new Uint8Array(
	crypto.hkdfSync("sha512", Buffer.from(SecretKeyBaseBase64, "base64"), "Sessions", "", KeyLength),
);

export async function seal(payload: string | Uint8Array<ArrayBufferLike>) {
	await sodium.ready;
	const nonce = crypto.randomBytes(NonceLength);
	const sealed = sodium.crypto_aead_xchacha20poly1305_ietf_encrypt(
		payload,
		null,
		null,
		nonce,
		SessionChachaEncryptionKey,
	);
	const combined = new Uint8Array(NonceLength + sealed.length);
	combined.set(nonce);
	combined.set(sealed, NonceLength);
	return Buffer.from(combined).toString("base64url");
}

export async function open(cookie: string) {
	await sodium.ready;
	const decoded = Buffer.from(cookie, "base64url");
	if (decoded.length < NonceLength + AuthenticationTagLength) {
		throw new Error("Malformed message");
	}
	const nonce = decoded.subarray(0, NonceLength);
	const sealed = decoded.subarray(NonceLength);
	return sodium.crypto_aead_xchacha20poly1305_ietf_decrypt(
		null,
		sealed,
		null,
		nonce,
		SessionChachaEncryptionKey,
	);
}

export async function encodeAndSeal(payload: any): Promise<string> {
	const encoded = encode(payload);
	return seal(encoded);
}

export async function openAndDecode<T extends any>(cookie: string): Promise<T> {
	const decrypted = await open(cookie);
	return decode<T>(decrypted);
}

export async function maybeLoadSession<T extends any>(
	cookie: string | null | undefined,
): Promise<T | null> {
	if (!cookie) {
		return null;
	}

	try {
		return await openAndDecode<T>(cookie);
	} catch (e) {
		return null;
	}
}
