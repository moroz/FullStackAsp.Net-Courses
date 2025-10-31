<script lang="ts">
	import type { PageProps } from "./$types";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
	import { applyAction, enhance } from "$app/forms";
	import Button from "@components/button.svelte";

	let { form }: PageProps = $props();
	let submitting = $state(false);
</script>

<form
	method="POST"
	class="grid gap-6"
	use:enhance={() => {
		submitting = true;
		return async ({ result }) => {
			submitting = false;
			await applyAction(result);
		};
	}}
	action="/login?/signIn"
	novalidate
>
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.sessions.new.header")}</h2>

	{#if form && !form.success}
		<div class="rounded-sm border-2 bg-red-100 px-4 py-3 text-red-800">
			{form?.errors?.[0]?.msg ?? "Invalid email/password combination."}
		</div>
	{/if}

	<InputField
		name="email"
		type="email"
		labelKey="common.sessions.new.email"
		autocomplete="email webauthn"
		value={form?.input.email}
		autofocus
	/>
	<InputField
		name="password"
		type="password"
		labelKey="common.sessions.new.password"
		autocomplete="current-password"
	/>

	<Button type="submit" variant="primary" disabled={submitting}
		>{$t("common.sessions.new.submit")}</Button
	>

	<p class="text-center">
		{@html $t("common.sessions.new.no_account_yet_html", { path: "/register" })}
	</p>
</form>
