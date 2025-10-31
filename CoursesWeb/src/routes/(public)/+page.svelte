<script lang="ts">
	import type { PageProps } from "./$types";
	import FeaturedEvent from "@components/featured-event.svelte";
	import { t } from "$lib/translations";
	import PageTitle from "@components/page-title.svelte";

	let { data }: PageProps = $props();
	const featuredEvent = data.events![0];
	const events = data.events!.slice(1);
</script>

<PageTitle title={$t("common.pages.home.title")} />

<div class="container mx-auto">
	<header class="mb-6">
		<h2 class="my-2 text-3xl font-bold">{$t("common.pages.home.heading")}</h2>
		<FeaturedEvent event={featuredEvent} />
	</header>

	<div class="grid grid-cols-3 gap-6">
		{#each events as event}
			<article class="bg-slate-300">
				<h3>{event.titleEn}</h3>
			</article>
		{/each}
	</div>
</div>
