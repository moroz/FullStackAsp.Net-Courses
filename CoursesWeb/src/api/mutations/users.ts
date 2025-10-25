import { CoursesApiClient } from "@api/client";
import { promisify } from "util";
import type { UserRegistrationRequest } from "@api/proto/courses/UserRegistrationRequest";
import grpc from "@grpc/grpc-js";

export async function registerUser(params: UserRegistrationRequest, locale = "en-US") {
	const client = new CoursesApiClient();
	const metadata = new grpc.Metadata();
	metadata.add("accept-language", locale);
	return new Promise((resolve, reject) => {
		client.client.registerUser(params, metadata, (error, result) => {
			if (error) {
				return reject(error);
			}
			return resolve(result);
		});
	});
}
