<script lang="ts">
	import { enhance } from "$app/forms";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
	import type { PageProps } from "./$types";
	import { createForm } from "felte";
	import z from "zod";
	import { validator } from "@felte/validator-zod";

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

	let { form: data }: PageProps = $props();
	const { form, validate, setFields, errors } = createForm({
		extend: validator({ schema }),
		onSubmit() {
			return false;
		},
	});

	const serverErrors =
		data?.errors.reduce(
			(acc, { key, msg }) => {
				return { ...acc, [key]: acc[key] || msg };
			},
			{} as Record<string, string>,
		) ?? {};

	async function handleEnhance({ formData, cancel }, submit) {
		const values = Object.fromEntries(formData);
		setFields(values);
		const validationErrors = await validate();
		if (validationErrors && Object.keys(validationErrors).length > 0) {
			cancel();
		}
		submit();
	}
</script>

<form method="POST" class="grid gap-3" use:enhance={handleEnhance}>
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.users.new.header")}</h2>

	<InputField
		name="email"
		type="email"
		labelKey="common.users.new.email"
		autocomplete="email"
		error={$errors.email || serverErrors.Email}
	/>
	<InputField
		name="givenName"
		type="text"
		labelKey="common.users.new.given_name"
		autocomplete="given-name"
		error={$errors.givenName || serverErrors.GivenName}
	/>
	<InputField
		name="familyName"
		type="text"
		labelKey="common.users.new.family_name"
		autocomplete="family-name"
		error={$errors.familyName || serverErrors.FamilyName}
	/>
	<InputField
		name="password"
		type="password"
		labelKey="common.users.new.password"
		autocomplete="new-password"
		error={$errors.password || serverErrors.Password}
	/>
	<InputField
		name="passwordConfirmation"
		type="password"
		labelKey="common.users.new.confirm_password"
		autocomplete="new-password"
		error={$errors.passwordConfirmation || serverErrors.PasswordConfirmation}
	/>

	<button
		class="h-10 w-full cursor-pointer rounded-sm bg-primary-900 font-bold text-white transition-colors hover:bg-primary-800"
		>{$t("common.users.new.submit")}</button
	>

	<p class="text-center">
		{@html $t("common.users.new.already_have_an_account_html", { path: "/login" })}
	</p>
</form>
