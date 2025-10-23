import { CoursesApiClient } from "@api/client";
import { promisify } from "util";
import type { UserRegistrationRequest } from "@api/proto/courses/UserRegistrationRequest";

export async function registerUser(params: UserRegistrationRequest) {
	const client = new CoursesApiClient();
	return await promisify(client.client.registerUser).call(client.client, params);
}
