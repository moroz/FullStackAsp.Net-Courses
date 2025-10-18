<script lang="ts">
	import type { PageProps } from "./$types";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
	import { enhance } from "$app/forms";
	import SubmitButton from "@components/forms/submit-button.svelte";

	let { form }: PageProps = $props();
</script>

<form method="POST" class="grid gap-6" use:enhance action="/login?/signIn">
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.sessions.new.header")}</h2>

	{#if form?.success}
		<div class="rounded-sm border bg-red-100 text-red-800">
			{form.errors?.[0]?.msg ?? "Invalid email/password combination."}
		</div>
	{/if}

	<InputField
		name="email"
		type="email"
		labelKey="common.sessions.new.email"
		autocomplete="email webauthn"
	/>
	<InputField
		name="password"
		type="password"
		labelKey="common.sessions.new.password"
		autocomplete="current-password"
	/>

	<SubmitButton>{$t("common.sessions.new.submit")}</SubmitButton>

	<p class="text-center">
		{@html $t("common.sessions.new.no_account_yet_html", { path: "/register" })}
	</p>
</form>
