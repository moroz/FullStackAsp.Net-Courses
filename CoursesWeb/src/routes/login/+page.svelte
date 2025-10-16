<script lang="ts">
	import type { PageProps } from "./$types";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";

	let { data }: PageProps = $props();
</script>

<pre>{JSON.stringify(data, null, 2)}</pre>

<form method="POST" class="mx-auto grid max-w-100 gap-4 border p-6">
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.sessions.new.header")}</h2>

	<InputField name="email" type="email" labelKey="common.sessions.new.email" />
	<InputField name="password" type="password" labelKey="common.sessions.new.password" />

	<button class="h-10 w-full bg-primary font-bold text-white"
		>{$t("common.sessions.new.submit")}</button
	>
</form>
