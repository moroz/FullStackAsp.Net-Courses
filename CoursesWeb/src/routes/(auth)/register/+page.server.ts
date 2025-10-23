import type { Actions } from "./$types";
import { registerUser } from "@api/mutations";
import type { UserRegistrationRequest } from "@api/proto/courses/UserRegistrationRequest";

export const actions = {
	default: async ({ request }) => {
		const formData = await request.formData();
		const params = Object.fromEntries(
			["email", "givenName", "familyName", "password", "passwordConfirmation"].map((key) => [
				key,
				formData.get(key),
			]),
		) as UserRegistrationRequest;
		const result = await registerUser(params);
		console.log(result);
	},
} satisfies Actions;
