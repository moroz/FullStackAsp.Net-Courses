import crypto from "node:crypto";
import { encode, decode } from "cbor2";
import sodium from "libsodium-wrappers";

const SecretKeyBaseBase64 =
	process.env.SECRET_KEY_BASE ??
	"jKeZVSULHKgV1REKtw6YZTzurg6/t/uGHdL8pctRizuvPSdnvpYtSVwSWmQ5MJuGtR2sXnT312YQqR/bFJCCKA==";

const KeyLength = 32;
const NonceLength = 24;
const AuthenticationTagLength = 16;

const SessionChachaEncryptionKey = new Uint8Array(
	crypto.hkdfSync("sha512", Buffer.from(SecretKeyBaseBase64, "base64"), "Sessions", "", KeyLength),
);

export async function seal(payload: Record<string, any>) {
	await sodium.ready;
	const encoded = encode(payload);
	const nonce = crypto.randomBytes(NonceLength);
	const sealed = sodium.crypto_aead_xchacha20poly1305_ietf_encrypt(
		encoded,
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
	const decrypted = sodium.crypto_aead_xchacha20poly1305_ietf_decrypt(
		null,
		sealed,
		null,
		nonce,
		SessionChachaEncryptionKey,
	);
	return decode(decrypted);
}
