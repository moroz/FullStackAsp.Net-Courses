import type { Actions } from "./$types";
import { signInWithPassword } from "@api/mutations";
import { saveSession } from "$lib/session";
import { redirect } from "@sveltejs/kit";

export const actions = {
	default: async ({ locals, request, cookies }) => {
		const formData = await request.formData();
		const email = formData.get("email") as string;
		const password = formData.get("password") as string;

		if (email && password) {
			const result = await signInWithPassword(email, password);

			if (result?.success) {
				const asUint8Array = new Uint8Array(result.accessToken!);
				const session = {
					...locals.session,
					accessToken: asUint8Array,
				};
				await saveSession(session, cookies);

				return redirect(303, "/");
			}
		}
	},
} satisfies Actions;
