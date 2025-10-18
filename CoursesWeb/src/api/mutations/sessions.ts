import { CoursesApiClient } from "../client";
import { promisify } from "util";
import { buildMetadata } from "@api/queries/auth";

export async function signInWithPassword(email: string, password: string) {
	const client = new CoursesApiClient();
	return await promisify(client.client.signInWithPassword).call(client.client, {
		email,
		password,
	});
}

export async function signOut(token: Uint8Array): Promise<boolean> {
	return new Promise((resolve, reject) => {
		if (!token.length) return resolve(false);

		const client = new CoursesApiClient();
		client.client.signOut({}, buildMetadata(token), (error, result) => {
			if (error) {
				return reject(error);
			}

			return resolve(result?.success ?? false);
		});
	});
}
