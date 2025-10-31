<script lang="ts">
	import { enhance } from "$app/forms";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
	import type { PageProps } from "./$types";
	import type { ErrorMessage } from "@api/proto/courses/ErrorMessage";
	import Button from "@components/button.svelte";

	const { form }: PageProps = $props();

	function transformErrors(errors: ErrorMessage[]) {
		return (
			errors.reduce(
				(acc, { key, msg }) => {
					return { ...acc, [key as string]: acc[key as string] || msg! };
				},
				{} as Record<string, string>,
			) ?? {}
		);
	}

	let errors = $derived.by(() => transformErrors(form?.errors ?? []));
</script>

<form method="POST" class="grid gap-4" use:enhance novalidate>
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.users.new.header")}</h2>

	<InputField
		name="email"
		type="email"
		labelKey="common.users.new.email"
		autocomplete="email"
		error={errors.email}
		required
	/>
	<InputField
		name="givenName"
		type="text"
		labelKey="common.users.new.given_name"
		autocomplete="given-name"
		error={errors.givenName}
		required
	/>
	<InputField
		name="familyName"
		type="text"
		labelKey="common.users.new.family_name"
		autocomplete="family-name"
		error={errors.familyName}
		required
	/>
	<InputField
		name="password"
		type="password"
		labelKey="common.users.new.password"
		helperText={$t("common.users.new.helpers.password", { min: 8, max: 128 })}
		autocomplete="new-password"
		error={errors.password}
		required
	/>
	<InputField
		name="passwordConfirmation"
		type="password"
		labelKey="common.users.new.confirm_password"
		autocomplete="new-password"
		error={errors.passwordConfirmation}
		required
	/>

	<Button type="submit" variant="primary">{$t("common.users.new.submit")}</Button>

	<p class="text-center">
		{@html $t("common.users.new.already_have_an_account_html", { path: "/login" })}
	</p>
</form>
