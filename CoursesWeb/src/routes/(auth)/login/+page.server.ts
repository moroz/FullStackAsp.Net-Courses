import type { Actions } from "./$types";
import { signInWithPassword, signOut } from "@api/mutations";
import { saveSession } from "$lib/session";
import { redirect } from "@sveltejs/kit";

export const actions = {
	signIn: async ({ locals, request, cookies }) => {
		const input = Object.fromEntries(await request.formData()) as Record<string, string>;

		if (!input.email || !input.password) return { success: false, input: { email: input.email } };

		const result = await signInWithPassword(input.email, input.password);

		if (result?.success) {
			const asUint8Array = new Uint8Array(result.accessToken!);
			const session = {
				...locals.session,
				accessToken: asUint8Array,
			};
			await saveSession(session, cookies);

			return redirect(303, "/");
		} else {
			return { success: false, errors: result?.errors, input: { email: input.email } };
		}
	},
	signOut: async ({ locals, cookies }) => {
		const { accessToken: token, ...session } = locals.session;
		if (!token) {
			return redirect(303, "/");
		}

		const result = await signOut(token);
		await saveSession(session, cookies);

		return redirect(303, "/");
	},
} satisfies Actions;
