import { CoursesApiClient } from "../client";
import { promisify } from "util";

export async function signInWithPassword(email: string, password: string): Promise<any> {
	const client = new CoursesApiClient();
	return await promisify(client.client.signInWithPassword).call(client.client, {
		email,
		password,
	});
}
