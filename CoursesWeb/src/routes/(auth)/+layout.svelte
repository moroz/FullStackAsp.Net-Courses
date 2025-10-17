<script lang="ts">
	import "../../app.css";
	import favicon from "$lib/assets/favicon.svg";
	import type { LayoutProps } from "./$types";
	import LanguageSwitcher from "@components/language-switcher.svelte";
	import Card from "@components/card.svelte";

	let { children, data }: LayoutProps = $props();
</script>

<svelte:head>
	<link rel="icon" href={favicon} />
	<link rel="preconnect" href="https://fonts.googleapis.com" />
	<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
	<link
		href="https://fonts.googleapis.com/css2?family=DM+Sans:ital,opsz,wght@0,9..40,100..1000;1,9..40,100..1000&display=swap"
		rel="stylesheet"
	/>
</svelte:head>

<div class="flex min-h-screen flex-col bg-slate-100">
	<main class="m-auto grid gap-6">
		<h1 class="text-center text-3xl font-bold text-primary">Homeo sapiens</h1>
		<Card class="w-100 space-y-6">
			{@render children?.()}

			<footer class="flex items-center justify-center gap-4 text-center text-primary">
				<LanguageSwitcher
					full
					locale={data.locale}
					pathname={data.pathname}
					class="cursor-pointer px-4 py-2 outline transition-colors hover:bg-slate-200"
				/>

				&bull;

				<a href="/" class="px-4 py-2 transition-colors hover:bg-slate-200"> Go back </a>
			</footer>
		</Card>
	</main>
</div>

<style>
	@reference "@/app.css";

	footer :global(a) {
		@apply outline;
	}
</style>
