<script lang="ts">
	import { enhance } from "$app/forms";
	import { t } from "$lib/translations";
	import InputField from "@components/forms/input-field.svelte";
</script>

<form method="POST" class="grid gap-6" use:enhance>
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.users.new.header")}</h2>

	<InputField name="email" type="email" labelKey="common.users.new.email" autocomplete="email" />
	<InputField
		name="password"
		type="password"
		labelKey="common.users.new.password"
		autocomplete="new-password"
	/>
	<InputField
		name="confirm_password"
		type="password"
		labelKey="common.users.new.confirm_password"
		autocomplete="new-password"
	/>

	<button
		class="h-10 w-full cursor-pointer rounded-sm bg-primary-900 font-bold text-white transition-colors hover:bg-primary-800"
		>{$t("common.users.new.submit")}</button
	>

	<p class="text-center">
		{@html $t("common.users.new.already_have_an_account_html", { path: "/login" })}
	</p>
</form>
