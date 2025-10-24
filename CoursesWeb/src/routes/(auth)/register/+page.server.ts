import type { Actions } from "./$types";
import { registerUser } from "@api/mutations";
import type { UserRegistrationRequest } from "@api/proto/courses/UserRegistrationRequest";
import { fail } from "@sveltejs/kit";

export const actions = {
	default: async ({ request }) => {
		const formData = await request.formData();
		const params = Object.fromEntries(formData) as UserRegistrationRequest;
		const result = await registerUser(params);
		if (!result?.success) {
			return fail(422, { success: false, errors: result?.errors });
		}
		return { success: true };
	},
} satisfies Actions;
