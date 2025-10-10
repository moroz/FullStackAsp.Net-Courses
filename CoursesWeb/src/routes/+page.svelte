<script lang="ts">
	import type { PageProps } from "./$types";
	import FeaturedEvent from "@components/featured-event.svelte";

	let { data }: PageProps = $props();
	const featuredEvent = data.events![0];
	const events = data.events!.slice(1);
</script>

<div class="container mx-auto">
	<header>
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
