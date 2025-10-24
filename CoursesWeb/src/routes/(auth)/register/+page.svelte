<script lang="ts">
	import { deserialize, enhance } from "$app/forms";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
	import type { PageProps } from "./$types";
	import { createForm } from "felte";
	import z from "zod";
	import { validator } from "@felte/validator-zod";
	import { redirect } from "@sveltejs/kit";
	import type { ErrorMessage } from "@api/proto/courses/ErrorMessage";

	const schema = z
		.object({
			email: z.email(),
			password: z.string().min(8).max(128),
			passwordConfirmation: z.string(),
		})
		.refine((data) => !data.password || data.password === data.passwordConfirmation, {
			message: "Passwords do not match.",
			path: ["passwordConfirmation"],
		});

	function transformErrors(errors: ErrorMessage[]) {
		debugger;
		return (
			errors.reduce(
				(acc, { key, msg }) => {
					return { ...acc, [key as string]: acc[key as string] || msg! };
				},
				{} as Record<string, string>,
			) ?? {}
		);
	}

	const { form, validate, setFields, errors } = createForm({
		extend: validator({ schema }),
		async onSubmit(values, { form, event }) {
			const data = new FormData(form);
			const result = await fetch(form!.action, { method: "POST", body: data })
				.then((r) => r.text())
				.then(deserialize);
			if (result.type === "success") {
				return redirect(302, "/login");
			}
			if (result.type === "failure") {
				const serverErrors = transformErrors(result.data!.errors as ErrorMessage[]);
				errors.set(serverErrors);
				console.log(serverErrors);
			}
		},
	});
</script>

<form method="POST" class="grid gap-3" use:form>
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.users.new.header")}</h2>

	<InputField
		name="email"
		type="email"
		labelKey="common.users.new.email"
		autocomplete="email"
		error={$errors.email}
	/>
	<InputField
		name="givenName"
		type="text"
		labelKey="common.users.new.given_name"
		autocomplete="given-name"
		error={$errors.givenName}
	/>
	<InputField
		name="familyName"
		type="text"
		labelKey="common.users.new.family_name"
		autocomplete="family-name"
		error={$errors.familyName}
	/>
	<InputField
		name="password"
		type="password"
		labelKey="common.users.new.password"
		autocomplete="new-password"
		error={$errors.password}
	/>
	<InputField
		name="passwordConfirmation"
		type="password"
		labelKey="common.users.new.confirm_password"
		autocomplete="new-password"
		error={$errors.passwordConfirmation}
	/>

	<button
		class="h-10 w-full cursor-pointer rounded-sm bg-primary-900 font-bold text-white transition-colors hover:bg-primary-800"
		>{$t("common.users.new.submit")}</button
	>

	<p class="text-center">
		{@html $t("common.users.new.already_have_an_account_html", { path: "/login" })}
	</p>
</form>
