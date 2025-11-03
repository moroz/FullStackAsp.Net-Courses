using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using NSec.Cryptography;
using PeterO.Cbor;

namespace Courses.Services;

public class SessionService
{
    private readonly Key _encryptionKey;
    private const int KeyLength = 32;
    private const int NonceLength = 24;
    private const int AuthenticationTagLength = 16;
    public const int Overhead = NonceLength + AuthenticationTagLength;

    public SessionService(string secretKeyBaseBase64, string salt = "Sessions")
    {
        var baseKey = Convert.FromBase64String(secretKeyBaseBase64);
        var derived = HKDF.DeriveKey(HashAlgorithmName.SHA512, baseKey, KeyLength, Encoding.UTF8.GetBytes(salt));
        _encryptionKey = Key.Import(AeadAlgorithm.XChaCha20Poly1305, derived, KeyBlobFormat.RawSymmetricKey);
    }

    public string Seal(byte[] payload)
    {
        var nonce = RandomNumberGenerator.GetBytes(NonceLength);
        var sealedText = AeadAlgorithm.XChaCha20Poly1305.Encrypt(_encryptionKey, nonce, [], payload);
        var combined = new byte[sealedText.Length + NonceLength];
        Buffer.BlockCopy(nonce, 0, combined, 0, NonceLength);
        Buffer.BlockCopy(sealedText, 0, combined, NonceLength, sealedText.Length);
        return Base64UrlTextEncoder.Encode(combined);
    }

    public string Seal(string payload)
    {
        return Seal(Encoding.UTF8.GetBytes(payload));
    }

    public byte[]? Open(string cookie)
    {
        var decoded = Base64UrlTextEncoder.Decode(cookie);
        if (decoded.Length < Overhead)
        {
            throw new InvalidOperationException("Malformed message");
        }

        var nonce = decoded[0..NonceLength];
        var msg = decoded[NonceLength..];
        return AeadAlgorithm.XChaCha20Poly1305.Decrypt(_encryptionKey, nonce, [], msg);
    }

    public string EncodeAndSeal(object payload)
    {
        var cbor = CBORObject.FromObject(payload).EncodeToBytes();
        return Seal(cbor);
    }

    public bool DecodeCookie<T>(string cookie, out T? output)
    {
        var msg = Open(cookie);
        if (msg == null)
        {
            output = default;
            return false;
        }

        output = CBORObject.DecodeObjectFromBytes<T>(msg);
        return true;
    }
}