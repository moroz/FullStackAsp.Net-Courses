<script lang="ts">
	import { t } from "$lib/translations";
</script>

<form method="POST" class="mx-auto grid max-w-100 gap-3 border p-6">
	<h2 class="text-center text-xl font-bold lg:text-2xl">{$t("common.sessions.new.header")}</h2>

	<label class="grid">
		{$t("common.sessions.new.email")}
		<input name="email" type="email" class="border" autofocus />
	</label>

	<label class="grid">
		{$t("common.sessions.new.password")}
		<input name="password" type="password" class="border" />
	</label>

	<button>{$t("common.sessions.new.submit")}</button>
</form>
