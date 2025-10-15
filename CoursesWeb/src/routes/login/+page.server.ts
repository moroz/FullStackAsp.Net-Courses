import type { Actions } from "./$types";
import { signInWithPassword } from "@api/mutations";

export const actions = {
	default: async ({ request, cookies }) => {
		const formData = await request.formData();
		const email = formData.get("email") as string;
		const password = formData.get("password") as string;

		if (email && password) {
			const result = await signInWithPassword(email, password);
			console.log(result);
		}
		console.log({ email, password });
	},
} satisfies Actions;
