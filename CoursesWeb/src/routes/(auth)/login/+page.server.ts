import type { Actions } from "../../../../.svelte-kit/types/src/routes";
import { signInWithPassword } from "@api/mutations";
import { saveSession } from "$lib/session";
import { redirect } from "@sveltejs/kit";

export const actions = {
	default: async ({ locals, request, cookies }) => {
		const formData = await request.formData();
		const email = formData.get("email") as string;
		const password = formData.get("password") as string;

		if (!email || !password) return;

		const result = await signInWithPassword(email, password);

		if (result?.success) {
			const asUint8Array = new Uint8Array(result.accessToken!);
			const session = {
				...locals.session,
				accessToken: asUint8Array,
			};
			await saveSession(session, cookies);

			return redirect(303, "/");
		} else {
			return { success: false, errors: result?.errors };
		}
	},
} satisfies Actions;
