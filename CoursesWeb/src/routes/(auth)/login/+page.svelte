<script lang="ts">
	import type { PageProps } from "../../../../.svelte-kit/types/src/routes";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
	import { enhance } from "$app/forms";

	let { form }: PageProps = $props();
</script>

<form method="POST" class="mx-auto grid max-w-100 gap-4 rounded-sm border p-6" use:enhance>
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.sessions.new.header")}</h2>

	{#if form?.success}
		<div class="rounded-sm border bg-red-100 text-red-800">
			{form.errors?.[0]?.msg ?? "Invalid email/password combination."}
		</div>
	{/if}

	<InputField name="email" type="email" labelKey="common.sessions.new.email" />
	<InputField name="password" type="password" labelKey="common.sessions.new.password" />

	<button class="h-10 w-full rounded-sm bg-primary font-bold text-white"
		>{$t("common.sessions.new.submit")}</button
	>
</form>
