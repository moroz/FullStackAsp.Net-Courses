import { CoursesApiClient } from "../client";
import grpc from "@grpc/grpc-js";
import type { User } from "@api/interfaces";
import { timestampToISO } from "@api/helpers";

export function buildMetadata(token: Uint8Array | string): grpc.Metadata {
	const metadata = new grpc.Metadata();
	const serialized =
		typeof token === "string" ? token : Buffer.from(token as Uint8Array).toString("base64");
	metadata.add("authorization", `Bearer ${serialized}`);
	return metadata;
}

export function getCurrentUser(token: Uint8Array | string): Promise<User | null> {
	return new Promise((resolve, reject) => {
		if (!token.length) return resolve(null);

		const client = new CoursesApiClient();
		client.client.getCurrentUser({}, buildMetadata(token), (error, result) => {
			if (error) {
				return reject(error);
			}
			if (!result?.user) {
				return resolve(null);
			}

			const user: User = {
				id: result.user.id!.value,
				createdAt: timestampToISO(result.user.createdAt)!,
				lastLoginAt: timestampToISO(result.user.lastLoginAt as any),
				email: result.user.email,
				givenName: result.user.givenName,
				familyName: result.user.familyName,
				salutation: result.user.salutation || null,
			};

			resolve(user);
		});
	});
}
